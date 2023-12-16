using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Models;
using services.Contracts;
using Core.Models;

namespace Endpoint.Controllers;

public class HomeController : Controller
{
    private readonly ISliderService _slider;
    private readonly ICompetitivedvantagesService _com;
    private readonly IProductService _product;
    public HomeController(ISliderService slider,ICompetitivedvantagesService com,IProductService product)
    {
        _slider = slider;
        _com = com;
        _product = product;
    }
    public IActionResult Index()
    {
        IndexViewModel model = new IndexViewModel();
        model.Sliders = _slider.getAll().Data;
        model.CompetitiveAdvantages = _com.getAll().Data;
        model.Products = _product.getAll(null).Data;
        return View(model);
    }


}
