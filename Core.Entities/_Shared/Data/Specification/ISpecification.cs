using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Domain._Shared.Data.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
