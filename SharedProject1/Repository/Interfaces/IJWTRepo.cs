using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Models;
using System.Security.Claims;

public interface IJWTRepo : IGenericRepository<UserRefreshToken>
{
    public Token Generatetoken(string userId);
    public string GenerateRefreshToken(string userId);

    public ClaimsPrincipal GetPrincipalFromExpiredtoken(string token);

}