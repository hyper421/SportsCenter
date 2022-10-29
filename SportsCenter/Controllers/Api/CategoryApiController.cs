using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.Services;

namespace SportsCenter.Controllers.Api
{
    [Route("api/category/{action}")]
    public class CategoryApiController : ControllerBase
    {
        private readonly SportsCenterDbContext _db;
        private readonly UploadService uploadService;

        public CategoryApiController(SportsCenterDbContext db, UploadService uploadService)
        {
            _db = db;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create(CategoryCreateDto model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Category");
                if (result.Item1)
                {
                    _db.Category.Add(new DataAccess.Entity.Category
                    {
                        IsActive = model.IsActive ? 1 : 0,
                        Name = model.Name,
                        ImagePath = result.Item2

                    });
                    _db.SaveChanges();
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
        public async Task<bool> Update(CategoryUpdateDto model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = _db.Category.FirstOrDefault(x => x.Id == model.Id);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Category");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }
                data.IsActive = model.IsActive ? 1 : 0;
                data.Name = model.Name;

                if (needUpdate) data.ImagePath = path;
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
            return _db.Category.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
                path = x.ImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = _db.Category.First(x => x.Id == id);
            return new
            {
                data.Name,
                IsActive = data.IsActive == 1,
                data.Id,
                path = data.ImagePath
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                _db.Category.Remove(new DataAccess.Entity.Category() { Id = id });
                _db.SaveChanges();
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
