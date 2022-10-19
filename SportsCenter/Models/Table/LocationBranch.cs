using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsCenter.Models.Table
{
    public class LocationBranch
    {
        [Key]
        public int LocationBranch_Id { get; set; }
        [Required]
        [ForeignKey("Location")]
        public int Location_Id { get; set; }
        [Required]
        [ForeignKey("Item")]
        public int Item_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? LocationBranch_partition { get; set; } //劃分場館
        [Required]
        public int LocationBranch_Price { get; set; }



        //建立關聯
        public virtual Item Item { get; set; }

        public virtual Location Location { get; set; }

    }
}
