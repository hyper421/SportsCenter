using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Table;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly SportsCenterDbContext DbContext;

        public BookingController(SportsCenterDbContext dbContext)
        {
            DbContext = dbContext;
        }
        // GET: api/<BookingController>
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

            var user = DbContext.Member.Include(x=>x.Orders).FirstOrDefault(x=>x.MemberId==int.Parse(userId));
            if (user == null)
            {
                return result;
            }
            var tempData = user.Orders.Select(x => new TempCartModel
            {
                
                OrderId = x.Order_Id,
                LocationId = x.Location_Id,
                OrderDate = x.Order_Date,
                OrderTime = x.Order_Duration,
                OrderPrice = x.Order_Price,
            });
            result.Data.AddRange(tempData);
            result.Status = true;
            return result;
        }

        // GET api/<BookingController>/5    
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        public bool Post([FromBody] BookingModel model)
        {
            DbContext.Order.Add(new Models.Table.Order
            {
                Member_Id = 1,
                Location_Id = model.Location_Id,
                Location_Branch = model.Location_Branch,
                Order_Date = model.Order_Date,
                Order_Duration = model.Order_Duration,
            });
            //DbContext.SaveChanges();
            return true;

            //var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            //if (userId == null)
            //{
            //    return false;
            //}

            //var user = DbContext.Member.Include("Orders").FirstOrDefault(x => x.MemberId == int.Parse(userId));
            //if (user == null)
            //{
            //    return false;
            //}
            //var userCart = user.Orders.FirstOrDefault(x => x.Location_Id == model.Location_Id);
            //if (userCart == null)
            //{
            //    DbContext.Order.Add(new Models.Table.Order
            //    {
            //        Member_Id = int.Parse(userId),
            //        Location_Id = model.Location_Id,
            //        Location_Branch = model.Location_Branch,
            //        Order_Date = model.Order_Date,
            //        Order_Duration = model.Order_Duration,
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("我就爛");
            //}

            //DbContext.SaveChanges();
            //return true;
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class CommonApiFormat<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
    }

    public class TempCartModel
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public int? OrderPrice { get; set; }
    }

}
