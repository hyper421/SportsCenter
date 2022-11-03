using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.LeoModel;
using System.Security.Claims;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Cart/{action}")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        public CartApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public object GetUser()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var data = dbContext.Member.First(x => x.Id == int.Parse(userId));
            return new
            {
                data.Name,
                data.Address,
                data.Email,
                data.Phone
            };
        }
        [HttpGet]
        public CommonApiFormat<List<TempCartModel>> Get()
        {
            var result = new CommonApiFormat<List<TempCartModel>>()
            {
                Status = false,
                Data = new List<TempCartModel>()
            };
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
            {
                return result;
            }
            var user = dbContext.Member.Include(x => x.ProductsCart).ThenInclude(y => y.Products).FirstOrDefault(x => x.Id == int.Parse(userId));
            if (user == null)
            {
                return result;
            }
            var tempdata = user.ProductsCart.Select(x => new TempCartModel
            {
                //塞要的資料
                ProductId = x.Id,
                ProductName = x.Products.ProductsName,
                ProductPrice = x.Products.ProductsPrice,
                ProductCount = x.Count,
            });
            result.Data.AddRange(tempdata);
            result.Status = true;
            return result;
        }

        // POST api/<CartApiController>
        [HttpPost]
        public bool Post([FromBody] AddCartModel model)
        {
            var ProductsName = (from a in dbContext.Products
                                where a.ProductsId == model.ProductId
                                select a.ProductsName).FirstOrDefault();
            var ProductsPrice = (from a in dbContext.Products
                                 where a.ProductsId == model.ProductId
                                 select a.ProductsPrice).FirstOrDefault();

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
            {
                return false;
            }
            var user = dbContext.Member.Include("ProductsCart").FirstOrDefault(x => x.Id == int.Parse(userId));
            if (user == null)
            {
                return false;
            }
            var userCart = user.ProductsCart.FirstOrDefault(x => x.ProductsId == model.ProductId);
            if (userCart == null)
            {
                dbContext.ProductsCart.Add(new ProductsCart
                {
                    MemberId = int.Parse(userId),
                    ProductsId = model.ProductId,
                    Count = model.Count,
                });
            }
            else
            {
                userCart.Count += model.Count;
            }
            dbContext.SaveChanges();
            return true;

        }

        // PUT api/<CartApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        //刪除
        // DELETE api/<CartApiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int Products_Id)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            //var findItem = dbContext.ProductsCart.Where(a => a.Products_Id == Products_Id).Select(a => a).FirstOrDefault();
            var findItem = (from a in dbContext.ProductsCart
                            where a.MemberId == int.Parse(id) && a.ProductsId == Products_Id
                            select a).FirstOrDefault();

            if (findItem == default(ProductsCart))
            {
                return false;
            }
            else
            {
                dbContext.ProductsCart.Remove(findItem);
            }
            dbContext.SaveChanges();
            return true;
        }
    }
}
