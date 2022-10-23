namespace SportsCenter.DataAccess.Entity
{
    public class LocationBranch
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Memo { get; set; }
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<LocationOrder> LocationOrder { get; set; }
    }
}