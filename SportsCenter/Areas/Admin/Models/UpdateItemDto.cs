namespace SportsCenter.Areas.Admin.Models
{
    public class UpdateItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
