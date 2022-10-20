using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace SportsCenter.Models.Table
{
    //只能信用卡 沒有以繳費選項
    public class LocationOrder
    {
        [Key]
        public int LocationOrder_Id { get; set; }
        [Required]
        [ForeignKey("Location")]
        public int Location_Id { get; set; }
        public int LocationBranch_Id { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int Member_Id { get; set; }
        [Required]
        public int LocationOrder_Price { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? LocationOrder_DateTime { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? LocationOrder_Time { get; set; }



        //建立關聯
        public virtual Member Member { get; set; }

        public virtual Location Location { get; set; }
    }
}
