using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;

namespace SportsCenter.Controllers.Api
{
    [Route("api/ProductOrder/{action}")]
    [ApiController]
    public class ProductOrderApiController : Controller
    {
        private readonly SportsCenterDbContext context;

        public ProductOrderApiController(SportsCenterDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public object GetAll()
        {
            return context.ProductsOrder.Select(x => new
            {
                x.Id,
                OrderDate = x.OrderDate.ToString("yyyy/M/dd-HH:mm:ss"),
                x.MemberAddress,
                x.MemberCellphone,
                name = (from a in context.Member
                        where a.Id == x.MemberId
                        select a.Name).FirstOrDefault()
            }).ToList();
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
                totle = x.Count*x.ProductsPrice
            });
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.ProductsOrder.Remove(new DataAccess.Entity.ProductsOrder() { Id = id });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        [HttpDelete]

        public bool DeleteDetail(int id)
        {
            try
            {
                context.ProductsOrderDetail.Remove(new DataAccess.Entity.ProductsOrderDetail() { Id = id });
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
