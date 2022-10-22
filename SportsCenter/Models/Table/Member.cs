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
        public int Id { get; set; }

        public int IsActive { get; set; }

        [Column(TypeName = "nvarchar(max)"), Required]
        public string Name { get; set; }


        [Column(TypeName = "nvarchar(100)"), Required]
        public string Account { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Salt { get; set; }

        [Column(TypeName = "nvarchar(Max)"), Required]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Phone { get; set; }

        public DateTime CreateTime { get; set; }

        public string ImagePath { get; set; }

        public int Role { get; set; }
        //0:未認證1:User,2:Company,3:Empolyee,4:Host

        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
        public virtual ICollection<ProductsOrder> ProductsOrders { get; set; }
        public virtual ICollection<LocationOrder> LocationOrders { get; set; }
    }
}
