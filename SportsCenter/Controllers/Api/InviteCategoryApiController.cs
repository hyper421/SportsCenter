using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;

namespace SportsCenter.Controllers.Api
{
    [Route("api/InviteCategory/{action}")]
    [ApiController]
    public class InviteCategoryApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;

        public InviteCategoryApiController(SportsCenterDbContext db)
        {
            context = db;
        }
        [HttpPost]
        public bool Create(CreateInviteCategoryModel model)
        {
            try
            {
                context.InviteCategory.Add(new DataAccess.Entity.InviteCategory
                {
                    IsActive = model.IsActive,
                    Name = model.Name,
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<bool> Update(UpdateInviteCategoryDto model)
        {
            try
            {
                var data = context.Category.FirstOrDefault(x => x.Id == model.Id);
                if (data == null) return false;
                data.IsActive = model.IsActive ? 1 : 0;
                data.Name = model.Name;
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
            return context.InviteCategory.Select(x => new
            {
                x.Name,
                x.IsActive,
                x.Id,
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.InviteCategory.First(x => x.Id == id);
            return new
            {
                data.Name,
                data.IsActive,
                data.Id,
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.InviteCategory.Remove(new DataAccess.Entity.InviteCategory() { Id = id });
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
