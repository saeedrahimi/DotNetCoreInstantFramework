using System.Collections.Generic;
using Core.Domain.Identity.AggregateRoot;
using Core.Domain._Shared;


namespace Infrastructure.Data.Repository.Identity
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

        public override Result ValidateModel(List<User> model)
        {

            return base.ValidateModel(model);
        }
    }
}
