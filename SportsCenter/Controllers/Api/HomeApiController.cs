using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Home")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;

        public HomeApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<HomeApiController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return dbContext.Category;
        }

        // GET api/<HomeApiController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return dbContext.Category.Find(id);
        }

    }
}
