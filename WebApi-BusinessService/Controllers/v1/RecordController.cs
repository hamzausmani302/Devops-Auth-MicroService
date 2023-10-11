using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi_BusinessService.Entities;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Model.ViewModels;
using WebApi_BusinessService.Utils;

namespace WebApi_BusinessService.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecordController : BaseController
    { 
        private CustomAutoMapper<RecordViewModel , AppMonthRecords> automapper;

        [HttpGet("")]
        public async Task<ResponseViewModel<List<RecordViewModel>>> getRecords() {
            List<AppMonthRecords> records =  await uow.recordRepo.GetAllActiveRecords(userID);
             List<RecordViewModel> models = automapper.MapModelLstBack(records);
            return new ResponseViewModel<List<RecordViewModel>>() {Status = (int)HttpStatusCode.OK , data = models }; 
        }

        

        [HttpPost("")]
        public async Task<IActionResult> addRecord(RecordViewModel viewModel) {
            TryValidateModel(viewModel);
            AppMonthRecords mapped = automapper.MapModel(viewModel);
            AppUser currUser = uow.userRepo.GetAll().Where(el => el.Id == userID).First();
            mapped.User = currUser;
            AppMonthRecords rec =  await uow.recordRepo.Add(mapped);
            return Ok(automapper.MapModelBack(rec));

        }
        /*public async Task<IActionResult> editRecord()
        {
            await Task.CompletedTask;
            return Ok("");
        }

        public async Task<IActionResult> setRecordInActive()
        {
            await Task.CompletedTask;
            return Ok("");
        }*/

        public RecordController(IUnitOfWork uow , IHttpContextAccessor context) : base(uow , context.HttpContext)
        {
            automapper = new CustomAutoMapper<RecordViewModel, AppMonthRecords>();
        }
    }
}
