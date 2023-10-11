using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using WebApi_BusinessService.Model;
using System.Security.Claims;

namespace WebApi_BusinessService.Utils.Middlewares
{
    public class CustomAuthenticationFilter : IActionFilter
    {
        private ApplicationSettings Settings;
        public CustomAuthenticationFilter(IOptions<ApplicationSettings> Settings) {
            this.Settings = Settings.Value;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token =  context.HttpContext?.Request?.Headers["auth_token"];
            if(token == null)
            {
                context.Result = new ForbidResult();
                return;
            }
            (bool isValid  , Guid id) = GetUserIdFromToken(token);
            if(isValid == false)
            {
                context.Result = new ForbidResult();
                return;
            }
            context.HttpContext.Items["userId"] = id;
        }

        private (bool   , Guid) GetUserIdFromToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(Settings.Key);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if(principal == null) {
                return (false, Guid.NewGuid());
            }
            bool isValid = Guid.TryParse(principal.Claims?.First(el => el.ValueType == "id")?.Value , out Guid id);
            return (isValid , id);

        }
    }
}
