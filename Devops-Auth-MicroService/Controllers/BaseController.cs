using Devops_Auth_MicroService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Devops_Auth_MicroService.Controllers
{
    public class BaseController : ControllerBase
    {
       protected IUnitOfWork uow { get; set; }
       public BaseController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
