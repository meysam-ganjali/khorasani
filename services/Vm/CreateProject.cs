
using Microsoft.AspNetCore.Http;

namespace services.Vm
{
    public class CreateProject
    {
        public string CompanyName { get; set; } 
        public string CompanuPhone { get; set; }
        public string CompanyAddress { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}