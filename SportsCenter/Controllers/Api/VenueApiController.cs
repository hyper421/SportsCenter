using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Venue")]
    [ApiController]
        public class VenueApiController: ControllerBase
        {

            private readonly SportsCenterDbContext _context;
            public VenueApiController(SportsCenterDbContext _context)
            {
                this._context = _context;
            }
            #region  回傳Location資料

            [HttpGet]

            public IEnumerable<Location> Get()
            {
                return _context.Location;

            }

            #endregion
            #region 回傳詳細資料畫面viaId

            [HttpGet("{id}")]
            public Location GetbyId(int id)
            {

                return _context.Location.Find(id);
            }
            #endregion

            #region  CreateLocation資料

            [HttpPost]
            public IActionResult PostLocation([FromBody] Location location)
            {
                var i = new Location
                {
                    Name = location.Name,
                    EnglishName = location.EnglishName,
                    Address = location.Address,
                    ContactPhone = location.ContactPhone,
                    Website = location.Website,
                    ImagePath = location.ImagePath,
                };
                _context.Location.Add(i);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetbyId), new { id = location.Id }, location);
            }

            #endregion
            #region  刪除

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var location = _context.Location.SingleOrDefault(i => i.Id == id);
                if (location != null)
                {
                    _context.Remove(location);
                    _context.SaveChanges();
                    return NoContent();
                }

                return NotFound();
            }
            #endregion
        }
    }



        //[HttpPut("{id}")]
        //public IActionResult updateLocation(int id, [FromBody] Location update)
        //{
        //    var location = _context.Location.SingleOrDefault(i => i.Id == update.Id);
        //    if (location != null)
        //    {
        //        //location.Name = update.Name;
        //        //location.EnglishName = update.EnglishName;
        //        //location.Address = update.Address;
        //        //location.ContactPhone = update.ContactPhone;
        //        //location.Website = update.Website;
        //        //location.ImagePath = update.ImagePath;
        //        location = update;
        //        _context.Update(location);
        //        _context.SaveChanges();
        //        return CreatedAtAction(nameof(GetbyId), new { id = location.Id }, location);
        //    }
        //    return BadRequest();
        //}


