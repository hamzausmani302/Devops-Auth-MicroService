using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_BusinessService.Entities
{
    public class AppMonthAttachment
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double Size { get; set; }
        [ForeignKey("Record_Id")]
        public AppMonthRecords Record { get; set; }
        public Guid Record_Id { get; set; }
    }
}
