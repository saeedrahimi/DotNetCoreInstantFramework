using System.ComponentModel.DataAnnotations;
using System.Net;
using FluentValidation;

namespace Core.Domain.Contract.Services.Application.Identity.Model
{
    public class SignInModel: BaseModel<SignInModel>
    {
        
        public SignInModel()
        {
            Validator = new LoginModelValidator();

        }

        [Required]
        public string UserName { get; set; }

       

        [Required]
        public string Password { get; set; }

        [Required]
        public IPAddress IpAddress { get; set; }

        private class LoginModelValidator:AbstractValidator<SignInModel>
        {
            public LoginModelValidator()
            {
                RuleFor(r => r.Password).NotEmpty();
                RuleFor(r => r.IpAddress).NotEmpty();
                RuleFor(r => r.UserName).NotEmpty();
            }
        }

    }

}
