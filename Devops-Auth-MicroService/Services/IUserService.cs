namespace Devops_Auth_MicroService.Interfaces;
public interface IUserService
{
    public Task<User> addUser(RegisterViewModel model);

    public Task<User> getUserFromEmailPassword(string email, string password);
    Task<bool> IsValidUserAsync(User users);

    Task<UserRefreshToken> AddUserRefreshTokens(UserRefreshToken user);

    UserRefreshToken GetSavedRefreshTokens(string userId, string refreshtoken);

    void DeleteUserRefreshTokens(string userId, string refreshToken);

}