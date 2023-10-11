

using WebApi_BusinessService.Models;

namespace WebApi_BusinessService.Interfaces { 

    public interface IUnitOfWork
    {
        public AuthDbContext1 Context { get; set; }
        public IRecordRepo recordRepo { get; set; }
        public IUserRepo userRepo { get; set; }


        public Task CompleteAsync();
    }
}
