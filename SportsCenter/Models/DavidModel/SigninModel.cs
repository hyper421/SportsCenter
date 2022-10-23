using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SportsCenter.Models.DavidModel
{
    public class SigninModel
    {
        [Required]
        public string? Member_Name { get; set; }
        [Required]
        public string? Member_Account { get; set; }
        [Required]
        public string? Member_Password { get; set; }
        [Required]
        public string? Member_Address { get; set; }
        [Required]
        public string? Member_Email { get; set; }
        [Required]
        public string? Member_Phone { get; set; }
        public string? Member_Salt { get; set; }
    }
}
