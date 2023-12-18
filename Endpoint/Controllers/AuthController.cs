using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using services.Contracts;
using System.Security.Claims;
namespace Endpoint.Controllers
{

    public class AuthController : Controller
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Login(string userName, string pass){
            var res = _auth.Login(userName,pass);
            if(res != null){
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,res.Id.ToString()),
                    new Claim(ClaimTypes.Name, res.FullName),
                    new Claim(ClaimTypes.Role, res.RoleName),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties() {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.Now.AddDays(7.0),
                };


                HttpContext.SignInAsync(principal, properties);
                return Redirect("~/");
            }
            return Redirect("/Auth/Login");
        }
    }
}