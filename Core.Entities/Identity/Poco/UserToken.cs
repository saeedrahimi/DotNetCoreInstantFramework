using System;
using Core.Domain.Contract;
using Core.Domain.Identity.AggregateRoot;

namespace Core.Domain.Identity.Poco
{
    public class UserToken:BaseEntity
    {
      
        public string AccessToken { get; internal set; }
        public DateTime ExpireDate { get; internal set; }


       
        public Guid UserId { get; internal set; } 
        public virtual User User { get; internal set; }
    }
}
