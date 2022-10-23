namespace SportsCenter.DataAccess.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}