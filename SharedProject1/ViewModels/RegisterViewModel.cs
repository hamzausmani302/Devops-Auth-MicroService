using Devops_Auth_MicroService.Validators;
using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [MinLength(0)]
    [MaxLength(40)]

    public string UserName { get; set; }

    [EmailAddress]
    [Required]
    [MinLength(0)]
    public string Email { get; set; }
    [PasswordFormat(10 )]
    public string Password { get; set; }

    


}