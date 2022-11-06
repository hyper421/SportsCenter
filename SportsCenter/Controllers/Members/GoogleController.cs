using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using System;
using System.Net;
using System.Security.Claims;

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
            Random random = new Random();
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var name = result.Principal.Claims.Where(x => x.Type.Contains("name")).Select(a => a.Subject.Name).FirstOrDefault();
            var email = result.Principal.Claims.Where(x => x.Type.Contains("emailaddress")).Select(a => a.Value).FirstOrDefault();
            var role = result.Principal.Claims.Where(x => x.Type.Contains("role")).Select(a => a.Value).FirstOrDefault();
            var password = result.Principal.Claims.Where(x => x.Type.Contains("nameidentifier")).Select(a => a.Value).FirstOrDefault();
            var users = (from a in _context.Member
                         where a.Account == email
                         select a).FirstOrDefault();
            if (users != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, users.Name),
                new Claim(ClaimTypes.Sid, users.Id.ToString()),
                new Claim(ClaimTypes.Email, users.Email),
                new Claim(ClaimTypes.StreetAddress, users.Address),
                new Claim(ClaimTypes.HomePhone, users.Phone),
                new Claim(ClaimTypes.Role, users.Role.ToString()),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var clainPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, clainPrincipal);
            }
            else
            {
                _context.Member.Add(new Member
                {
                    Name = name,
                    Account = email,
                    Password = password,
                    Salt = random.Next(0, 100).ToString(),
                    Email = email,
                    CreateTime = DateTime.Now,
                    IsActive = 1,
                    Address = "",
                    Role = int.Parse(role),
                    ImagePath = "/Logo//logo.jpg",
                    Phone = ""

                });
                _context.SaveChanges();
            }
            return RedirectToAction("index", "home");
        }
    }
}
