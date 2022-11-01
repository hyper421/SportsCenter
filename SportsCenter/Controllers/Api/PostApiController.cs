using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.Services;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Post/{action}")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;
        private readonly UploadService uploadService;

        public PostApiController(SportsCenterDbContext context, UploadService uploadService)
        {
            this.context = context;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create([FromForm] CreatePostModel model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Post");
                if (result.Item1)
                {
                    context.Posts.Add(new DataAccess.Entity.Post
                    {
                        IsActive = model.IsActive,
                        Member_Id = (from a in context.Member
                                     where a.Name == model.Name
                                     select a.Id).FirstOrDefault(),
                        InviteCategory_Id = (from a in context.InviteCategory
                                             where a.Name == model.Type
                                             select a.Id).FirstOrDefault(),
                        ImagePath = result.Item2,
                        Title = model.Title,
                        Content = model.Content,
                        CreatedDate = DateTime.Now,
                    });
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<bool> Update([FromForm] UpdatePostModel model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = context.Posts.FirstOrDefault(x => x.Id == model.Id);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Post");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }
                data.IsActive = model.IsActive;
                data.Member_Id = (from a in context.Member
                                  where a.Name == model.Name
                                  select a.Id).FirstOrDefault();
                data.InviteCategory_Id = (from a in context.InviteCategory
                                          where a.Name == model.Type
                                          select a.Id).FirstOrDefault();
                data.Title = model.Title;
                data.Content = model.Content;
                data.CreatedDate = DateTime.Now;

                if (needUpdate) data.ImagePath = path;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public object GetAll()
        {
            return context.Posts.Select(x => new
            {
                x.Id,
                name = (from a in context.Member
                        where a.Id == x.Member_Id
                        select a.Name).FirstOrDefault(),
                x.IsActive,
                x.Title,
                path = x.ImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.Posts.First(x => x.Id == id);
            return new
            {
                data.Id,
                name = (from a in context.Member
                        where a.Id == data.Member_Id
                        select a.Name).FirstOrDefault(),
                type = (from a in context.InviteCategory
                        where a.Id == data.InviteCategory_Id
                        select a.Name).FirstOrDefault(),
                data.Title,
                data.Content,
                data.IsActive,
                path = data.ImagePath
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.Posts.Remove(new DataAccess.Entity.Post() { Id = id });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
