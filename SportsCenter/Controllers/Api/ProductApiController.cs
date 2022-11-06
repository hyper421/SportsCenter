using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Extensions;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Product/{action}")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;

        public ProductApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public object GetItem()
        {
            return dbContext.Item.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
            }).ToList();
        }
        [HttpGet]
        public IEnumerable<Products> GetProduct()
        {
            return dbContext.Products;
        }
        [HttpGet]
        public object GetSuccess()
        {
            var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            var data = dbContext.ProductsOrder.Join(dbContext.ProductsOrderDetail,
                c => c.Id,
                s => s.ProductOrderId,
                (c, s) => new
                {
                    id = c.MemberId,
                    Name = s.ProductName,
                    Count = s.Count,
                    Price = s.ProductsPrice,
                    Time = c.OrderDate.ToString("yyyy/M/dd-HH:mm:ss"),
                    Total = s.ProductsPrice * s.Count,
                }).OrderBy(cs => cs.Total).Where(cs => cs.id == userid);

            Delete();
            return data;
        }
        public bool Delete()
        {
            var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            var user = (from a in dbContext.ProductsCart
                        where a.MemberId == userid
                        select a).FirstOrDefault();
            if (user != null)
            {
                dbContext.ProductsCart.Remove(user);
                dbContext.SaveChanges();
                Delete();
            }
            return true;
        }
    }
}
