using System.ComponentModel.DataAnnotations;

namespace SportsCenter.Models.DavidModel
{
    public class LoginModel
    {
        [Required]
        public string? Member_Account { get; set; }
        [Required]
        public string? Member_Password { get; set; }
    }
}
