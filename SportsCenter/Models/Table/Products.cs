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

        [Column(TypeName = "nvarchar(50)"), Required]
        public string? Products_Name { get; set; }
        
        public int Products_Price { get; set; }

        public DateTime Products_DateTime { get; set; }

        /// <summary>
        ///  庫存
        /// </summary>
        public int Products_Inventory { get; set; }

        public string Products_ImagePath { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
    }
}
