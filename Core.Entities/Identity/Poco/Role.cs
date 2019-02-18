using System;
using System.Collections.Generic;
using Core.Domain.Contract;

namespace Core.Domain.Identity.Poco
{
    public class Role:BaseEntity
    {

        public Role()
        {
        }


        public Guid Id { get; internal set; }
        public string Name { get; internal set; }

        public virtual ICollection<UserRoles> UserRoles { get; internal  set; }
    }
}
