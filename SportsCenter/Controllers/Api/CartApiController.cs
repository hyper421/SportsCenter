using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.LeoModel;
using SportsCenter.Models.Table;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Cart")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        public CartApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<CartApiController>
        [HttpGet]
        public CommonApiFormat<List<TempCartModel>> Get()
        {
            //var result = new CommonApiFormat<List<TempCartModel>>()
            //{
            //    Status = false,
            //    Data = new List<TempCartModel>()
            //};
            //var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            //if (userId == null)
            //{
            //    return result;
            //}
            //var user = dbContext.Member.Include(x => x.ProductsCart).ThenInclude(y => y.Products).FirstOrDefault(x => x.MemberId == int.Parse(userId));
            //if (user == null)
            //{
            //    return result;
            //}
            //var tempdata = user.ProductsCart.Select(x => new TempCartModel
            //{
            //    //塞要的資料
            //    ProductId = x.ProductsCart_ID,
            //    ProductName = x.Products_Name,
            //    ProductPrice = x.Products_Price,
            //    ProductCount = x.ProductsCart_Count,
            //    ProductTotal = x.ProductsCart_Total,
            //});
            //result.Data.AddRange(tempdata);
            //result.Status = true;
            //return result;

            //測試用
            var result = new CommonApiFormat<List<TempCartModel>>()
            {
                Status = false,
                Data = new List<TempCartModel>()
            };
            var user = dbContext.Member.Include(x => x.ProductsCart).ThenInclude(y => y.Products).FirstOrDefault(x => x.MemberId == 2);
            if (user == null)
            {
                return result;
            }
            var tempdata = user.ProductsCart.Select(x => new TempCartModel
            {
                //塞要的資料
                ProductId = x.ProductsCart_ID,
                ProductName = x.Products_Name,
                ProductPrice = x.Products_Price,
                ProductCount = x.ProductsCart_Count,
                ProductTotal = x.ProductsCart_Total,
                
            });
            result.Data.AddRange(tempdata);
            result.Status = true;
            return result;
        }

        // GET api/<CartApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartApiController>
        [HttpPost]
        public bool Post([FromBody] AddCartModel model)
        {
            //var ProductsName = (from a in dbContext.Products
            //                    where a.Products_Id == model.ProductId
            //                    select a.Products_Name).FirstOrDefault();
            //var ProductsPrice = (from a in dbContext.Products
            //                     where a.Products_Id == model.ProductId
            //                     select a.Products_Price).FirstOrDefault();

            //var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            //if (userId == null)
            //{
            //    return false;
            //}
            //var user = dbContext.Member.Include("ProductsCart").FirstOrDefault(x => x.MemberId == int.Parse(userId));
            //if (user == null)
            //{
            //    return false;
            //}
            //var userCart = user.ProductsCart.FirstOrDefault(x => x.Products_Id == model.ProductId);
            //if (userCart == null)
            //{
            //    dbContext.ProductsCart.Add(new Models.Table.ProductsCart
            //    {
            //        Member_Id = int.Parse(userId),
            //        Products_Id = model.ProductId,
            //        ProductsCart_Count = model.Count,
            //        Products_Name = ProductsName,
            //        Products_Price = ProductsPrice,
            //    });
            //}
            //else
            //{
            //    userCart.ProductsCart_Count += model.Count;
            //}
            //dbContext.SaveChanges();
            //return true;

            //測試用
            var ProductsName = (from a in dbContext.Products
                                where a.Products_Id == model.ProductId
                                select a.Products_Name).FirstOrDefault();
            var ProductsPrice = (from a in dbContext.Products
                                 where a.Products_Id == model.ProductId
                                 select a.Products_Price).FirstOrDefault();

            var user = dbContext.Member.Include("ProductsCart").FirstOrDefault(x => x.MemberId == 2);
            if (user == null)
            {
                return false;
            }
            var userCart = user.ProductsCart.FirstOrDefault(x => x.Products_Id == model.ProductId);
            if (userCart == null)
            {
                dbContext.ProductsCart.Add(new Models.Table.ProductsCart
                {
                    Member_Id = 2,
                    Products_Id = model.ProductId,
                    ProductsCart_Count = model.Count,
                    Products_Name = ProductsName,
                    Products_Price = ProductsPrice,
                });
            }
            else
            {
                userCart.ProductsCart_Count += model.Count;
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
                            where a.Member_Id == int.Parse(id) && a.Products_Id == Products_Id
                            select a).FirstOrDefault();

            if (findItem == default(Models.Table.ProductsCart))
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
