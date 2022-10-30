using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Controllers.Api
{

    [Route("api/Item/{action}")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;

        public ItemApiController(SportsCenterDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public bool Create(CreateItemModel model)
        {
            try
            {
                context.Item.Add(new DataAccess.Entity.Item
                {
                    IsActive = model.IsActive ? 1 : 0,
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
        public async Task<bool> Update(UpdateItemDto model)
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
            return context.Item.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.Item.First(x => x.Id == id);
            return new
            {
                data.Name,
                IsActive = data.IsActive == 1,
                data.Id,
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.Item.Remove(new DataAccess.Entity.Item() { Id = id });
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
