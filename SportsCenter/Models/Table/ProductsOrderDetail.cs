using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class ProductsOrderDetail
    {
        [Key]
        public int Id { get; set; }
        public string Product_ID { get; set; }
        public int Count { get; set; }
        public int Products_Price { get; set; }
        public string Product_Name { get; set; }

        [ForeignKey("ProductsOrder")]
        public int ProductOrderId { get; set; }

        public virtual ProductsOrder ProductsOrder { get; set; }

    }
}