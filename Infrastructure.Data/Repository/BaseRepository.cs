using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Domain._Shared;
using Core.Domain._Shared.Data.Repository;
using Core.Domain._Shared.Data.Specification;


namespace Infrastructure.Data.Repository
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext _dbContext;
        public virtual IEntityValidator<T> Validator { get; set; }
      



        protected BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public virtual Result Add(T entity)
        {
            var validate = Validator.ValidateModelForCreate(entity);
            
            if (!validate.Success) return validate;

            _dbContext.Set<T>().Add(entity);

            return new Result()
            {
                Success = true,
                Data = entity
            };
        }

        public virtual Result Update(T entity)
        {

            var validate = Validator.ValidateModelForUpdate(entity);
            if (!validate.Success) return validate;

            _dbContext.Set<T>().Update(entity);
            

            return new Result()
            {
                Success = true,
                Data = entity
            };
        }

        public virtual Result Remove(T entity)
        {

            var validate = Validator.ValidateModelForRemove(entity);
            if (!validate.Success) return validate;

            _dbContext.Set<T>().Remove(entity);

            return new Result()
            {
                Success = true,
                Data = entity
            };
        }

        public virtual Result Get(ISpecification<T> spec)
        {            
            // return the result of the query using the specification's criteria expression
            var result=ApplySpecification(spec).ToList();

            var validate = Validator.ValidateModel(result);
            if (!validate.Success) return validate;
            return new Result()
            {
                Success = true,
                Data = result
            };
        }

        public virtual Result Get(Expression<Func<T, bool>> condition)
        {
            var result = _dbContext.Set<T>().Where(condition).ToList();

            var validate = Validator.ValidateModel(result);
            if (!validate.Success) return validate;

            return new Result()
            {
                Success = true,
                Data = result
            };
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
