using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;
using SportsCenter.DataAccess;

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
     

        // GET api/<BookingController>/5    
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

    public class TempBookingModel
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string OrderBranch { get; set; }
        public string LocationName { get; set; }
        public int? OrderPrice { get; set; }


    }

}
