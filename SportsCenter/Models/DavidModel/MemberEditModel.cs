using System.ComponentModel.DataAnnotations;

namespace SportsCenter.Models.DavidModel
{
    public class MemberEditModel
    {
        public string? Member_Name { get; set; }
        public string? Member_Account { get; set; }
        public string? Member_Password { get; set; }
        public string? Member_Address { get; set; }
        public string? Member_Email { get; set; }
        public string? Member_Phone { get; set; }
    }
}
