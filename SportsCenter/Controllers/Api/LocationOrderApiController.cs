using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.Services;

namespace SportsCenter.Controllers.Api
{
    [Route("api/LocationOrder/{action}")]
    [ApiController]
    public class LocationOrderApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;
        private readonly UploadService uploadService;

        public LocationOrderApiController(SportsCenterDbContext context, UploadService uploadService)
        {
            this.context = context;
            this.uploadService = uploadService;
        }
        [HttpGet]
        public object GetAll()
        {
            var data = (from a in context.LocationOrder join b in context.LocationBranch
                       on a.LocationBranchId equals b.Id
                       select new {a.Id,a.MemberId,b.LocationId,a.LocationBranchId,b.CategoryId,a.Price,a.Time});

            return data.Select(x => new
            {
                x.Id,
                user = context.Member.Where(a=>a.Id==x.MemberId).Select(b=>b.Name).FirstOrDefault(),
                locationName = context.Location.Where(a=>a.Id==x.LocationId).Select(b=>b.Name).FirstOrDefault(),
                brunchName = context.LocationBranch.Where(a=>a.Id == x.LocationBranchId).Select(b=>b.Name).FirstOrDefault(),
                category = context.Category.Where(a=>a.Id==x.CategoryId).Select(b=>b.Name).FirstOrDefault(),
                x.Price,
                x.Time
            });
        }
        [Route("{id}")]
        public object Detail(int id)
        {

            return context.ProductsOrderDetail.Where(x => x.ProductOrderId == id).Select(x => new
            {
                x.ProductName,
                x.ProductsPrice,
                x.Count,
                x.Id,
                totle = x.Count * x.ProductsPrice
            });
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.LocationOrder.Remove(new DataAccess.Entity.LocationOrder() { Id = id });
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
