using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class LocationImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int Location_Id { get; set; }
        public string Path { get; set; }
        
        public virtual Location Location { get; set; }
    }
}