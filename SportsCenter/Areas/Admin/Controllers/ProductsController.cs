using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
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
            ViewBag.ProductsId = id;
            return View();
        }
    }
}
