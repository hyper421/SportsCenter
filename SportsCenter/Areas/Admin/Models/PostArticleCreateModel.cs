using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Models.Dto
{
    public class PostArticleCreateModel
    {


        public int Id { get; set; }
        public int Member_Id { get; set; }
        public int InviteCategory_Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }

            public string Type { get; set; } //臨時
        public DateTime CreatedDate { get; set; }



    }
}
