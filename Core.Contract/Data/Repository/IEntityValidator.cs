using System.Collections.Generic;

namespace Core.Contract.Data.Repository
{
    public interface IEntityValidator<T>
    {

        Result ValidateModel(T model);
        Result ValidateModels(List<T> models);
        Result ValidateModelForCreate(T model);
        Result ValidateModelForUpdate(T model);
        Result ValidateModelForRemove(T model);
    }
}
