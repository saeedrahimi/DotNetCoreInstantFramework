using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using Core.Domain.Contract;
using Core.Domain.Contract.Services;
using Core.Domain._Shared;
using Core.Domain._Shared.Logger;
using Core.Domain._Shared.Services;
using Microsoft.EntityFrameworkCore.Internal;

namespace Web.Framework
{

    public class ServiceProxy<T> : DispatchProxy where T : class
    {
        private T _decorated;
        private static ILogger<T> _logger;

        public static T Create(T decorated, ILogger<T> logger)
        {
            _logger = logger;


            object proxy = Create<T, ServiceProxy<T>>();
            ((ServiceProxy<T>)proxy).SetParameters(decorated);

            return (T)proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {

            var serviceInterceptors = targetMethod.GetCustomAttributes(typeof(Interceptor), true);
            if (!serviceInterceptors.Any())
                return targetMethod.Invoke(_decorated, args);


            var serviceInterceptor = (Interceptor)serviceInterceptors[0];
            if (targetMethod.ReturnType != typeof(Result) && targetMethod.ReturnType != typeof(Task<Result>))
            {
                throw new Exception($"for use of ExceptionHandling method return type shoulde be {typeof(Result)}");
            }

            try
            {

                //Validate Ipute Model
                if (serviceInterceptor.InputModelValidation)
                {
                    foreach (var arg in args)
                    {
                        if (!(arg is IModelValidator)) continue;

                        var validateResult = (arg as IModelValidator).Validate();
                        if (!validateResult.Success)
                        {
                            return validateResult;
                        }
                    }
                }

                //execute Method
                if (serviceInterceptor.TransactionScope)
                {
                    using (new TransactionScope())
                    {
                        return targetMethod.Invoke(_decorated, args);
                    }
                }

                return targetMethod.Invoke(_decorated, args);

            }
            catch (Exception e)
            {
                if(serviceInterceptor.LogMode != LogMode.Non)
                    _logger.Fatal(e,e.Message);

                return new Result()
                {
                    Success = false,
                    Message = e.Message
                };
            }

        }

        private void SetParameters(T decorated)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
        }

    }


}
