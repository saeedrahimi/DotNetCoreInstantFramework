using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
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
