namespace SportsCenter.Areas.Admin.Models
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public IFormFile Image { get; set; }
    }
}
