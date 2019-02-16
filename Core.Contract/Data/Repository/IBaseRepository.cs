using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Contract.Data.Specification;
using Core.Contract.Ioc;
using Core.Entities;

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
