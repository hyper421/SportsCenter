namespace SportsCenter.Models
{
    public class MessageViewModel
    {


        public int Id { get; set; }

        public int Member_Id { get; set; }
        public int Post_Id { get; set; }
        public string Body { get; set; }

        public DateTime CreateDate { get; set; }

        //public virtual Member Member { get; set; }

        //public virtual Post Post { get; set; }


    }
}
