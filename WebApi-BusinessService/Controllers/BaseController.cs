
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Utils;
using WebApi_BusinessService.Utils.Middlewares;

namespace WebApi_BusinessService.Controllers
{
    public class BaseController : ControllerBase

    {

       protected Guid userID { get; set; } 
       protected IUnitOfWork uow { get; set; }
       public BaseController(IUnitOfWork uow, HttpContext httpContext )
        {
            this.uow = uow;
            
            if (httpContext.Items?.First(el => el.Key == "userId").Value != null)
            {
                Guid.TryParse(httpContext.Items?.First(el => el.Key == "userId").Value.ToString(), out Guid ID);
                userID = ID;
                Console.WriteLine(userID);

            }

        }
        
        
    }
}
