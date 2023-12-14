
using Core.Models;
using Microsoft.AspNetCore.Http;

namespace services.Vm
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public IFormFile CoverPath { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }
    }
}