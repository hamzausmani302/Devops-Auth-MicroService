using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Models;

namespace Devops_Auth_MicroService.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public AuthDbContext Context { get; set; }
        

        public UnitOfWork(AuthDbContext context , IAppUserRepo appUserRepo , IJWTRepo jwtRepo)
        {
            
            this.Context = context;
            this.appUserRepo = appUserRepo;
            this.jwtRepo = jwtRepo;
        }

        public IAppUserRepo appUserRepo { get; private set; }
        public IJWTRepo jwtRepo { get; private set; }
        
        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
