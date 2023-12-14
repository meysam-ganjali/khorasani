using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Models;
using services.Contracts;
using Core.Models;

namespace Endpoint.Controllers;

public class HomeController : Controller
{
   
    public IActionResult Index()
    {
        return View();
    }


}
