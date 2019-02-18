using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Core.Domain.Identity;
using Core.Domain.Identity.AggregateRoot;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebPages.Authentication
{
    public static class AuthenticationHelper
    {
        public static string GetClaim(this IIdentity identity, string name)
        {
            var claimsidentity = (ClaimsIdentity)identity;
            IEnumerable<Claim> claims = claimsidentity.Claims;
            var value = "";
            try
            {
                value = claims.ToDictionary(claim => claim.Type, claim => claim.Value)[name];
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return value;
        }


        public static SignInConfig GetSigninConfig(User user)
        {


            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.DisplayName));

            foreach (var userRole in user.UserRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            return new SignInConfig()
            {
                ClaimsPrincipal= new ClaimsPrincipal(identity),
                IssuedUtc = DateTimeOffset.UtcNow,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(3)
            };
        }

        
    }

    public class SignInConfig
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public DateTimeOffset IssuedUtc { get; set; }
        public DateTimeOffset ExpiresUtc { get; set; }
    }
}
