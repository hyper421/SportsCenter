using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SportsCenter.Models.Table
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string ImagePath { get; set; }
        public string Website { get; set; }

        public virtual ICollection<LocationBranch> LocationBranch { get; set; }
        public virtual ICollection<LocationImage> LocationImage { get; set; }
    }
}
