using Microsoft.AspNetCore.Mvc;
using services.Contracts;
namespace Endpoint.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _category;
        public CategoryViewComponent(ICategoryService category)
        {
            _category = category;
        }
        public  IViewComponentResult Invoke()
        {
            var res = _category.getAllParent();
            return View("Category",res.Data);
        }
    }

    public class DesktopCatViewComponent : ViewComponent
    {
        private readonly ICategoryService _category;
        public DesktopCatViewComponent(ICategoryService category)
        {
            _category = category;
        }
        public  IViewComponentResult Invoke()
        {
            var res = _category.getAllParent();
            return View("DesktopCat",res.Data);
        }
    }
}