
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models.Dto;
using System.Security.Claims;
using System.Xml.Linq;



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


        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return dbContext.Category;
        }

        // POST api/<PostArticle>
        [HttpPost]
        public bool Post([FromBody] PostArticleCreateModel post)
        {
            //var ID = (from a in dbContext.InviteCategory
            //          where a.Name == post.Type
            //          select a.Id).FirstOrDefault();
            //var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            dbContext.Posts.Add(new DataAccess.Entity.Post
            {
                InviteCategory_Id = /*ID*/1,
                Member_Id = /*userid*/2,
                Title = post.Title,
                Content = post.Content,
                CreatedDate = DateTime.Now,
                ImagePath = "https://images-ext-1.discordapp.net/external/J49keTE-_qetwWIKr4YJ9AkFmNJYuE7JK3AQB4wuNHk/%3Fauto%3Dcompress%26cs%3Dtinysrgb%26w%3D1600/https/images.pexels.com/photos/1828525/pexels-photo-1828525.jpeg?width=396&height=594",
            });
            return true;
        }

        [HttpGet]
        public object GetAll()
        {
            return dbContext.Posts.Select(x => new {
                x.InviteCategory_Id,
                x.Member_Id,
                x.Title,
                x.Content,
                x.CreatedDate,
                x.ImagePath,

            }).ToList();
        }


        //[HttpPost]
        //public bool Create([FromBody] PostArticleCreateModel model)
        //{
        //    try
        //    {
        //        dbContext.Posts.Add(new DataAccess.Entity.Post { 
        //            //Id = model.Id, 
        //            Title = model.Title,
        //            Content = model.Content,
        //            //Member_Id = model.Member_Id,
        //            InviteCategory_Id = model.InviteCategory_Id,
        //            ImagePath = model.ImagePath,
        //            CreatedDate = DateTime.Now,

        //        });

        //        dbContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}


        //try
        //{
        //    dbContext.Posts.Add(new DataAccess.Entity.Post
        //    {
        //        //IsActive = model.IsActive ? 1 : 0,
        //        Id = model.Id,
        //    });
        //    var i = new PostArticleCreateModel
        //    {
        //    //InviteCategory_Id = model.InviteCategory_Id,
        //    Title = model.Title,
        //    ImagePath = model.ImagePath,
        //    Content = model.Content,
        //    //Member_Id = model.Member_Id,

        //};
        //model.CreatedDate = DateTime.Now;
        //dbContext.Posts.Add(i);
        //dbContext.SaveChanges();
        //return true;
        //}
        //catch (Exception)
        //{
        //    return false;
        //}
    }










    //// GET api/<PostArticle>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<PostArticle>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<PostArticle>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<PostArticle>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}

}