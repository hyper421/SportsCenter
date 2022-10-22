using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsCenter.Models.Table
{
    public class LocationBranch
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int Location_Id { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        /// <summary>
        /// 劃分場館
        /// </summary>
        public string Name { get; set; } 
        public int Price { get; set; }
        public string Memo { get; set; }
        public string ImagePath { get; set; }



        //建立關聯
        public virtual Category Category { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<LocationOrder> LocationOrders { get; set; }

    }
}
