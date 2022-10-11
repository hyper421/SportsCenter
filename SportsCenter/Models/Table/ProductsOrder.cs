using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class ProductsOrder
    {
        [Key]
        public int ProductsOrder_Id { get; set; }
        [Required]
        public int Products_Id { get; set; }
        [Required]
        public int Member_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_Cellphone { get; set; }
        [Required]
        public int ProductsOrder_total { get; set; }
        [Required]
        public int ProductsOrder_Count { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? ProductsOrder_DateTime { get; set; }
    }
}
