using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverPath { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] 
        public Category Category { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<ProductGallery> ProductGalleries { get; set; }
    }
}