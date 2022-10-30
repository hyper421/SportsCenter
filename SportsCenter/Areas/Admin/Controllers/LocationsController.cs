using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.LocationsId = id;
            return View();
        }
    }
}
