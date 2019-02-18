using System;
using System.Reflection;
using System.Threading.Tasks;
using Core.Domain.Contract;
using Core.Domain.Contract.Logger;
using Core.Domain.Contract.Services.Shared;
using Microsoft.EntityFrameworkCore.Internal;

namespace Web.Framework
{

    public class ServiceProxy<T> : DispatchProxy
    {
        private T _decorated;
        private static ILogger _logger;

        public static T Create(T decorated, ILogger logger)
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

            if (!serviceInterceptor.ExceptionHandling)
            {
                return targetMethod.Invoke(_decorated, args);
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
                return targetMethod.Invoke(_decorated, args);
            }
            catch (Exception e)
            {
                if (serviceInterceptor.Log != LogMode.Non)
                    _logger.Log(LogMode.Exception,e.Message);

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
