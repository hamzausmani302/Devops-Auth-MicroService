using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Models;
using Devops_Auth_MicroService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Devops_Auth_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork uow , UserManager<IdentityUser> userManager): base(uow , userManager)
        {
            _userManager = userManager;
        }
        private readonly UserManager<IdentityUser> _userManager;

        [HttpGet]
        public List<User> getUsers()
        {
            return uow.appUserRepo.GetAll();

        }

        [HttpPost]
        public async void addUser()
        {
        }
        


    }
}
