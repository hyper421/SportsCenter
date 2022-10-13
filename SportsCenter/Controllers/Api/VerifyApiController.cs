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
    [Route("api/[controller]")]
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
        [HttpPost]
        public async Task<bool> Login(Member member)
        {
            HashingPassword hashingPassword = new HashingPassword();
            if (member.Member_Account == null || member.Member_Password == null) { return false;}
            member.Member_Password = hashingPassword.HashPassword($"{member.Member_Password}{member.Member_Password.Substring(0, 2)}");

            var user = _context.Member.FirstOrDefault(x => x.Member_Account == member.Member_Account && x.Member_Password == member.Member_Password);

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

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, clainPrincipal);

            }
            return true;
        }
    }
}
