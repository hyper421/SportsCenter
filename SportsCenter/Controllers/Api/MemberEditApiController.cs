using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.DavidModel;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Table;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace SportsCenter.Controllers.Api
{
    [Route("api/MemberEdit")]
    [ApiController]
    public class MemberEditApiController : ControllerBase
    {
        #region 建構涵式
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;
        public MemberEditApiController(SportsCenterDbContext SportsCenterDbContext)
        {
            this._context = SportsCenterDbContext;
        }
        #endregion
        #region 取會員資料
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var user = (from a in _context.Member where a.MemberId == int.Parse(id) select a).ToList();
            return user;
        }
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return _context.Member.Find(id);
        }
        #endregion


        #region 回傳會員資料
        [HttpPost]
        public bool Post([FromBody] MemberEditModel model)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
            {
                return false;
            }
            var user = (from b in _context.Member
                      where b.MemberId == int.Parse(userId)
                        select b).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                user.Member_Account = model.Member_Account;
                user.Member_Name = model.Member_Name;
                user.Member_Phone = model.Member_Phone;
                user.Member_Email = model.Member_Email;
                user.Member_Address = model.Member_Address;
                _context.Update(user);
            }
            _context.SaveChanges();
            return true;
        }
        #endregion
    }
}
