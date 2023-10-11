using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Devops_Auth_MicroService.Controllers
{
    public class BaseController : ControllerBase
    {
       protected IUnitOfWork uow { get; set; }
        protected UserManager<IdentityUser> userManager { get; set; }

       public BaseController(IUnitOfWork uow , UserManager<IdentityUser> userManager)
        {
            this.uow = uow;
            this.userManager = userManager;
        }
        protected BaseService getService(Type _serviceType)
        {
            ConstructorInfo constructor = _serviceType.GetConstructor(new Type[] {typeof(IUnitOfWork), typeof(UserManager<IdentityUser>)  });
            BaseService instance = (BaseService)constructor.Invoke(new object[] {uow , userManager });
            return instance;
            
        }
    }
}
