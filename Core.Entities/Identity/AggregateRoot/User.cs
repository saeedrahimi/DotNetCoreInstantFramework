using System;
using System.Collections.Generic;
using Core.Domain.Identity.Poco;
using Core.Domain._Shared;

namespace Core.Domain.Identity.AggregateRoot
{
    public  class User:BaseEntity
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string DisplayName { get; set; }

        public virtual  ICollection<UserRoles> UserRoles { get; private set; }
        protected virtual  UserToken Token { get; private set; }

        #region Functionality
        public void SetToken(string accessToken)
        {
            var token= new UserToken()
            {
                UserId =this.Id,
                CreateDate = DateTime.Now,
            };
            if (this.Token == null)
            {
                this.Token = token;
            }

            this.Token.AccessToken = accessToken;
            this.Token.ExpireDate = DateTime.UtcNow.AddDays(1);
            this.Token.LastModifyDate = DateTime.Now;

        }
        #endregion

    }
}
