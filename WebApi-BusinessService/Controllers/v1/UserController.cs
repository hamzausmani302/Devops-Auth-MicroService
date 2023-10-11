using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi_BusinessService.Entities;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Model.ViewModels;
using WebApi_BusinessService.Services;
using WebApi_BusinessService.Utils;
using WebApi_BusinessService.Utils.Middlewares;

namespace WebApi_BusinessService.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        private CustomAutoMapper<UserViewModel, AppUser> automapper;

        [HttpGet("")]
        public async Task<ResponseViewModel<List<AppUser>>> getUsers()
        {
            List<AppUser> users = uow.userRepo.GetAll();
            return new ResponseViewModel<List<AppUser>>(){Status=(int)HttpStatusCode.OK , data=users  };
        }

        [HttpPost("")]
        public async Task<IActionResult> addUser(UserViewModel viewModel)
        {
            TryValidateModel(viewModel);
            AppUser mapped = automapper.MapModel(viewModel);
            IntegrationService integrationService = new IntegrationService(config);
            mapped.Id = Guid.NewGuid();
            try
            {
                await integrationService.RegisterInAuth(new RegisterViewModel() { Id = mapped.Id, Email = "gamzausmani21@gmal.com", UserName = viewModel.Name, Password = "string12345" });
                var result = await uow.userRepo.Add(mapped);

                return Ok(new ResponseViewModel<AppUser>() { Status = (int)HttpStatusCode.Created, data = result });
            }catch(Exception e)
            {
                return BadRequest();
            }
            }

        IConfiguration config;
        public UserController(IUnitOfWork uow, IHttpContextAccessor context , IConfiguration config) : base(uow , context.HttpContext)
        {
            automapper = new CustomAutoMapper<UserViewModel , AppUser>();
            this.config = config;
        }
    }
}
