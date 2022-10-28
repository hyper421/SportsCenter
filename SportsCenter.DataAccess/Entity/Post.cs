using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCenter.DataAccess.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public int Member_Id { get; set; }
        public int InviteCategory_Id { get; set; }
        public string Title { get; set; }        
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual InviteCategory InviteCategory { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
