using System;

namespace Core.Domain.Contract
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
