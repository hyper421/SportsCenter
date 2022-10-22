using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)"), Required]
        public string Name { get; set; }

        public int IsActive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
