namespace SportsCenter.Areas.Admin.Models
{
    public class CreatePostModel
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; }
        public IFormFile Image { get; set; }
        public string? Content { get; set; }
    }
}
