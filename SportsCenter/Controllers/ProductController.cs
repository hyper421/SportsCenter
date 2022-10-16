using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Table;
using System.Security.Claims;

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
        public IActionResult Index()
        {
            return View();                    
        }

        //public IActionResult Badminton()
        //{
        //    return View("Badminton");
        //}
        //public IActionResult TableTennis()
        //{
        //    return View("TableTennis");
        //}
        //public IActionResult Pool()
        //{
        //    return View("Pool");
        //}
        //public IActionResult Squash()
        //{
        //    return View("Squash");
        //}

        [HttpGet]
        public IEnumerable<Products> Basketball()
        {
            var basketball = (from a in _dbContext.Products where a.Item_Id == 1 select a);
            foreach (var product in basketball) { Console.WriteLine(product); }
            return basketball;
        }
        [HttpGet]
        public IEnumerable<Products> Badminton()
        {
            var badminton = (from a in _dbContext.Products where a.Item_Id == 2 select a);
            return badminton;
        }
        [HttpGet]
        public IEnumerable<Products> TableTennis()
        {
            var tableTennis = (from a in _dbContext.Products where a.Item_Id == 3 select a);
            return tableTennis;
        }
        [HttpGet]
        public IEnumerable<Products> Pool()
        {
            var pool = (from a in _dbContext.Products where a.Item_Id == 4 select a);
            return pool;
        }
        [HttpGet]
        public IEnumerable<Products> Squash()
        {
            var squash = (from a in _dbContext.Products where a.Item_Id == 5 select a);
            return squash;
        }

    }
}
