namespace SportsCenter.Areas.Admin.Models
{
    public class UpdatePostModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; }
        public IFormFile Image { get; set; }
        public string? Content { get; set; }
    }
}
