using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.Services;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Locations/{action}")]
    [ApiController]
    public class LocationsApiController : Controller
    {
        private readonly SportsCenterDbContext context;
        private readonly UploadService uploadService;

        public LocationsApiController(SportsCenterDbContext context, UploadService uploadService)
        {
            this.context = context;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create([FromForm] CreateLocationsModel model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Locations");
                var id = (from a in context.Item
                          where a.Name == model.Name
                          select a.Id).FirstOrDefault();
                if (result.Item1)
                {
                    context.Location.Add(new DataAccess.Entity.Location
                    {
                        Name = model.Name,
                        EnglishName = model.EnglishName,
                        Address = model.Address,
                        Description = model.Description,
                        ContactPhone = model.ContactPhone,
                        Area = model.Area,
                        ImagePath = result.Item2,
                        Website=model.Website,

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
        public async Task<bool> Update([FromForm] UpdateLocationsModel model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = context.Location.FirstOrDefault(x => x.Id == model.Id);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Products");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }

                data.Name = model.Name;
                data.EnglishName = model.EnglishName;
                data.Address = model.Address;
                data.Description = model.Description;
                data.ContactPhone = model.ContactPhone;
                data.Area = model.Area;
                data.Website = model.Website;

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
            return context.Location.Select(x => new
            {
                x.ImagePath,
                x.Id,
                x.EnglishName,
                x.ContactPhone,
                x.Area,
                x.Name,
                path = x.ImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.Location.First(x => x.Id == id);
            var type = (from a in context.Location
                        join b in context.Category
                        on a.Id equals id
                        where a.Id == b.Id
                        select b.Name).FirstOrDefault();

            return new
            {
                data.Address,
                data.Description,
                data.Website,
                data.EnglishName,
                data.ContactPhone,
                data.Name,
                data.Area,
                data.Id,
                path = data.ImagePath,
                itameName = type,
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.Location.Remove(new DataAccess.Entity.Location() { Id = id });
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
