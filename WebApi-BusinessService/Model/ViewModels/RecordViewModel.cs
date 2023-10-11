using System.ComponentModel.DataAnnotations.Schema;
using WebApi_BusinessService.Entities;

namespace WebApi_BusinessService.Model.ViewModels
{
    public class RecordViewModel
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public string? Title { get; set; }
        public AppUser? User { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? Created_Date { get; set; }
    }
}
