using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly SportsCenterDbContext _db;

        public ItemController(SportsCenterDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateItem()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
