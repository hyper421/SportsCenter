using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace SportsCenter.Models.Table
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [DefaultValue(0)]
        public int Member_ValidFlag { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string? Member_Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string? Member_Account { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_Salt { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        [Required]
        public string? Member_Password { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string? Member_Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string? Member_Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string? Member_Phone { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_CreateTime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_img { get; set; }
        [DefaultValue(0)]
        public int Member_Role { get; set; } //0:User1:Company2:Empolyee3:Host

        //public virtual ICollection<ProductsCart> ProductsCart { get; set; }
    }
}
