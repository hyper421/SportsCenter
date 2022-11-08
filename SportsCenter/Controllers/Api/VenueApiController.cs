using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Extensions;
using SportsCenter.Models;
using SportsCenter.Service;
using System.Security.Claims;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Venue/{action}")]
    [ApiController]
    public class VenueApiController : ControllerBase
    {

        private readonly SportsCenterDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly CryptoService _cryptoService;


        public VenueApiController(SportsCenterDbContext _context, IConfiguration configuration, CryptoService cryptoService)
        {
            this._context = _context;
            _configuration = configuration;
            _cryptoService = cryptoService;
        }
        public object GetVenueByCategory(int categoryId)
        {
            var category = _context.Category.Include(x => x.LocationBranch).ThenInclude(x => x.Location).FirstOrDefault(x => x.Id == categoryId);
            if (category == null) return null;

            return category.LocationBranch.Select(x => new
            {
                x.Location.Area,
                LocationName = x.Location.Name,
                x.Location.Description,
                x.Location.ImagePath,
                LocationId = x.Location.Id,
                LocationBranchId = x.Id,
                x.Location.Address,
                x.Name,
                x.Price,
                x.Memo
            }).GroupBy(x => new { x.Area, x.LocationName, x.Description, x.ImagePath, x.LocationId, /*x.LocationBranchId*/ }, (area, place) => new {
                area,
                place
            });
        }

        #region  回傳Location資料

        [HttpGet]
        public object Get()
        {
            return _context.Location.Select(x => new
            {
                x.Area,
                x.ImagePath,
                x.Id,
                x.Name,
                x.EnglishName,
                x.Description,
                x.Website,
                x.ContactPhone,
                x.Address,
                categoryIds = x.LocationBranch.Select(x => x.CategoryId).ToList()
            });

        }

        #endregion
        #region 回傳詳細資料畫面viaId
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetDetail(int id)
        {
            var data = _context.Location.Where(x => x.Id == id).Select(x => new DataAccess.Entity.Location
            {
                Id = x.Id,
                Area = x.Area,
                ImagePath = x.ImagePath,
                Name = x.Name,
                EnglishName = x.EnglishName,
                Description = x.Description,
                Website = x.Website,
                ContactPhone = x.ContactPhone,
                Address = x.Address,
            }).FirstOrDefault();

            return Ok(data);
        }

        #endregion


        [HttpPost]
        public SpgatewayInputModel GetInfoData(bookingData data)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            //var order = _context.Category.Include(x => x.LocationBranch).ThenInclude(x => x.Location).FirstOrDefault(x => x.Id == categoryId);
            _context.LocationOrder.Add(new LocationOrder
            {
                LocationBranchId = data.LocationBranchId,
                MemberId = User.GetId(),
                Price = data.Price,
                DateTime = DateTime.Now,
            });
            _context.SaveChanges();


            TradeInfo tradeInfo = new TradeInfo()
            {
                MerchantID = _configuration["Pay:MerchantID"],
                RespondType = "JSON",
                TimeStamp = DateTimeOffset.Now.ToOffset(new TimeSpan(8, 0, 0)).ToUnixTimeSeconds().ToString(),
                Version = _configuration["Pay:Version"],
                MerchantOrderNo = $"{DateTime.Now.Ticks}_{User.GetId()}",
                //Amt = data.TotalPrice.ToString(),
                Amt = data.Price.ToString(),
                ItemDesc = data.Name + data.Category ,
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












        #region  CreateLocation資料

        [HttpPost]
        public IActionResult PostLocation([FromBody] Location location)
        {
            var i = new Location
            {
                Name = location.Name,
                EnglishName = location.EnglishName,
                Address = location.Address,
                ContactPhone = location.ContactPhone,
                Website = location.Website,
                ImagePath = location.ImagePath,
            };
            _context.Location.Add(i);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDetail), new { id = location.Id }, location);
        }

        #endregion
        #region  刪除

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var location = _context.Location.SingleOrDefault(i => i.Id == id);
            if (location != null)
            {
                _context.Remove(location);
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
        #endregion
    }
}


