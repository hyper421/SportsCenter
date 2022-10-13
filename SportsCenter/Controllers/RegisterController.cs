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
        public async Task<IActionResult> Signin([Bind("Member_CreateTime,Member_Name,Member_Account,Member_Password,Member_Address,Member_Phone,Member_Email")] Member member)
        {
            if (ModelState.IsValid)
            {
                member.Member_CreateTime = DateTime.Now.ToString();
                var salt = member.Member_Password.Substring(0, 2);
                //Hash
                member.Member_Password = hashingPassword.HashPassword($"{member.Member_Password}{salt}");
                //等待連結資料庫
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
