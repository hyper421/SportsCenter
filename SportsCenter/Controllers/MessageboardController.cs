using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Controllers
{
    public class MessageboardController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult FawenYanzheng()
        {
            return View();
        }

        public IActionResult AurtherArticle()
        {
            return View();
        }
    }
}
