using System.Collections.Generic;
using Core.Domain.Contract;
using Core.Domain.Identity.AggregateRoot;

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
