using Microsoft.AspNetCore.Mvc;
using SportsCenter.Models.Hashing;

namespace SportsCenter.Controllers
{
    public class RegisterController : Controller
    {
        HashingPassword hashingPassword = new HashingPassword();
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
                member.MemberSalt = salt;
                var password = hashingPassword.HashPassword($"{member.MemberPassword}{member.MemberSalt}");
                member.MemberPassword = password;



                //等待連結資料庫
                //_mVCProjectContext.Add(member);
                //await _mVCProjectContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
