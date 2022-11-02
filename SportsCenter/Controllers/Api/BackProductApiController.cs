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
            this.context = context;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create([FromForm] CreateProductModel model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Products");
                var id = (from a in context.Item
                          where a.Name == model.ItemName
                          select a.Id).FirstOrDefault();
                if (result.Item1)
                {
                    context.Products.Add(new DataAccess.Entity.Products
                    {
                        ProductsDateTime = DateTime.Now,
                        ProductsImagePath = result.Item2,
                        ProductsName = model.ProductsName,
                        ProductsInventory = model.ProductsInventory,
                        ProductsPrice = model.ProductsPrice,
                        ItemId = id
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
        public async Task<bool> Update([FromForm] UpdateProductModel model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = context.Products.FirstOrDefault(x => x.ProductsId == model.ProductsId);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Products");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }
                var itemId = (from a in context.Item
                              where a.Name == model.ItemName
                              select a.Id).FirstOrDefault();
                data.ProductsName = model.ProductsName;
                data.ProductsPrice = model.ProductsPrice;
                data.ProductsInventory = model.ProductsInventory;
                data.ItemId = itemId;

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
                x.ProductsPrice,
                x.ProductsInventory,
                path = x.ProductsImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.Products.First(x => x.ProductsId == id);
            var type = (from a in context.Products
                        join b in context.Item
                        on a.ProductsId equals id
                        where a.ItemId == b.Id
                        select b.Name).FirstOrDefault();

            return new
            {
                data.ProductsPrice,
                data.ProductsInventory,
                data.ProductsName,
                data.ProductsId,
                type = type,
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
