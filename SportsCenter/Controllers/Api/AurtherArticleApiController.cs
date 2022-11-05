using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models;

namespace SportsCenter.Controllers.Api
{
    [Route("api/AurtherArticle/{action}")]
    [ApiController]
    public class AurtherArticleApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        public AurtherArticleApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<MessageViewModel> GetAll(int id)
        {
            var messages = dbContext.Posts.Where(x => x.Id == id).Include(x => x.Message);
            var p = messages.Select(x => new MessageViewModel
            {
                Id = x.Id,
            }).ToList();

            return p;

        }
        [HttpPost]
        public bool PostMessage([FromBody] MessageViewModel message)
        {

            var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            dbContext.Message.Add(new DataAccess.Entity.Message
            {

                Member_Id = userid,
                Post_Id = message.PostId,
                Body = message.Body,
                CreateDate = DateTime.Now,

            });
            dbContext.SaveChanges();

            return true;
        }

    }




}
