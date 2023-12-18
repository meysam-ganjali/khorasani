
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services.Contracts;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(SD.AdminManager)]
    public class SliderController : Controller
    {
       private readonly ISliderService _sliderService;
       public SliderController(ISliderService sliderService)
       {
        _sliderService = sliderService;
       }
        public IActionResult Index()
        {
            var res = _sliderService.getAll();
            return View(res.Data);
        }
        [HttpPost]
        public IActionResult CreateSlider(IFormFile image){
            var res = _sliderService.createSlider(image);
            return Redirect("/Admin/Slider/Index");
        }
        public IActionResult DeleteSlider(int id){
            var res = _sliderService.deleteSlider(id);
            return Redirect("/Admin/Slider/Index");
        }
    }
}