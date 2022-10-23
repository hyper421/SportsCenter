using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models.JenaModel;

namespace SportsCenter.Controllers
{
    public class LocationsController : Controller
    {
        private readonly SportsCenterDbContext _context;
        private readonly IHostEnvironment environment;

        public LocationsController(SportsCenterDbContext context, IHostEnvironment environment)
        {
            _context = context;
            this.environment = environment; //傳照片用
        }
        #region 修改Location後台
        public async Task<IActionResult> EditBackEnd()
        {
            return View(await _context.Location.ToListAsync());
        }
        #endregion
        #region GET Index頁面
  
        public async Task<IActionResult> Index()
        {
            return View(await _context.Location.ToListAsync());
        }
        #endregion
        #region 詳細資料頁面
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }
        #endregion

        #region Create頁面+照片上傳
        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }
        //要把確切要綁啥寫在Bind

        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create([Bind("Location_Id,Location_Name,Location_EngName,Location_Area,Location_Address,Location_Phone,Location_Email,Location_ValidFlag")] Location location, IFormFile files)
        public async Task<IActionResult> Create(LocationViewModel model, IFormFile files)
        {

            //if (files == null || files.Length == 0)
            //{
            //    return Content("沒有選取檔案，請回上一頁");
            //    return RedirectToAction("Create");
            //}

            var path = Path.Combine(environment.ContentRootPath, "wwwroot\\Jena\\picture", files.FileName);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            //    var root = $@"{environment.ContentRootPath}\wwwroot\picture";
            //var imagePath = root + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + files.FileName;
            //using (var fs = System.IO.File.Create(path))
            {
                await files.CopyToAsync(fs);
                fs.Close();
            }
            model.Location.ImagePath = files.FileName;

            //if (ModelState.IsValid)
            if (model != null)
            {
                _context.Location.Add(new Location()
                {
                    Name = model.Location.Name,
                    EnglishName = model.Location.EnglishName,
                    Address = model.Location.Address,
                    ContactPhone = model.Location.ContactPhone,
                    Website = model.Location.Website,
                    ImagePath = model.Location.ImagePath,
                });
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Edit頁面+照片上傳 (壞掉要修)

        public IActionResult Edit()
        {
            return View();
        }
        //要把確切要綁啥寫在Bind

        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create([Bind("Location_Id,Location_Name,Location_EngName,Location_Area,Location_Address,Location_Phone,Location_Email,Location_ValidFlag")] Location location, IFormFile files)
        public async Task<IActionResult> Edit(LocationViewModel model, IFormFile files)
        {

            //if (files == null || files.Length == 0)
            //{
            //    return Content("沒有選取檔案，請回上一頁");
            //    return RedirectToAction("Edit");
            //}

            var path = Path.Combine(environment.ContentRootPath, "wwwroot\\Jena\\picture", files.FileName);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            //    var root = $@"{environment.ContentRootPath}\wwwroot\picture";
            //var imagePath = root + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + files.FileName;
            //using (var fs = System.IO.File.Create(path))
            {
                await files.CopyToAsync(fs);
                fs.Close();
            }
            model.Location.ImagePath = files.FileName;

            //if (ModelState.IsValid)
            if (model != null)
            {
                var location = new Location
                {
                    Name = model.Location.Name,
                    EnglishName = model.Location.EnglishName,
                    Address = model.Location.Address,
                    ContactPhone = model.Location.ContactPhone,
                    Website = model.Location.Website,
                    ImagePath = model.Location.ImagePath,

                };
                _context.Add(location);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Location == null)
        //    {
        //        return NotFound();
        //    }

        //    var location = await _context.Location.FindAsync(id);
        //    if (location == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(location);
        //}

        //// POST: Locations/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Location_Id,Location_Name,Location_EngName,Location_Area,Location_Address,Location_Phone,Location_Email,Location_ValidFlag")] Location location)
        //{
        //    if (id != location.Location_Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(location);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LocationExists(location.Location_Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(location);
        //}
        #endregion
        #region 刪除畫面
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Location == null)
            {
                return Problem("Entity set 'SportsCenterDbContext.Location'  is null.");
            }
            var location = await _context.Location.FindAsync(id);
            if (location != null)
            {
                _context.Location.Remove(location);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
#endregion
        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.Id == id);
        }
    }
}
