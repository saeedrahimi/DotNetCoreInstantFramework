using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Contract;
using Core.Domain.Contract.Services.Application.Identity;
using Core.Domain.Contract.Services.Application.Identity.Model;
using Core.Domain.Identity.AggregateRoot;
using Core.Domain.Identity.Command;
using Core.Domain.Identity.DTO;
using Core.Domain.Identity.Events;
using Core.Domain.Identity.Query;
using Core.Domain.Identity.Repository;
using Core.Domain.Identity.Services;
using Core.Domain._Shared;
using Core.Domain._Shared.Data;
using MediatR;
using Microsoft.IdentityModel.Tokens;


namespace Services.Application.Identity
{

    public class IdentityService : BaseApplicationService, IIdentityService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public IdentityService(IMediator mediator,IUnitofWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _userRepository = unitOfWork.UserRepository;
        }

        public async Task<Result> SignIn(SignInModel model)
        {

            var getUserResult = await  _mediator.Send(new CheckUserAuthenticateQuery(model.UserName, model.Password));
            if (!getUserResult.Success)
                return getUserResult;

            var resultData = getUserResult.GetData<List<User>>();

            var user = resultData.FirstOrDefault();
            var token = GenerateJwtToken(user);

            var saveTokenResult = await _mediator.Send(new UpdateUserTokenCommand(user,token));
            if (!saveTokenResult.Success)
                return saveTokenResult;

            Commit();
            await _mediator.Publish(new UserSignInEvent(user?.DisplayName));

            return new Result()
            {
                Success = true,
                Data = user
            };
        }

        public Result SignUp(SignUpModel model)
        {

            return new Result()
            {
                Success = true
            };
        }

        public Result ExistUser(string userName)
        {
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                return new Result()
                {
                    Success = false,
                    Message = "نام کاربری مقدار ندارد"
                };
            }
            var specific = _userRepository.SpecificationFactory.UserExistSpec(userName);
            var getUserResult = _userRepository.Get(specific);

            if (!getUserResult.Success) return getUserResult;

            var users = getUserResult.GetData<List<User>>();
            if (users.Count > 1)
            {
                return new Result()
                {
                    Success = false,
                    Message = "مغایرت در تعداد نام کاربری"
                };
            }

            var user = users.FirstOrDefault();
            return new Result()
            {
                Success = true,
                Data = user,
            };

        }


        #region Private 

        private string GenerateJwtToken(User user)
        {
            string key = "1!2@3eeddaaa222d--==jkjdjajkjhnjklasdBBBbaaakkeeiii&&&654422jjjdnmnnuu@2mmj8 6r1263898921555544djybd&&72323423188965assfdg''llj]]//&//t$";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iss, "any"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.DisplayName),
                
            };


            var jwttoken = new JwtSecurityToken(
                issuer: "any",
                audience: "any",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(jwttoken);

        }
        
        #endregion
    }
}
