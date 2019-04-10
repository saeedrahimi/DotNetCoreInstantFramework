using System.ComponentModel.DataAnnotations;
using Core.Domain._Shared.Services;

namespace Core.Domain.Contract.Services.Application.Identity.Model
{
    public  class SignUpModel:BaseModel<SignUpModel>
    {
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

    }


    

}
