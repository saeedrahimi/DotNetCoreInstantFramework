using System;
using Core.Domain.Identity.AggregateRoot;

namespace Core.Domain.Identity.Poco
{
    public class UserRoles
    {

        public Guid UserId { get; internal set; }
        public virtual User User { get; internal set; }

        public Guid RoleId { get; internal set; }
        public virtual Role Role { get; internal set; }

    }
}
