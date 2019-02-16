using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Core.Contract;
using Core.Contract.Data;
using Core.Contract.Services.Shared;
using Core.Entities.Identity;

namespace Infrastructure.Data.EF.Repository.Identity
{
    public class UserValidator : BaseEntityValidator<User>
    {

        public UserValidator(AppDbContext dbContext) : base(dbContext)
        {

        }


        public override Result ValidateModel(User model)
        {
           
            return base.ValidateModel(model);
        }

        public override Result ValidateModels(List<User> model)
        {

            return base.ValidateModels(model);
        }
    }
}
