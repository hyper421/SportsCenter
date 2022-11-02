using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Product/{action}")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;

        public  ProductApiController(SportsCenterDbContext dbContext)
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

        
        
        
    }
}
