using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Services;

namespace SportsCenter.Controllers.Api
{
    [Route("api/BackProduct/{action}")]
    [ApiController]
    public class BackProductApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;
        private readonly UploadService uploadService;

        public BackProductApiController(SportsCenterDbContext context, UploadService uploadService)
        {
            context = context;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create(CreateProductModel model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Products");
                if (result.Item1)
                {
                    context.Products.Add(new DataAccess.Entity.Products
                    {

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
        public async Task<bool> Update(CategoryUpdateDto model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = context.Products.FirstOrDefault(x => x.ProductsId == model.Id);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Products");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }
                data.ProductsName = model.Name;

                if (needUpdate) data.ProductsImagePath = path;
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
            return context.Products.Select(x => new
            {
                x.ProductsName,
                x.ProductsId,
                path = x.ProductsImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.Products.First(x => x.ProductsId == id);
            return new
            {
                data.ProductsName,
                data.ProductsId,
                path = data.ProductsImagePath
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.Products.Remove(new DataAccess.Entity.Products() { ProductsId = id });
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
