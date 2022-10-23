using Microsoft.AspNetCore.Builder;
using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Models.JenaModel
{
    public class LocationViewModel
    {
        public Location Location { get; set; }
        public IFormFile? Files { get; set; }

    }
}
