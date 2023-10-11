using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi_BusinessService.Model.ViewModels
{
    public class ResponseViewModel<T>
    {
        public int Status { get; set; }
        public T data { get; set; }
    }
}
