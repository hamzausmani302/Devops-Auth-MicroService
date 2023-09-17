using Devops_Auth_MicroService.Validators;
using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    
    public string Name { get; set; }
    
    public string Password { get; set; }
}