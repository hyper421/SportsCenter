using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SportsCenter.Models.Table
{
    public class Location
    {
        [Key]
        public int Location_Id { get; set; }
        [Required]
        public int Item_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Location_Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Location_Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Location_partition { get; set; } //劃分場館

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Location_Phone { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Location_Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Location_Area { get; set; }
        [Required]
        public int Location_Price { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Location_ValidFlag { get; set; }
    }
}
