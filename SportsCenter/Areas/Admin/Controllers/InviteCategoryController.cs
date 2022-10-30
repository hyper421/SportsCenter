using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InviteCategoryController : Controller
    {
        private readonly SportsCenterDbContext _db;

        public InviteCategoryController(SportsCenterDbContext db)
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
        public IActionResult Edit(int id)
        {
            ViewBag.InviteCategoryId = id;
            return View();
        }
    }
}
