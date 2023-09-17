using Devops_Auth_MicroService.Model;
using Devops_Auth_MicroService.Models;
using Devops_Auth_MicroService.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class JWTRepo : GenericRepository<UserRefreshToken>, IJWTRepo
{
    ApplicationSettings Settings { get; set; }
    AuthDbContext Context { get; set; }

    public JWTRepo(AuthDbContext dbContext , IOptions<ApplicationSettings> settings) : base(dbContext)
    {
        Settings = settings.Value;
        Context = dbContext;
    }

    public string GenerateRefreshToken(string userId)
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        return null;
    }
    public Token Generatetoken(string userId)
    {
        try
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(Settings.Key);
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(

                    new Claim[] {
                    new Claim("ID", userId),
                    new Claim("role", "")
                    }
                ),
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = handler.CreateToken(descriptor);
            return new Token() { AccessToken = handler.WriteToken(token), RefreshToken = GenerateRefreshToken(userId) };
        }catch(Exception e)
        {
            return null;
        }
    }

    public ClaimsPrincipal GetPrincipalFromExpiredtoken(string token)
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
        JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        return principal;
    }
}