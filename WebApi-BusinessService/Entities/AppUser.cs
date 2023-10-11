using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_BusinessService.Entities
{
    [Table("App_User")]
    public class AppUser
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Name")]
        [Required]
        public string Name { get; set; }

        public DateTime DOB { get; set; } = DateTime.MinValue;

        public List<AppMonthRecords> MonthRecords { get; set; }
        
    }
}
