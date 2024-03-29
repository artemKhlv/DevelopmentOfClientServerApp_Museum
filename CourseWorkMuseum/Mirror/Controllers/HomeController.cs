﻿
using Microsoft.AspNetCore.Mvc;


namespace Mirror.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;
    //
    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult WelcomePage()
    {
        return View();
    }

    public IActionResult MainPage()
    {
        return View();
    }

    public IActionResult ErrorPage()
    {
        return View();
    }

    public IActionResult Magic1()
    {
        return View();
    }
    
    public IActionResult Exhibitions()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult JakeWoodEvans()
    {
        return View();
    }
    
    public IActionResult GroupExhibition()
    {
        return View();
    }
    
    public IActionResult NicolasHoliber()
    {
        return View();
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    // }
}