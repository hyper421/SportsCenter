using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.Services;

namespace SportsCenter.Controllers.Api
{
    [Route("api/LocationsBrunch/{action}")]
    [ApiController]
    public class LocationsBrunchApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;
        private readonly UploadService uploadService;

        public LocationsBrunchApiController(SportsCenterDbContext context, UploadService uploadService)
        {
            this.context = context;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create([FromForm] CreateLocationBranchModel model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Products");

                if (result.Item1)
                {
                    context.LocationBranch.Add(new DataAccess.Entity.LocationBranch
                    {
                        LocationId = (from a in context.Location
                                      where a.Name == model.LocationName
                                      select a.Id).FirstOrDefault(),
                        CategoryId = (from a in context.Category
                                      where a.Name == model.Type
                                      select a.Id).FirstOrDefault(),
                        Name = model.Name,
                        Price = model.Price,
                        Memo = model.Memo,
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
        public async Task<bool> Update([FromForm] UpdateLocationBranchModel model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = context.LocationBranch.FirstOrDefault(x => x.Id == model.Id);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Products");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }

                data.Id = model.Id;
                data.LocationId = (from a in context.Location
                                   where a.Name == model.LocationName
                                   select a.Id).FirstOrDefault();
                data.CategoryId = (from a in context.Category
                                   where a.Name == model.Type
                                   select a.Id).FirstOrDefault();
                data.Name = model.Name;
                data.Price = model.Price;
                data.Memo = model.Memo;

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
            return context.LocationBranch.Select(x => new
            {
                x.Id,
                LocationName=(from a in context.Location
                              where a.Id == x.LocationId
                              select a.Name).FirstOrDefault(),
                Type=(from a in context.Category
                      where a.Id == x.CategoryId
                      select a.Name).FirstOrDefault(),
                x.Name,
                x.Price,
                x.Memo,
                path = x.ImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.LocationBranch.First(x => x.Id == id);
            return new
            {
                data.Id,
                LocationName = (from a in context.Location
                                where a.Id == data.LocationId
                                select a.Name).FirstOrDefault(),
                Type = (from a in context.Category
                        where a.Id == data.CategoryId
                        select a.Name).FirstOrDefault(),
                data.Name,
                data.Price,
                data.Memo,
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.LocationBranch.Remove(new DataAccess.Entity.LocationBranch() { Id = id });
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
