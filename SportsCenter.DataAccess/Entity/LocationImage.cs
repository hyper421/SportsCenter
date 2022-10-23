namespace SportsCenter.DataAccess.Entity
{
    public  class LocationImage
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Path { get; set; }

        public virtual Location Location { get; set; }
    }
}