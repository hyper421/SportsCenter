using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Models
{
    public class PostArticleCreateModel
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public IFormFile? Files { get; set; }
        

    }
}
