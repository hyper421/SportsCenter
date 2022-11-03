namespace SportsCenter.Models
{
    public class MessagesLoadingViewModel
    {
        public int Id { get; set; }

        public int Member_Id { get; set; }
        public string MemberName { get; set; }
        public string MemberImagePath { get; set; }
        public int Post_Id { get; set; }
        public string Body { get; set; }

        public string CreateDate { get; set; }
    }
}
