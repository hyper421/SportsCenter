using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class Products
    {
        [Key]
        public int Products_Id { get; set; }
        [ForeignKey("Item")]
        public int Item_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Products_Name { get; set; }
        [Required]
        public int Products_Price { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Products_DateTime { get; set; }
        [Required]
        public int Products_Inventory { get; set; } //庫存
        [Column(TypeName = "nvarchar(50)")]
        public string Products_Target { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Products_img { get; set; }


        public virtual Item Item { get; set; }
        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
    }
}
