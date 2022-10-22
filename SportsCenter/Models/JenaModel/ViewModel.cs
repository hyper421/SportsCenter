using Microsoft.AspNetCore.Builder;
using SportsCenter.Models.Entity;

namespace SportsCenter.Models.JenaModel
{
    public class LocationViewModel
    {
        public Location Location { get; set; }
        public IFormFile? Files { get; set; }

    }
}
