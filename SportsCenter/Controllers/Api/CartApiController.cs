using Microsoft.AspNetCore.Mvc;
using SportsCenter.Models.LeoModel;
using SportsCenter.Models.Table;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartApiController>
        [HttpPost]
        public void Post([FromBody] AddCartModel model)
        {
            dbContext.ProductsCart.Add(new Models.Table.ProductsCart
            {
                Member_Id = 1,
                Products_Id =model.ProductId,
                ProductsCart_Count =model.Count

            });
        }

        // PUT api/<CartApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
