
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using services.Contracts;

namespace Endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(SD.AdminManager)]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UsersController(IUserService userService,IRoleService roleService)
        {
            _userService = userService;
            _roleService=roleService;
        }
        public IActionResult Index()
        {
            var user = _userService.getAllUser();
            var roles = _roleService.getAllRole();
            ViewBag.roles= new SelectList(roles.Data,"Id","RoleName");
            return View(user.Data);
        }
        [HttpPost]
        public IActionResult CreateUser(User user){
            user.CreatedDate = DateTime.Now.ToShortDateString();
            var result = _userService.createUser(user);
            return Redirect("/Admin/Users/Index");
        }
        public IActionResult DeleteUser(int id){
            var result = _userService.deleteUser(id);
            return Redirect("/Admin/Users/Index");
        }
    }
}