
using Core.Models;

namespace Endpoint.Models
{
    public class IndexViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<CompetitiveAdvantage> CompetitiveAdvantages { get; set; }
        public List<Product> Products { get; set; }
    }
}