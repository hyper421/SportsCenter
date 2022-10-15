using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Hashing;
using SportsCenter.Models.Table;

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
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return _context.Member.Find(id);
        }
    }
}
