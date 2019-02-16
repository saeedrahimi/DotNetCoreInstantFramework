using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebPages.Authentication
{
    public class JwtBearerEventsHandler: JwtBearerEvents
    {
        public  override async Task TokenValidated(TokenValidatedContext context)
        {

            var userPrincipal = context.Principal;

            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }

            var serialNumberClaim = claimsIdentity.FindFirst(ClaimTypes.SerialNumber);
            if (serialNumberClaim == null)
            {
                context.Fail("This is not our issued token. It has no serial.");
                return;
            }

            var accessToken = context.SecurityToken as JwtSecurityToken;
            if (accessToken == null || string.IsNullOrWhiteSpace(accessToken.RawData))
            {
                context.Fail("This is not our issued token. It has no serial.");
                return;
            }

            //return base.TokenValidated(context);
        }

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            return base.AuthenticationFailed(context);
        }

        public override Task Challenge(JwtBearerChallengeContext context)
        {
            return base.Challenge(context);
        }

        public override Task MessageReceived(MessageReceivedContext context)
        {
            //const string tokenKey = "my.custom.jwt.token.key";
            //if (context.HttpContext.Items.ContainsKey(tokenKey))
            //{
            //    context.Token = (string)context.HttpContext.Items[tokenKey];
            //}
            return base.MessageReceived(context);
        }
    }
}
