using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Contract.Services.Application.Identity;
using Core.Domain.Identity;
using Core.Domain.Identity.AggregateRoot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebPages.Authentication;


namespace WebPages.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginCallbackModel : PageModel
    {
        private readonly IIdentityService _identityService;
        public ExternalLoginCallbackModel(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        public async Task<IActionResult> OnGet(string returnUrl = null, string remoteError = null)
        {

            if (remoteError != null)
            {
                ModelState.AddModelError("", remoteError);
                return Page();
            }

            var info = await GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError("", "not found Info");
                return Page();
            }


            var identity = info?.Principal;

            //var name = identity?.Claims.Where(c => c.Type == ClaimTypes.Name)
            //    .Select(c => c.Value).SingleOrDefault();

            var email = identity?.Claims.Where(c => c.Type == ClaimTypes.Email)
                .Select(c => c.Value).SingleOrDefault();

            //var phone = identity?.Claims.Where(c => c.Type == ClaimTypes.MobilePhone)
            //    .Select(c => c.Value).SingleOrDefault();


            var existUserResult = _identityService.ExistUser(email);
            if (existUserResult.Success)
            {
                var user = existUserResult.GetData<User>();
                var signInconfig = AuthenticationHelper.GetSigninConfig(user);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, signInconfig.ClaimsPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        IssuedUtc = signInconfig.IssuedUtc,
                        ExpiresUtc = signInconfig.ExpiresUtc
                    });

                if (string.IsNullOrEmpty(returnUrl)) returnUrl = "/index";
                return RedirectToPage(returnUrl);
            }

            return RedirectToPage("Register");


        }


        private async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            var auth = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var items = auth?.Properties?.Items;

            if (auth?.Principal == null || items == null || !items.ContainsKey("LoginProvider"))
            {
                return null;
            }

            var providerKey = auth.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var provider = items["LoginProvider"] as string;
            if (providerKey == null || provider == null)
            {
                return null;
            }

            return new ExternalLoginInfo(auth.Principal, provider, providerKey, provider)
            {
                AuthenticationTokens = auth.Properties.GetTokens()
            };


        }



    }
}