using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
