using System;
using System.Linq.Expressions;
using Core.Domain.Contract;
using Core.Domain._Shared.Data.Specification;
using Core.Domain._Shared.Ioc;

namespace Core.Domain._Shared.Data.Repository
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
