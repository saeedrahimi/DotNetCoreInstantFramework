using System;
using System.Linq.Expressions;
using Core.Domain.Contract.Data.Specification;
using Core.Domain.Contract.Ioc;

namespace Core.Domain.Contract.Data.Repository
{
    public interface IBaseRepository<T> where T: BaseEntity 
    {

        [ImportProperty]
        IEntityValidator<T> Validator { get; set; }

     

        Result Add(T entity);
        Result Update(T entity);
        Result Remove(T entity);
        Result Get(ISpecification<T> spec);
         

        [Obsolete]
        Result Get(Expression<Func<T,bool>> where);

    }
}
