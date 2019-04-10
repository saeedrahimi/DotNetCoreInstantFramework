using System.Collections.Generic;

namespace Core.Domain.Contract.Data.Repository
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
