using WebApi_BusinessService.Entities;

namespace WebApi_BusinessService.Interfaces
{
    public interface IRecordRepo : IGenericRepository<AppMonthRecords>
    {
        public Task< List<AppMonthRecords> > GetAllActiveRecords(Guid userId);
       
            

    }
}
