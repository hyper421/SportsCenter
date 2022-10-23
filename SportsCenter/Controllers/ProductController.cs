using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Controllers
{
    public class ProductController : Controller
    {
        private readonly SportsCenterDbContext _dbContext;
        public ProductController(SportsCenterDbContext ProductDbContext)
        {
            this._dbContext = ProductDbContext;
        }
        [HttpGet]
        public IActionResult Basketball()
        {

            return View();                    
        }

        public IActionResult Badminton()
        {
            return View();
        }
        public IActionResult TableTennis()
        {
            return View();
        }
        public IActionResult Pool()
        {
            return View();
        }
        public IActionResult Squash()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Products> BasketballView()
        {
            var basketball = (from a in _dbContext.Products where a.ItemId == 3 select a);
            //foreach (var product in basketball) { Console.WriteLine(product); }
            return basketball;
        }
        [HttpGet]
        public IEnumerable<Products> BadmintonView()
        {
            var badminton = (from a in _dbContext.Products where a.ItemId == 4 select a);
            return badminton;
        }
        [HttpGet]
        public IEnumerable<Products> TableTennisView()
        {
            var tableTennis = (from a in _dbContext.Products where a.ItemId == 5 select a);
            return tableTennis;
        }
        [HttpGet]
        public IEnumerable<Products> PoolView()
        {
            var pool = (from a in _dbContext.Products where a.ItemId == 6 select a);
            return pool;
        }
        [HttpGet]
        public IEnumerable<Products> SquashView()
        {
            var squash = (from a in _dbContext.Products where a.ItemId == 7 select a);
            return squash;
        }

    }
}
