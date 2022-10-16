using Microsoft.AspNetCore.Mvc;
using SportsCenter.Models.Table;

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


        public IEnumerable<Products> Basketball(int id)
        {
            var basketball = (from a in _dbContext.Products where a.Item_Id == id select a);
            return basketball;
        }
        public IEnumerable<Products> Badminton(int id)
        {
            var badminton = (from a in _dbContext.Products where a.Item_Id == id select a);
            return badminton;
        }
        public IEnumerable<Products> TableTennis(int id)
        {
            var tableTennis = (from a in _dbContext.Products where a.Item_Id == id select a);
            return tableTennis;
        }
        public IEnumerable<Products> Pool(int id)
        {
            var pool = (from a in _dbContext.Products where a.Item_Id == id select a);
            return pool;
        }
        public IEnumerable<Products> Squash(int id)
        {
            var squash = (from a in _dbContext.Products where a.Item_Id == id select a);
            return squash;
        }

    }
}
