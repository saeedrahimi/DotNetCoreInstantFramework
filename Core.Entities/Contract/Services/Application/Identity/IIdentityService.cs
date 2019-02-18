using System.Threading.Tasks;
using Core.Domain.Contract.Services.Application.Identity.Model;
using Core.Domain.Contract.Services.Shared;

namespace Core.Domain.Contract.Services.Application.Identity
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
