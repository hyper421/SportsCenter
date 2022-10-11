using Microsoft.AspNetCore.Mvc;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Table;

namespace SportsCenter.Controllers
{
    public class RegisterController : Controller
    {
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;
        public RegisterController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signin([Bind("MemberName,MemberAccount,MemberPassword,MemberAddress,MemberCellphone,MemberEmail")] Member member)
        {
            if (ModelState.IsValid)
            {
                //Hash
                var salt = DateTime.Now.ToString();
                member.Member_Salt = salt;
                var password = hashingPassword.HashPassword($"{member.Member_Password}{member.Member_Salt}");
                member.Member_Password = password;



                //等待連結資料庫
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
