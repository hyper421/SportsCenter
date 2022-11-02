using SportsCenter.Controllers.Api;
using SportsCenter.DataAccess.Entity;
using System.Collections.Generic;

namespace SportsCenter.Models
{
    public class PostMessageViewModel
    {
        public int Id { get; set; }
        public int Member_Id { get; set; }
        public int InviteCategory_Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }
        public string CreatedDate { get; set; }

        public IEnumerable<MessagesLoadingViewModel> Message { get; set; }
        //public IEnumerable<GetInviteCategoryModel> InviteCategory  {get; set; }//？？需要嗎
    }
}
