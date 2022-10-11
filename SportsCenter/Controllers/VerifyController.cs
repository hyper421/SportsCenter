using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Table;
using System.Security.Claims;

namespace SportsCenter.Controllers
{
    public class VerifyController : Controller
    {
        #region 建構涵式
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;
        public VerifyController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Login(Member member)
        {
            member.Member_Password = hashingPassword.HashPassword($"{member.Member_Password}{member.Member_Password.Substring(0, 2)}");

            var user = _context.Member.FirstOrDefault(x => x.Member_Account == member.Member_Account && x.Member_Password == member.Member_Password);

            if (user == null)
            {
                ViewBag.errMsg = "帳號或密碼輸入錯誤";
            }
            else
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Member_Name),
                new Claim(ClaimTypes.Sid, user.MemberId.ToString()),
                new Claim(ClaimTypes.Email, user.Member_Email),
                new Claim(ClaimTypes.StreetAddress, user.Member_Address),
                new Claim(ClaimTypes.HomePhone, user.Member_Phone),
                new Claim(ClaimTypes.Role, "Users")

            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var clainPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, clainPrincipal);

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
