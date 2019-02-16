﻿using System;
using Core.Contract.Logger;

namespace Core.Contract.Services.Shared
{
    public class Interceptor:Attribute
    {
       


        public Interceptor()
        {
            Log = LogMode.Non;
            ExceptionHandling = true;
            InputModelValidation = true;
        }

        public LogMode Log { get; set; }
        public bool ExceptionHandling { get; set; }
        public bool InputModelValidation { get; set; }
      
        

    }
}