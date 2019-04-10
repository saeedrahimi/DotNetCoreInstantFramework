using System.Threading.Tasks;
using Core.Domain.Contract;
using Core.Domain.Contract.Services;
using Core.Domain.Contract.Services.Application.Identity.Model;
using Core.Domain.Identity.DTO;
using Core.Domain._Shared;
using Core.Domain._Shared.Services;

namespace Core.Domain.Identity.Services
{
    public interface IIdentityService : IBaseApplicationServices
    {


        [Interceptor]
        Task<Result> SignIn(SignInModel model);

        [Interceptor]
        Result SignUp(SignUpModel model);

        [Interceptor]
        Result ExistUser(string userName);

    }
}
