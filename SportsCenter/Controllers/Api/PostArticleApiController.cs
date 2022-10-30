
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SportsCenter.DataAccess;
//using SportsCenter.DataAccess.Entity;
//using SportsCenter.Models;
//using System.Security.Claims;
//using System.Xml.Linq;



//namespace SportsCenter.Controllers.Api
//{
//    [Route("/api/PostArticle/{action}")]
//    [ApiController]
//    public class PostArticleApiController : ControllerBase
//    {
//        private readonly SportsCenterDbContext dbContext;
//        public PostArticleApiController(SportsCenterDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }


//        [HttpGet]
//        public IEnumerable<Category> Get()
//        {
//            return dbContext.Category;
//        }

//        // POST api/<PostArticle>
//        [HttpPost]
//        public bool Post([FromBody] PostArticleCreateModel post)
//        {
//            var ID = (from a in dbContext.InviteCategory
//                      where a.Name == post.Type
//                      select a.Id).FirstOrDefault();
//            var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

//            dbContext.Posts.Add(new DataAccess.Entity.Post
//            {
//                InviteCategory_Id = 1,
//                Member_Id = 2,
//                Title = post.Title,
//                Content = post.Content,
//                CreatedDate = DateTime.Now,
//                IsActive = true,
//                ImagePath = "https://images-ext-1.discordapp.net/external/J49keTE-_qetwWIKr4YJ9AkFmNJYuE7JK3AQB4wuNHk/%3Fauto%3Dcompress%26cs%3Dtinysrgb%26w%3D1600/https/images.pexels.com/photos/1828525/pexels-photo-1828525.jpeg?width=396&height=594",
//            });
//            dbContext.SaveChanges();
//            return true;
//        }

//        [HttpGet]
//        public object GetAll()
//        {
//            return dbContext.Posts.Select(x => new {
//                x.InviteCategory_Id,
//                x.Member_Id,
//                x.Title,
//                x.Content,
//                x.CreatedDate,
//                x.ImagePath,

//            }).ToList();
//        }


//    }

//}


using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models;
using System.Security.Claims;

namespace SportsCenter.Controllers.Api
{
    [Route("/api/PostArticle/{action}")]
    [ApiController]
    public class PostArticleApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        public PostArticleApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public bool Post([FromBody] PostArticleCreateModel post)
        {
            //var ID = (from a in dbContext.InviteCategory
            //          where a.Name == post.Type
            //          select a.Id).FirstOrDefault();

            //var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            dbContext.Posts.Add(new DataAccess.Entity.Post
            {
                InviteCategory_Id = 1,
                Member_Id = 9527,
                Title = post.Title,
                Content = post.Content,
                CreatedDate = DateTime.Now,
                ImagePath = "https://images.pexels.com/photos/1828525/pexels-photo-1828525.jpeg?auto=compress&cs=tinysrgb&w=1600",
            });
            dbContext.SaveChanges();
            return true;
        }

        [HttpGet]
        public object GetAll()
        {
            return dbContext.Posts.Select(x => new
            {
                x.InviteCategory_Id,
                x.Member_Id,
                x.Title,
                x.Content,
                x.CreatedDate,
                x.ImagePath,

            }).ToList();
        }
    }
}