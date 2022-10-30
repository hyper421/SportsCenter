using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly SportsCenterDbContext context;

        public ItemController(SportsCenterDbContext context)
        {
            context = context;
        }
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
