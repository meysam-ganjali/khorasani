
using Microsoft.AspNetCore.Mvc;
using services.Contracts;
using services.Vm;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly ICompletedProject _project;
        public ProjectController(ICompletedProject project)
        {
            _project = project;
        }
        public IActionResult Index()
        {
            var res = _project.getAll();
            return View(res.Data);
        }
        [HttpPost]
        public IActionResult Create(CreateProject p){
            var res = _project.createProject(p);
            return Redirect("/Admin/Project/Index");
        }

        public IActionResult Delete(int id){
            var res = _project.deleteProject(id);
            return Redirect("/Admin/Project/Index");
        }
    }
}