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
<<<<<<< HEAD
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_CreateTime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Member_img { get; set; }
        [DefaultValue(0)]
        public int Member_Role { get; set; }
        //0:未認證1:User,2:Company,3:Empolyee,4:Host

<<<<<<< HEAD
        //public virtual ICollection<ProductsCart> ProductsCart { get; set; }
=======

        public virtual ICollection<Order> Orders { get; set; }
>>>>>>> 2838dc10716329e048da088f8e7dd95237db9ff4
=======
        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
>>>>>>> 1deae47138855ff401fcd0915280cbaefdece186
    }
}
