using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly SportsCenterDbContext _db;

        public CategoryController(SportsCenterDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
