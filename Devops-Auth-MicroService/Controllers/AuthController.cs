using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Devops_Auth_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        
        private IUserService _userService;
        
        public AuthController(IUnitOfWork uow, IUserService _userService  ) : base(uow){
            this._userService = _userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            TryValidateModel(viewModel);
            User addedUser = await _userService.addUser(viewModel);
            Token token = uow.jwtRepo.Generatetoken(addedUser.Id);
            return Ok(token);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            TryValidateModel(viewModel);
            User user = await _userService.getUserFromEmailPassword(viewModel.Name, viewModel.Password);
            Token token = uow.jwtRepo.Generatetoken(user.Id);
            return Ok(token);
        }





    }
}
