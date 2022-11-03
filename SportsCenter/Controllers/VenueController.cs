using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Controllers
{
    /// <summary>
    /// 場地介紹
    /// </summary>
    public class VenueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
