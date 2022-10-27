using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Controllers
{
    /// <summary>
    /// 帳號相關
    /// </summary>
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
