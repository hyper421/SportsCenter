using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Table;
using System.Security.Claims;

namespace SportsCenter.Controllers.Api
{
    [ApiController]
    public class VerifyApiController : ControllerBase
    {
        #region 建構涵式
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;
        public VerifyApiController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        #endregion
        [Route("api/Login")]
        [HttpPost]
        public bool Login(string Account, string Password )
        {
            if (Account == null || Password == null) { return false; }
            HashingPassword hashingPassword = new HashingPassword();

            Password = hashingPassword.HashPassword($"{Password}{Password.Substring(0, 2)}");

            var user = _context.Member.FirstOrDefault(x => x.Member_Account == Account && x.Member_Password == Password);

            if (user == null)
            {
                return false;
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

            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var clainPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, clainPrincipal);

            }
            return true;
        }
    }
}
