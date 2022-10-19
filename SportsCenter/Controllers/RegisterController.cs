using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Razor.Templating.Core;
using SportsCenter.Models.DavidModel;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Service;
using SportsCenter.Models.Table;
using System.Security.Claims;

namespace SportsCenter.Controllers
{
    public class RegisterController : Controller
    {
        #region 建構涵式
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;

        public RegisterController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        #endregion

        #region 主頁面
        public IActionResult Signin()
        {
            return View();
        }
        #endregion

        #region 註冊api
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Bind("Member_CreateTime,Member_Name,Member_Account,Member_Password,Member_Address,Member_Phone,Member_Email")]
        public bool Signin([FromBody] SigninModel signin)
        {
            Random random = new Random();//亂數
            if (ModelState.IsValid)
            {

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
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region 會員驗證 待完成
        //public IActionResult GetAuthorize()
        //{
        //    return View("Authorize");
        //}
        //[HttpPut]
        //public IActionResult Authorize()
        //{
        //    string cookie = Request.Cookies["EmailID"];
        //    Member? member = (from a in _context.Member
        //                      where a.Member_Email == cookie
        //                      select a).FirstOrDefault();
        //    member.Member_Role = 1;
        //    _context.Entry(member).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return Ok(cookie);
        //}
        #endregion

        #region 修改密碼畫面

        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult MailToReset()
        {
            return View();
        }

        #endregion

        #region 改密碼驗證信api
        public async Task<bool> Reset([FromBody] SendMailModel model)
        {
            Mail mail = new Mail();
            if (string.IsNullOrEmpty(model.Member_Email))
            {
                return false;
            }
            Member? member = (from a in _context.Member
                              where a.Member_Email == model.Member_Email
                              select a).FirstOrDefault();
            if (member == null)
            {
                return false;
            }
            HttpContext.Response.Cookies.Append("ID", member.MemberId.ToString());
            var msg = await RazorTemplateEngine.RenderAsync<Member>("Views/Register/MailToReset.cshtml", member);
            mail.SendMail(member.Member_Email, msg, "密碼重設信件");
            return true;
        }
        #endregion

        #region 修改密碼api
        [HttpPost]
        public bool ApiResetPassword([FromBody] ResetPassword model)
        {
            var userID = HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == "ID").Value;
            if (userID == null)
            {
                return false;
            }
            var user = (from b in _context.Member
                        where b.MemberId == int.Parse(userID)
                        select b).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                user.Member_Password = model.Member_Password;
                _context.Update(user);
            }
            _context.SaveChanges();
            return true;
        }
        #endregion
    }
}
