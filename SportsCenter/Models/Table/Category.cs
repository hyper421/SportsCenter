namespace SportsCenter.Models.Table
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }

        public virtual ICollection<LocationBranch> LocationBranch { get; set; }
    }
}