using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.DavidModel;
using SportsCenter.Models.Hashing;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using SportsCenter.DataAccess;

namespace SportsCenter.Controllers.Members
{
    public class MemberEditController : Controller
    {
        #region 建構涵式
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;
        public MemberEditController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        #endregion
        #region 會員修改主畫面
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}

