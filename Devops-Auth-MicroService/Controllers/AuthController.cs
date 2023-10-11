using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Models;
using Devops_Auth_MicroService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Devops_Auth_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public RoleManager<IdentityRole> roleManager;
        public AuthController(IUnitOfWork uow , UserManager<IdentityUser> um , RoleManager<IdentityRole> rm ) : base(uow , um){
            roleManager = rm;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            TryValidateModel(viewModel);
            UserService _userService = (UserService)getService(typeof(UserService));
            User addedUser = await _userService.addUser(viewModel);
            Token token = uow.jwtRepo.Generatetoken(addedUser.Id.ToString());
            return Ok(token);
        }
        [AllowAnonymous]
        [HttpGet("")]
        public string Test()
        {
            return "Ok";
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            TryValidateModel(viewModel);
            UserService _userService = (UserService)getService(typeof(UserService));
            User user = await _userService.getUserFromEmailPassword(viewModel.Name, viewModel.Password);
            
            if(user == null)
            {
                return NotFound();
            }
            Token token = uow.jwtRepo.Generatetoken(user.Id.ToString());
            return Ok(token);
        }

        


    }
}
