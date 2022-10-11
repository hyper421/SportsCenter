using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SportsCenter.Models.Table
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Member_Level { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Member_ValidFlag { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [DisplayName("姓名")]
        [Required]
        public string? Member_Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("帳號")]
        [Required]
        public string? Member_Account { get; set; }
        [Column(TypeName = "nvarchar(Max)")]
        [DisplayName("密碼")]
        [Required]
        public string? Member_Password { get; set; }
        [Required]
        public string? Member_Salt { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("地址")]
        [Required]
        public string? Member_Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("信箱")]
        [Required]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$", ErrorMessage = "請輸入正確的電子郵件位址.")]
        public string? Member_Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("電話")]
        [RegularExpression("[0-9]+",ErrorMessage ="請輸入數字")]
        [Required]
        public string? Member_Phone { get; set; }
    }
}
