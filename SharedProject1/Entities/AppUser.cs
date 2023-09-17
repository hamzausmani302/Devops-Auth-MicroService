using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devops_Auth_MicroService.Models
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        [Column("AppUser_ID")]
        public int UserId { get; set; }
        [Column("AppUser_Name")]
        public string? Name { get; set; }
        [Column("AppUser_Email")]
        public string? Email { get; set; }
        [Column("AppUser_Password")]
        public string? Password { get; set; }
    }
}
