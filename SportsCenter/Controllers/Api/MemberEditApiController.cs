using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.DavidModel;
using SportsCenter.Models.Hashing;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Services;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.Models;

namespace SportsCenter.Controllers.Api
{
    [Route("api/MemberEdit/{action}")]
    [ApiController]
    public class MemberEditApiController : ControllerBase
    {
        #region 建構涵式
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext _context;
        private readonly UploadService uploadService;

        public MemberEditApiController(SportsCenterDbContext SportsCenterDbContext,UploadService uploadService)
        {
            this._context = SportsCenterDbContext;
            this.uploadService = uploadService;
        }
        #endregion
        #region 取會員資料
        [HttpGet]
        public IEnumerable<Member> GetMember()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var user = (from a in _context.Member where a.Id == int.Parse(id) select a);
            return user;
        }
        #endregion
        #region 回傳會員資料
        [HttpPost]
        public bool ResetMember([FromBody] MemberEditModel model)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
            {
                return false;
            }
            var user = (from b in _context.Member
                      where b.Id == int.Parse(userId)
                        select b).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                user.Account = model.Member_Account;
                user.Name = model.Member_Name;
                user.Phone = model.Member_Phone;
                user.Email = model.Member_Email;
                user.Address = model.Member_Address;
                _context.Update(user);
            }
            _context.SaveChanges();
            return true;
        }
        #endregion
        [HttpPost]
        public async Task<bool> Update([FromForm]MemberImages model)
        {
            try
            {
                var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
                var needUpdate = model.Image != null;
                var path = "";
                var data = _context.Member.FirstOrDefault(x => x.Id == int.Parse(id));
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Category");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }
                if (needUpdate) data.ImagePath = path;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet]
        public object Detail()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            return _context.ProductsOrderDetail;
        }
        [HttpGet]
        public object getpath()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var data = _context.Member.First(x => x.Id == int.Parse(id));
            return new { 
                path = data.ImagePath,
                data.Name,
            };
        }
        [HttpGet]
        public object GetAll()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;


            var data = (from a in _context.LocationOrder
                        join b in _context.LocationBranch
                       on a.LocationBranchId equals b.Id
                        select new { a.Id, a.MemberId, b.LocationId, a.LocationBranchId, b.CategoryId, a.Price, a.Time });

            return data.Select(x => new
            {
                x.Id,
                user = _context.Member.Where(a => a.Id == x.MemberId).Select(b => b.Name).FirstOrDefault(),
                locationName = _context.Location.Where(a => a.Id == x.LocationId).Select(b => b.Name).FirstOrDefault(),
                brunchName = _context.LocationBranch.Where(a => a.Id == x.LocationBranchId).Select(b => b.Name).FirstOrDefault(),
                category = _context.Category.Where(a => a.Id == x.CategoryId).Select(b => b.Name).FirstOrDefault(),
                x.Price,
                x.Time
            });
        }
    }
}
