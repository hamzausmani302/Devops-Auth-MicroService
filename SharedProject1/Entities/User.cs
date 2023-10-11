using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TDL_USER")]
public class User : IdentityUser
{
    [Column("username")]
    public string Name { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }
    [Column("contact_number")]
    public string? Phone { get; set; }

}