using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Contract;
using Core.Domain.Identity.AggregateRoot;
using Core.Domain.Identity.Repository;
using Core.Domain._Shared;
using Core.Domain._Shared.Data;
using MediatR;

namespace Core.Domain.Identity.Command
{
    public class UpdateUserTokenCommand : IRequest<Result>
    {

        public User User { get; set; }

        public UpdateUserTokenCommand(User user,string token)
        {
            user?.SetToken(token);
        }

    }

    public class UpdateUserTokenCommandHandler :IRequestHandler<UpdateUserTokenCommand, Result>
    {

        private readonly IUserRepository _userRepository;
        public UpdateUserTokenCommandHandler(IUnitofWork unitofWork)
        {
            _userRepository = unitofWork.UserRepository;
        }

        public Task<Result> Handle(UpdateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var saveTokenResult=_userRepository.Update(request.User);
            if (!saveTokenResult.Success)
            {
                return Task.FromResult(new Result()
                {
                    Success = false,
                    Message = "خطا در ذخیره سازی نشانه کاربر",
                });
            }

            return Task.FromResult(saveTokenResult);
        }
    }
}
