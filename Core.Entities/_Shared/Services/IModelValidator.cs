using Core.Domain.Contract;

namespace Core.Domain._Shared.Services
{
    public interface IModelValidator
    {
        Result Validate();
    }
}
