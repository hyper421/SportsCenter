using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Controllers
{
    /// <summary>
    /// 場地預約
    /// </summary>
    public class VenueBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
