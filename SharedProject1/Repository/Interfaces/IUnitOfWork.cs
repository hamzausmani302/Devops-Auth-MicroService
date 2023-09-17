using Devops_Auth_MicroService.Models;

namespace Devops_Auth_MicroService.Interfaces
{
    public interface IUnitOfWork
    {
        public AuthDbContext Context { get; set; }
        IAppUserRepo appUserRepo { get;  }
        IJWTRepo jwtRepo { get; }
        public Task CompleteAsync();
    }
}
