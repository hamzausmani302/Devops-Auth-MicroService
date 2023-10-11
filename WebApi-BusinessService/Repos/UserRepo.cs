using Devops_Auth_MicroService.Repos;
using WebApi_BusinessService.Entities;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Models;

namespace WebApi_BusinessService.Repos
{
    public class UserRepo  : GenericRepository<AppUser> , IUserRepo
    {
        public AuthDbContext1 context;
        public UserRepo(AuthDbContext1 context): base(context) {
            this.context = context;
        }
    }
}
