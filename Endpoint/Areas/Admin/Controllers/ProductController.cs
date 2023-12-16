
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using services.Contracts;
using services.Vm;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorySerice;
        public ProductController(IProductService productService, ICategoryService categorySerice)
        {
            _productService = productService;
            _categorySerice = categorySerice;
        }
        public IActionResult Index()
        {
            var products = _productService.getAll(null);
            return View(products.Data);
        }

        public IActionResult CreateProduct()
        {
            var category = _categorySerice.getAllChild();
            ViewBag.category = new SelectList(category.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProduct product, List<CreateAttribute> CreateAttribute)
        {
            var res = _productService.createProduct(product, CreateAttribute);
            if (res.IsSuccess)
                return Redirect("/Admin/Product/Index");
                
            return View();
        }

        [HttpPost]
        public IActionResult CreateGallery(int productId, List<IFormFile> images){
           var res = _productService.createGallery(productId,images);
            return Redirect("/Admin/Product/Index");
        }
    }
}