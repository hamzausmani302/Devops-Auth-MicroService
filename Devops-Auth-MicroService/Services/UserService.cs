using Devops_Auth_MicroService.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Devops_Auth_MicroService.Services
{
    public class UserService : BaseService{
        
         private IUnitOfWork uow;
        private UserManager<IdentityUser> userManager;
        public UserService(IUnitOfWork uow , UserManager<IdentityUser> userManager)
        {
            this.uow = uow;
            this.userManager = userManager;
        }
        public async Task<User> addUser(RegisterViewModel model)
        {
            try
            {
                User user = await uow.appUserRepo.Add(new User() {   Id=model.Id.ToString() ,  Name = model.UserName, Email = model.Email, Password = model.Password, PhoneNumber = "123421312312" });
                
                return user;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserRefreshToken>  AddUserRefreshTokens(UserRefreshToken userToken)
        {
            UserRefreshToken token = await uow.jwtRepo.Add(userToken);
            await uow.CompleteAsync();
            return token;
        }

        public void DeleteUserRefreshTokens(string userId, string refreshToken)
        {
            var item = uow.Context.UserRefreshTokens.FirstOrDefault(x => x.UserId == userId && x.RefreshToken == refreshToken);
            if (item != null)
            {
                uow.Context.UserRefreshTokens.Remove(item);
            }
        }

        public UserRefreshToken GetSavedRefreshTokens(string userId, string refreshtoken)
        {
            return uow.Context.UserRefreshTokens.FirstOrDefault(x => x.UserId == userId && x.RefreshToken == refreshtoken && x.isActive == true);
        }

        public async Task<User> getUserFromEmailPassword(string name, string password)
        {
            User user=   await uow.appUserRepo.getUserWithCredentials(name, password);
            return user;
            
        }

        public async Task<bool> IsValidUserAsync(User users)
        {
            var u = userManager.Users.FirstOrDefault(o => o.UserName == users.Name);
            var result = await userManager.CheckPasswordAsync(u, users.Password);
            return result;
        }

    
    }
}
