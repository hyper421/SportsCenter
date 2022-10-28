namespace SportsCenter.Areas.Admin.Models
{
    public class CategoryCreateDto
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public IFormFile Image { get; set; }
    }
}
