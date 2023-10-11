using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_BusinessService.Entities
{
    public class AppMonthRecords
    {
        public Guid Id { get; set; }
        public DateTime Created_Date { get; set; }
        public string? Message { get; set; }
        public string? Title { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public Guid UserId { get; set; }

        public List<AppMonthAttachment> Attachments { get; set; }
        
        
    }
}
