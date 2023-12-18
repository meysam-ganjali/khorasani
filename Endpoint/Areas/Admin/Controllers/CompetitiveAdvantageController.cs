
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services.Contracts;
using services.Vm;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(SD.AdminManager)]
    public class CompetitiveAdvantageController : Controller
    {
        private readonly ICompetitivedvantagesService _competitiv;
        public CompetitiveAdvantageController(ICompetitivedvantagesService competitiv)
        {
            _competitiv=competitiv;
        }
        public IActionResult Index()
        {
            return View(_competitiv.getAll().Data);
        }
        [HttpPost]
        public IActionResult Create(CreateCompetitiveAdvantage p){
            var res = _competitiv.create(p);
            return Redirect("/Admin/CompetitiveAdvantage/Index");
        }
        public IActionResult Delete(int id){
            var res = _competitiv.delete(id);
            return Redirect("/Admin/CompetitiveAdvantage/Index");
        }
    }
}