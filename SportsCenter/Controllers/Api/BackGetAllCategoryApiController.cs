using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

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
