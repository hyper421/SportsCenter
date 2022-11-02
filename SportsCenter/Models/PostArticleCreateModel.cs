using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Models
{
    public class PostArticleCreateModel
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
