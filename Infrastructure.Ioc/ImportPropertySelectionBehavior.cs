using System;
using System.Linq;
using System.Reflection;
using Core.Domain.Contract.Ioc;
using SimpleInjector.Advanced;

namespace Infrastructure.Ioc
{
    public class ImportPropertySelectionBehavior: IPropertySelectionBehavior
    {
        public bool SelectProperty(Type implementationType, PropertyInfo propertyInfo)
        {


            var interfaces = implementationType.GetInterfaces();


            foreach (var Interface in interfaces)
            {
                if (Interface.GetProperty(propertyInfo.Name)?.GetCustomAttributes(typeof(ImportProperty)).Any()??false)
                {
                    return true;
                }
            }


            //var hasAttribute = implementationType.GetInterface("IUnitofWork")?.GetProperty(propertyInfo.Name)?
            //    .GetCustomAttributes(typeof(ImportedProperty)).Any();

            return false;


        }
    }
}
