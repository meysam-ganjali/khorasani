

using Microsoft.AspNetCore.Http;

namespace services.Vm
{
    public class CreateSetting
    {
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string Address { get; set; }
        public IFormFile? LogoPath { get; set; }
        public string Slogan { get; set; }
        public string Description { get; set; }
    }
}