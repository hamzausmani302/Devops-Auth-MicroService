using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using WebApi_BusinessService.Model;
using WebApi_BusinessService.Model.ViewModels;

namespace WebApi_BusinessService.Utils.Middlewares
{
    public class AuthenticateMiddleware
    {
        private readonly RequestDelegate _next;
        private ApplicationSettings Settings;
        public AuthenticateMiddleware(RequestDelegate next, IOptions<ApplicationSettings> options)
        {
            _next = next;
            Settings = options.Value;
        }

        public async Task InvokeAsync(HttpContext context , IOptions<ApplicationSettings> options)
        {
           

            Settings = options.Value;
            string token = context.Request?.Headers["auth_token"];
            if (token == null)
            {
                context.Response.WriteAsJsonAsync(new ResponseViewModel<object>() { Status = (int)HttpStatusCode.Unauthorized, data = null }, typeof(ResponseViewModel<object>));
                return;
            }
            (bool isValid, Guid id) = GetUserIdFromToken(token);
            if (isValid == false)
            {
                context.Response.WriteAsJsonAsync(new ResponseViewModel<object>() { Status = (int)HttpStatusCode.Unauthorized, data = null }, typeof(ResponseViewModel<object>));
                return;
            }
            context.Items["userId"] = id;
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }


        private (bool, Guid) GetUserIdFromToken(string token)
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
            if (principal == null)
            {
                return (false, Guid.NewGuid());
            }
            bool isValid = Guid.TryParse(principal.Claims?.First(el => el.Type== "ID")?.Value, out Guid id);
            return (isValid, id);

        }

    }
}
