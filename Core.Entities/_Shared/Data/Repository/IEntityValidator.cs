using System.Collections.Generic;
using Core.Domain.Contract;

namespace Core.Domain._Shared.Data.Repository
{
    public interface IEntityValidator<T>
    {

        Result ValidateModel(T model);
        Result ValidateModel(List<T> models);
        Result ValidateModelForCreate(T model);
        Result ValidateModelForUpdate(T model);
        Result ValidateModelForRemove(T model);
    }
}
