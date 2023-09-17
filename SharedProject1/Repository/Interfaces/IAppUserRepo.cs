using Devops_Auth_MicroService.Models;

namespace Devops_Auth_MicroService.Interfaces
{
    public interface IAppUserRepo : IGenericRepository<User>
    {   
        public Task<User> getUserWithCredentials(string username, string password);
    }
}
