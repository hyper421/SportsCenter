using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.JenaModel;
using SportsCenter.Models.Table;

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


      




