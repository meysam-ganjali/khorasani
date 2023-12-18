
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services.Contracts;
using services.Vm;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(SD.AdminManager)]
    public class SettingController : Controller
    {
        private readonly ISettingService _setting;
        public SettingController(ISettingService setting)
        {
            _setting = setting;
        }
        public IActionResult Index()
        {
            var res = _setting.getSetting();
            return View(res.Data);
        }

        [HttpPost]
        public IActionResult Create(CreateSetting p){
            var img = HttpContext.Request.Form.Files.FirstOrDefault();
            p.LogoPath = img;
            var res = _setting.createSetting(p);
            return Redirect("/Admin/Setting/Index");
        }
        public IActionResult Remove(int id){
            var res = _setting.deleteSetting(id);
             return Redirect("/Admin/Setting/Index");
        }
    }
}