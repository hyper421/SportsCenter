using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Models
{
    public class PostArticleCreateModel
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int InviteCategory_Id { get; set; }
        public IFormFile? files { get; set; }

        //public IEnumerable<GetInviteCategoryModel> InviteCategory { get; set; }//需要嗎？？


    }
}
