using System.Threading;
using System.Threading.Tasks;
using Core.Contract.Data;
using Core.Contract.Data.Repository.Identity.User;
using MediatR;

namespace Core.Contract.CQRS.User.Command
{
    public class UpdateUserTokenCommand : IRequest<Result>
    {

        public Core.Entities.Identity.User User { get; set; }

        public UpdateUserTokenCommand(Core.Entities.Identity.User user,string token)
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
