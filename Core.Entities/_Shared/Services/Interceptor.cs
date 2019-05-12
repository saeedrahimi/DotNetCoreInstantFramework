using System;
using Core.Domain._Shared.Logger;

namespace Core.Domain._Shared.Services
{
    public class Interceptor:Attribute
    {
        public Interceptor()
        {
            LogMode = LogMode.Non;
            InputModelValidation = true;
            TransactionScope = false;
        }

        public LogMode LogMode { get; set; }
        public bool InputModelValidation { get; set; }
        public bool TransactionScope { get; set; }
      
        

    }
}
