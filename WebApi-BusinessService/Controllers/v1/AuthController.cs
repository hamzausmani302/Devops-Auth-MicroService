using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi_BusinessService.Entities;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Model.ViewModels;

namespace WebApi_BusinessService.Controllers.v1
{
    public class AuthController : BaseController
    {

        public AuthController(IUnitOfWork uow , IHttpContextAccessor context) : base(uow , context.HttpContext) {
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<string> Login()
        {
            string dat = await   Task.FromResult("tst");
            return dat;
        }


    }
}
