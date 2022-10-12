using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsCenter.Models.Table
{
    public class ProductsCart
    {
        [Key]
        public int ProductsCart_ID { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int Member_Id { get; set; }
        [ForeignKey("Products")]
        public int Products_Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Products_Name { get; set; }
        public int Products_Price { get; set; }
        public int ProductsCart_Count { get; set; }
        public int ProductsCart_Total { get; set; }


        //建立關聯
        public virtual Member Member { get; set; }

        public virtual Products Products { get; set; }
    }
}
