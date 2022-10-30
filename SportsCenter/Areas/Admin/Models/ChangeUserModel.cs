namespace Test.Models.DavidModel
{
    public class ChangeUserModel
    {
        public int Id { get; set; }
        public int IsActive { get; set; }
        public int Role { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Image { get; set; }

    }
}
