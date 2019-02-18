using System;
using Core.Domain.Contract.Logger;

namespace Core.Domain.Contract.Services.Shared
{
    public class Interceptor:Attribute
    {
       


        public Interceptor()
        {
            Log = LogMode.Non;
            InputModelValidation = true;
            TransactionScope = false;
        }

        public LogMode Log { get; set; }
        public bool InputModelValidation { get; set; }
        public bool TransactionScope { get; set; }
      
        

    }
}
