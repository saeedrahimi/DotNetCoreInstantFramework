using System.Linq;
using Core.Domain.Contract;
using Core.Domain.Contract.Services;
using FluentValidation;

namespace Core.Domain._Shared.Services
{
    public class BaseModel<T> : IModelValidator
    {

        protected IValidator<T> Validator { private get; set; }


        public virtual Result Validate()
        {
            if (Validator == null)
            {
                return new Result()
                {
                    Success = true,
                    Data = true,
                    Message = "Not Implement Validator For Model"
                };
            }

            var validateResult = Validator.Validate(this);
            if (!validateResult.IsValid)
            {
                return new Result()
                {
                    Success = false,
                    Data = validateResult.IsValid,
                    Message = validateResult.Errors.FirstOrDefault()?.ErrorMessage
                };
            }

            return new Result()
            {
                Success = true,
                Data = true
            };


        }

    }
}
