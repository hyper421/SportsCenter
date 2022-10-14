using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportsCenter.Models.DavidModel;
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
        //[ValidateAntiForgeryToken]
        //[Bind("Member_CreateTime,Member_Name,Member_Account,Member_Password,Member_Address,Member_Phone,Member_Email")]
        public bool Signin([FromBody] SigninModel signin)
        {
            Random random = new Random();//亂數

            signin.Member_Salt = random.Next(0, 100).ToString();
            signin.Member_Password = hashingPassword.HashPassword($"{signin.Member_Password}{signin.Member_Salt}");                //Hash
                                                                                                                                   //等待連結資料庫
            _context.Member.Add(new Models.Table.Member
            {
                Member_Name = signin.Member_Name,
                Member_Account = signin.Member_Account,
                Member_Password = signin.Member_Password,
                Member_Salt = signin.Member_Salt,
                Member_Phone = signin.Member_Phone,
                Member_Email = signin.Member_Email,
                Member_Address = signin.Member_Address,
                Member_CreateTime = DateTime.Now.ToString()
            }); ;
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
