using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    /// <summary>
    /// //預留方案{1.全信用卡 2.已出貨未出貨}
    /// </summary>
    public class ProductsOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Member")]
        public int Member_Id { get; set; }

        [Required]
        public string? Member_Address { get; set; }

        [Required]
        public string? Member_Cellphone { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Member Member { get; set; }

        public virtual ICollection<ProductsOrderDetail> ProductsOrderDetails { get; set; }
    }
}
