using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Models;

namespace SportsCenter.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Basketball()
    {
        return View();
    }

    public IActionResult Badminton()
    {
        return View();
    }

    public IActionResult TablaTennis()
    {
        return View();
    }

    public IActionResult Pool()
    {
        return View();
    }

    public IActionResult Squash()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}