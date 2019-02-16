using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
{
    public class UserToken:BaseEntity
    {
      
        public string AccessToken { get; internal set; }
        public DateTime ExpireDate { get; internal set; }


       
        public Guid UserId { get; internal set; } 
        public virtual User User { get; internal set; }
    }
}
