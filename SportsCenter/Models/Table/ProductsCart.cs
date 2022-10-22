using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsCenter.Models.Table
{
    public class ProductsCart
    {
        [Key]
        public int ID { get; set; }


        [ForeignKey("Member")]
        public int Member_Id { get; set; }

        [ForeignKey("Products")]
        public int Products_Id { get; set; }

        public int Count { get; set; }


        //建立關聯
        public virtual Member Member { get; set; }

        public virtual Products Products { get; set; }
    }
}
