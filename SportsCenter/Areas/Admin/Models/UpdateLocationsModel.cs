namespace SportsCenter.Areas.Admin.Models
{
    public class UpdateLocationsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EnglishName { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? ContactPhone { get; set; }
        public string? Area { get; set; }
        public IFormFile Image { get; set; }
        public string? Website { get; set; }
    }
}
