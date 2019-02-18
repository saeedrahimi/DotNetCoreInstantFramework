using System;
using System.Linq.Expressions;
using Core.Contract.Data.Specification;
using Core.Contract.Ioc;


namespace Core.Contract.Data.Repository
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
