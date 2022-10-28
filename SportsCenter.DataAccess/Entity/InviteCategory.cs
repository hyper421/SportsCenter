namespace SportsCenter.DataAccess.Entity
{
    public class InviteCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}