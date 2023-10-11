using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Models;

namespace WebApi_BusinessService.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public AuthDbContext1 Context { get; set; }
        public IRecordRepo recordRepo { get; set;}
        public IUserRepo userRepo { get; set;}
        

        public UnitOfWork(AuthDbContext1 context , IRecordRepo recordRepo , IUserRepo userRepo )
        {
            this.recordRepo = recordRepo;
            this.Context = context;
            this.userRepo = userRepo;
        }


        
        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
