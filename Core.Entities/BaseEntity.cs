using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Entities
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            LastModifyDate=DateTime.Now;
            IsActive = true;
        }

       

        public DateTime CreateDate { get; set; }
        public DateTime LastModifyDate { get; set; }

        public bool IsActive { get; set; }

    }
}
