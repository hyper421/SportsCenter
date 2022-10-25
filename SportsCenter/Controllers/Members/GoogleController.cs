using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Controllers.Members
{
    public class GoogleController : Controller
    {
        private readonly SportsCenterDbContext _context;
        public GoogleController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        public IActionResult LoginGoogle()
        {
            var properties = new AuthenticationProperties()
            {
                RedirectUri = Url.Action("LoginResult")
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> LoginResult()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var json = result.Principal.Claims.Select(x => new
            {
                x.Value,
                x.Type,
                x.Issuer,
                x.OriginalIssuer
            });
            return Json(json);
        }
    }
}
