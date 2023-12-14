
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using services.Contracts;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.getAllParent();
            return View(categories.Data);
        }
         public IActionResult ChildIndex(int id)
        {
            var categories = _categoryService.getAllChildByParent(id);
            return View(categories.Data);
        }

  
        public IActionResult DeleteChild(int id){
            var res = _categoryService.deleteChild(id);
            return Redirect("/Admin/Category/Index");
        }
        [HttpPost]
        public IActionResult CreateChild(Category category){
            var res = _categoryService.createChild(category);
            return Redirect("/Admin/Category/Index");
        }

        [HttpPost]
        public IActionResult CreateParent(ParentCategory category){
            var res = _categoryService.createParent(category);
            return Redirect("/Admin/Category/Index");
        }

         public IActionResult DeleteParent(int id){
            var res = _categoryService.deleteParent(id);
            return Redirect("/Admin/Category/Index");
        }
    }
}