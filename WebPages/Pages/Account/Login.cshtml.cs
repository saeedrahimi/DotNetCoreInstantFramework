using System.Threading.Tasks;
using Core.Domain.Contract.Services.Application.Identity;
using Core.Domain.Contract.Services.Application.Identity.Model;
using Core.Domain.Identity;
using Core.Domain.Identity.AggregateRoot;
using Core.Domain.Identity.DTO;
using Core.Domain.Identity.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPages.Authentication;

namespace WebPages.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IIdentityService _ideIdentityService;

        public LoginModel(IIdentityService identityService)
        {
            _ideIdentityService = identityService;
        }


        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty] private bool RememberMe { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl)
        {

            var siginResult = await _ideIdentityService.SignIn(new SignInModel()
            {
                UserName = UserName,
                Password = Password,
                IpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4()
            });

            if (!siginResult.Success)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                ModelState.AddModelError("", siginResult.Message);
                return Page();
            }

            var user = siginResult.GetData<User>();
            var signInconfig = AuthenticationHelper.GetSigninConfig(user);

           await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, signInconfig.ClaimsPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = RememberMe,
                    IssuedUtc = signInconfig.IssuedUtc,
                    ExpiresUtc = signInconfig.ExpiresUtc
                });

            if (string.IsNullOrEmpty(returnUrl)) returnUrl = "/index";
            return Redirect(returnUrl);

        }



        #region Google Login
        public IActionResult OnPostGoogle(string provider, string returnUrl)
        {

            var redirectUrl = "/Account/ExternalLoginCallback";

            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            properties.Items["LoginProvider"] = provider;

            return Challenge(properties, provider);
        }
        #endregion

    }
}