using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.LeoModel;
using System.Security.Claims;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Extensions;
using SportsCenter.Service;
using SportsCenter.Models;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Cart/{action}")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly CryptoService _cryptoService;

        public CartApiController(SportsCenterDbContext dbContext, IConfiguration configuration, CryptoService cryptoService)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
            _cryptoService = cryptoService;
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



        [HttpPost]
        public SpgatewayInputModel GetInfoData(PayData data)
        {
            var cart = dbContext.ProductsCart.Include(x => x.Products).Where(x => x.MemberId == User.GetId());
            dbContext.ProductsOrder.Add(new ProductsOrder
            {
                MemberId = User.GetId(),
                MemberAddress = data.Address,
                MemberCellphone = data.Phone,
                OrderDate = DateTime.Now,
                ProductsOrderDetail = cart.Select(x => new ProductsOrderDetail
                {
                    ProductId = x.ProductsId.ToString(),
                    ProductName = x.Products.ProductsName,
                    ProductsPrice = x.Products.ProductsPrice,
                    Count = x.Count
                }).ToList()
            });
            dbContext.SaveChanges();


            TradeInfo tradeInfo = new TradeInfo()
            {
                MerchantID = _configuration["Pay:MerchantID"],
                RespondType = "JSON",
                TimeStamp = DateTimeOffset.Now.ToOffset(new TimeSpan(8, 0, 0)).ToUnixTimeSeconds().ToString(),
                Version = _configuration["Pay:Version"],
                MerchantOrderNo = $"{DateTime.Now.Ticks}_{User.GetId()}",
                Amt = data.TotalPrice.ToString(),
                ItemDesc = "商品資訊(自行修改)",
                ReturnURL = _configuration["Pay:ReturnURL"],
                NotifyURL = _configuration["Pay:NotifyURL"],
                Email = User.GetMail(),
                EmailModify = 0,
                CREDIT = 1,
            };

            var inputModel = new SpgatewayInputModel
            {
                MerchantID = _configuration["Pay:MerchantID"],
                Version = _configuration["Pay:Version"]
            };

            var tradeQueryPara = string.Join("&", tradeInfo.ToKeyValuePairList().Select(x => $"{x.Key}={x.Value}"));
            inputModel.TradeInfo = _cryptoService.EncryptAESHex(tradeQueryPara, _configuration["Pay:HashKey"], _configuration["Pay:HashIV"]);
            inputModel.TradeSha = _cryptoService.EncryptSHA256($"HashKey={_configuration["Pay:HashKey"]}&{inputModel.TradeInfo}&HashIV={_configuration["Pay:HashIV"]}");

            return inputModel;

        }
    }
}
