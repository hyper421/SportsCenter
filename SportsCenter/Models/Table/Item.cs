using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class Item
    {
        [Key]
        public int Item_Id  { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Item_Name { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Item_ValidFlag { get; set; }
    }
}
