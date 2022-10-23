using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Templating.Core;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models.DavidModel;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Service;
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
        public async Task<bool> Signin([FromBody] SigninModel signin)
        {
            Random random = new Random();//亂數
            if (ModelState.IsValid)
            {
                Mail mail = new Mail();
                signin.Member_Salt = random.Next(0, 100).ToString();
                signin.Member_Password = hashingPassword.HashPassword($"{signin.Member_Password}{signin.Member_Salt}");                //Hash
                                                                                                                                       //等待連結資料庫
                _context.Member.Add(new Member
                {
                    Name = signin.Member_Name,
                    Account = signin.Member_Account,
                    Password = signin.Member_Password,
                    Salt = signin.Member_Salt,
                    Phone = signin.Member_Phone,
                    Email = signin.Member_Email,
                    Address = signin.Member_Address,
                    CreateTime = DateTime.Now
                });
                HttpContext.Response.Cookies.Append("UserEmail", signin.Member_Email);
                var msg = await RazorTemplateEngine.RenderAsync<SigninModel>("Views/Register/Authorize.cshtml", signin);
                mail.SendMail(signin.Member_Email, msg, "開約GO 會員認證信件");
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 會員驗證信
        public IActionResult GetAuthorize()
        {
            return View("Authorize");
        }
        #endregion
        #region 驗證連結
        public IActionResult Authorize()
        {
            string cookie = Request.Cookies["UserEmail"];
            Member? member = (from a in _context.Member
                              where a.Email == cookie
                              select a).FirstOrDefault();
            member.Role = 1;
            string msg = "驗證完成";
            _context.Entry(member).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(msg);
        }
        #endregion

        #region 忘記密碼輸入信箱畫面

        public IActionResult ForgetPassword()
        {
            return View();
        }
        #endregion
        #region 忘記密碼輸入密碼畫面
        public IActionResult ResetPassword()
        {
            return View();
        }
        #endregion
        #region 忘記密碼信封
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
                              where a.Email == model.Member_Email
                              select a).FirstOrDefault();
            if (member == null)
            {
                return false;
            }
            HttpContext.Response.Cookies.Append("ID", member.Id.ToString());
            var msg = await RazorTemplateEngine.RenderAsync<Member>("Views/Register/MailToReset.cshtml", member);
            mail.SendMail(member.Email, msg, "開約GO 密碼重設信件");
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
                        where b.Id == int.Parse(userID)
                        select b).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                user.Password = model.Member_Password;
                _context.Update(user);
            }
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region 登出
        [HttpDelete]
        public void logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        #endregion

        #region 未登入畫面 待完成
        [HttpGet("NoLogin")]
        public string noLogin()
        {
            return "未登入";
        }
        #endregion
        #region 沒權限畫面 待完成
        [HttpGet("NoAccess")]
        public string NoAccess()
        {
            return "未登入";
        }
        #endregion





    }
}
