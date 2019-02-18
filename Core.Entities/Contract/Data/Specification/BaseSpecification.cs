using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Domain.Contract.Data.Specification
{
    public abstract class BaseSpecification<T>:ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; protected set; }
        public virtual List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected BaseSpecification()
        {

        }

       
      

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }


    }
}
