using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Contract;
using Core.Domain.Identity.AggregateRoot;
using Core.Domain.Identity.Repository;
using Core.Domain._Shared;
using Core.Domain._Shared.Data;
using MediatR;

namespace Core.Domain.Identity.Query
{
    public class CheckUserAuthenticateQuery :IRequest<Result>
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public CheckUserAuthenticateQuery(string userName,string password)
        {
            UserName = userName;
            Password = password;
        }
    }
     


    public class CheckUserAuthenticateQueryHandler : IRequestHandler<CheckUserAuthenticateQuery,Result>
    {

        private readonly IUserRepository _userRepository;

        public CheckUserAuthenticateQueryHandler(IUnitofWork uow)
        {
            _userRepository = uow.UserRepository;
        }

        public Task<Result> Handle(CheckUserAuthenticateQuery request, CancellationToken cancellationToken)
        {
            
            var specific = _userRepository.SpecificationFactory.UserPassMatchSpec(request.UserName, request.Password);
            var getUserResult = _userRepository.Get(specific);

            if (!getUserResult.Success)
                return Task.FromResult(getUserResult); 

            var resultData = getUserResult.GetData<List<User>>();

            if (resultData.Count > 1)
            {
                Task.FromResult(new Result()
                {
                    Success = false,
                    Message = "مغایرت در نام کاربری",
                });
            }

            // Raising Event ...
            return Task.FromResult(getUserResult);
        }
    }
}
