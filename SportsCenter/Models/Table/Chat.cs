using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsCenter.Models.Table
{
    public class Chat
    {
        [Key]

        public int Chat_Id { get; set; }
        [Required]
        public int Member_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Chat_Message { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Chat_CreateDateTime { get; set; }
        public int Chat_LikeCount { get; set; }
        public int Chat_DislikeCount { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Chat_ValidFlag { get; set; }
    }
}
