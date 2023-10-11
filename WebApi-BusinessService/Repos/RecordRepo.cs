using Devops_Auth_MicroService.Repos;
using Microsoft.EntityFrameworkCore;
using WebApi_BusinessService.Entities;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Models;

namespace WebApi_BusinessService.Repos
{
    public class RecordRepo : GenericRepository<AppMonthRecords>, IRecordRepo
    {

        public AuthDbContext1 context;
        public RecordRepo(AuthDbContext1 context): base(context)
        {
            this.context = context;
        }

        public async Task<List<AppMonthRecords>> GetAllActiveRecords(Guid userId)
        {
            List<AppMonthRecords> result = await   DbSet
                                                .ToListAsync();
            return result;
        }

     
    }
}
