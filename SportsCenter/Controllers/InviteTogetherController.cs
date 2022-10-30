using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult PostArticle()
        {
            return View();
        }

        public IActionResult AurtherArticle()
        {
            return View();
        }
    }
}
