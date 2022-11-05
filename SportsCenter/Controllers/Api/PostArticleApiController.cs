using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models;
using SportsCenter.Services;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace SportsCenter.Controllers.Api
{
    [Route("api/PostArticle/{action}")]
    [ApiController]
    public class PostArticleApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        private readonly UploadService _uploadService;

        public PostArticleApiController(SportsCenterDbContext dbContext, UploadService uploadService)
        {
            this.dbContext = dbContext;
            _uploadService = uploadService;
        }

        [HttpPost]
        public async Task<bool> Post([FromForm] PostArticleCreateModel post)
        {


            var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            var posts = new Post
            {
                Member_Id = userid,
                Title = post.Title,
                IsActive = true,
                Content = post.Content,
                CreatedDate = DateTime.Now,
                InviteCategory_Id = post.CategoryId
            };

            var imagePath = "";
            var isSuccess = false;
            if (post.Files is { Length: > 0 })
            {
                (isSuccess, imagePath) = await _uploadService.Upload(post.Files, "Post");
            }

            if (isSuccess)
            {
                posts.ImagePath = imagePath;
            }

            dbContext.Posts.Add(posts);

            await dbContext.SaveChangesAsync();

            return true;
        }

        [HttpGet]
        public object GetAll()
        {
            return dbContext.Posts.Select(x => new PostMessageViewModel
            {
                Id = x.Id,
                InviteCategory_Id = x.InviteCategory_Id,
                Member_Id = x.Member.Name,
                Title = x.Title,
                MemberImagePath = $"/system/{x.Member.ImagePath}",
                Content = x.Content,
                CreatedDate = x.CreatedDate.ToString("yyyy/M/dd-HH:mm:ss"),
                ImagePath = $"/system/{x.ImagePath}",
            }).ToList();
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetDetail(int id)
        {
            var data = dbContext.Posts.Where(x => x.Id == id).Select(x => new PostMessageViewModel
            {
                Id = x.Id,
                InviteCategory_Id = x.InviteCategory_Id,
                Member_Id = x.Member.Name,
                MemberImagePath = $"/system/{x.Member.ImagePath}",
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate.ToString("yyyy/M/dd-HH:mm:ss"),
                ImagePath = $"/system/{x.ImagePath}",
                Message = x.Message.OrderBy(y => y.CreateDate).Select(y => new MessagesLoadingViewModel
                {
                    Id = y.Id,
                    Member_Id = y.Member_Id,
                    MemberImagePath = $"/system/{y.Member.ImagePath}",
                    MemberName = y.Member.Name,
                    Body = y.Body,
                    Post_Id = y.Post_Id,
                    CreateDate = y.CreateDate.ToString("yyyy/M/dd-HH:mm:ss"),
                }).ToList(),
                //載入留言
            }).FirstOrDefault();

            return Ok(data);
        }

        [HttpGet]
        public object GetInviteCategoryid()
        {
            return dbContext.InviteCategory.Select(x => new GetInviteCategoryModel
            {
                IsActive = true,
                Name = x.Name,
                CategoryId = x.Id,
            }).ToList();
        }

    }


}