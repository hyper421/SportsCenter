using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateItem()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.ItemId = id;

            return View();
        }
    }
}
