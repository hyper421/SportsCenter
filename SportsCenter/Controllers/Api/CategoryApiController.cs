using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.Models.Dto;

namespace SportsCenter.Controllers.Api
{
    [Route("api/category/{action}")]
    public class CategoryApiController : ControllerBase
    {
        private readonly SportsCenterDbContext _db;

        public CategoryApiController(SportsCenterDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public bool Create([FromBody]CategoryCreateDto model)
        {
            try
            {
                _db.Category.Add(new DataAccess.Entity.Category
                {
                    IsActive = model.IsActive ? 1 : 0,
                    Name = model.Name,
                });
                _db.SaveChanges();
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
            return _db.Category.Select(x=> new { 
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
                path = ""
            
            }).ToList();
        }
    }
}
