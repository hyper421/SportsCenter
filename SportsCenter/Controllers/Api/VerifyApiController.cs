using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Table;
using System.Security.Claims;
using SportsCenter.Models.DavidModel;
using System.Diagnostics.Metrics;

namespace SportsCenter.Controllers.Api
{
    //[Route("api/Product")]
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
        [Route("api/Login")]
        public bool Login([FromBody] LoginModel model)
        {
            if (model.Member_Account == null || model.Member_Password == null) { return false; }
            HashingPassword hashingPassword = new HashingPassword();
            var salt = (from a in _context.Member
                        where a.Member_Account == model.Member_Account
                        select a.Member_Salt).FirstOrDefault();
            model.Member_Password = hashingPassword.HashPassword($"{model.Member_Password}{salt}");

            var user = _context.Member.FirstOrDefault(x => x.Member_Account == model.Member_Account && x.Member_Password == model.Member_Password);

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
