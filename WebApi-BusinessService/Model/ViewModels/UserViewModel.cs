using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi_BusinessService.Entities;

namespace WebApi_BusinessService.Model.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; } = DateTime.MinValue;

    }
}
