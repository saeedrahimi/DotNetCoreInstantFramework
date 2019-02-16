using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
{
    public class UserRoles
    {

        public Guid UserId { get; internal set; }
        public virtual User User { get; internal set; }

        public Guid RoleId { get; internal set; }
        public virtual Role Role { get; internal set; }

    }
}
