using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using System.Security.Claims;

namespace SportsCenter.Controllers.Api
{
    [Route("api/BackGetAllCategory/{action}")]
    [ApiController]
    public class BackGetAllCategoryApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;

        public BackGetAllCategoryApiController(SportsCenterDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public object GetLocation()
        {
            return context.Location.Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList();
        }
        [HttpGet]
        public object GetInviteCategory()
        {
            return context.InviteCategory.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == true,
                x.Id,
            }).ToList();
        }
        [HttpGet]
        public object GetUsers()
        {
            return context.Member.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
            }).ToList();
        }
        [HttpGet]
        public object GetMember()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var data = context.Member.FirstOrDefault(x => x.Id == int.Parse(id));
            return new
            {
                path = data.ImagePath,
                data.Name,
            };
        }
        [HttpGet]
        public object GetItem()
        {
            return context.Item.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
            }).ToList();
        }
        [HttpGet]
        public object GetCategory()
        {
            return context.Category.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
            }).ToList();
        }
    }
}
