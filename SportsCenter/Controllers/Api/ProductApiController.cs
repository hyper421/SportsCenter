using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Product")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly db_a8ea3c_sportscenterContext dbContext;

        public  ProductApiController(db_a8ea3c_sportscenterContext dbContext)
        {
            this.dbContext = dbContext;
        }



        //GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return dbContext.Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Products Get(int Item_Id)
        {
            return dbContext.Products.Find(Item_Id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
