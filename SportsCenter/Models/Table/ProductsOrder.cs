using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class ProductsOrder
    {
        //預留方案{1.全信用卡 2.已出貨未出貨}
        [Key]
        public int ProductsOrder_Id { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int Products_Id { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int Member_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_Cellphone { get; set; }
        [Required]
        public int ProductsOrder_Count { get; set; }
        [Required]
        public int ProductsOrder_Total { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? ProductsOrder_DateTime { get; set; }


        //建立關聯
        public virtual Member Member { get; set; }

        public virtual Products Products { get; set; }
    }
}
