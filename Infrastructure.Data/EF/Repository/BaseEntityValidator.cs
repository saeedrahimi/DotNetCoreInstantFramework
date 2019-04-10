using System.Collections.Generic;
using System.Linq;
using Core.Domain.Contract;
using Core.Domain.Contract.Data.Repository;

namespace Infrastructure.Data.EF.Repository
{
    public class BaseEntityValidator<T>:IEntityValidator<T>
    {

        private readonly AppDbContext _dbContext;

        public BaseEntityValidator(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual Result ValidateModel(T model)
        {
            return new Result()
            {
                Success = true
            };
        }

        public virtual Result ValidateModel(List<T> models)
        {

            if (!models.Any())
            {
                return new Result()
                {
                    Success = false,
                    Message = "اطلاعاتی در سیستم یافت نشد",
                };
            }

            foreach (var model in models)
            {

                var result = ValidateModel(model);
                if (!result.Success)
                {
                    return result;
                }
            }

            return new Result()
            {
                Success = true
            };
        }

        public virtual Result ValidateModelForCreate(T model)
        {
            return new Result()
            {
                Success = true
            };
        }

        public virtual Result ValidateModelForUpdate(T model)
        {
            return new Result()
            {
                Success = true
            };
        }

        public virtual Result ValidateModelForRemove(T model)
        {
            return new Result()
            {
                Success = true
            };
        }

      
    }
}
