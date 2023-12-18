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
    private readonly ISettingService _setting;
    private readonly ICompletedProject _project;
    public HomeController(ISliderService slider, ICompetitivedvantagesService com, IProductService product, ISettingService setting, ICompletedProject project)
    {
        _slider = slider;
        _com = com;
        _product = product;
        _setting = setting;
        _project = project;
    }
    public IActionResult Index()
    {
        IndexViewModel model = new IndexViewModel();
        model.Sliders = _slider.getAll().Data;
        model.CompetitiveAdvantages = _com.getAll().Data;
        model.Products = _product.getAll(null).Data;
        model.Setting = _setting.getSetting().Data;
        model.Companies = _project.getAll().Data;
        return View(model);
    }

    public IActionResult ProjectDetaile(int id){
        var res = _project.getProject(id);
        return View(res.Data);
    }

}
