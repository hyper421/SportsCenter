﻿namespace SportsCenter.Areas.Admin.Models
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; }
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
