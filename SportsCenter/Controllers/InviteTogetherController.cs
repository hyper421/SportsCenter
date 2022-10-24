using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Controllers
{
    /// <summary>
    /// 揪團
    /// </summary>
    public class InviteTogetherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
