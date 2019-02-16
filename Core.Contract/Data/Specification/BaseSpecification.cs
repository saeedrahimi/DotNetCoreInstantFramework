using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Contract.Data.Specification
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
