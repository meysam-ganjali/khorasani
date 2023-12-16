
using Microsoft.AspNetCore.Http;

namespace services.Vm
{
    public class CreateCompetitiveAdvantage
    {
        public string Name { get; set; }
        public IFormFile LogoPath { get; set; }
    }
}