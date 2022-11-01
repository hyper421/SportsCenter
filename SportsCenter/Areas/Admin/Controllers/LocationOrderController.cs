using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Areas.Admin.Controllers
{
    public class LocationOrderController : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            ViewBag.ProductsOrderId = id;
            return View();
        }
    }
}
