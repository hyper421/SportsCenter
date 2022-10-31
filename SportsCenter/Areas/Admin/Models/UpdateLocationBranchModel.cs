namespace SportsCenter.Areas.Admin.Models
{
    public class UpdateLocationBranchModel
    {
        public int Id { get; set; }
        public string? LocationName { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Memo { get; set; }
        public IFormFile Image { get; set; }
    }
}
