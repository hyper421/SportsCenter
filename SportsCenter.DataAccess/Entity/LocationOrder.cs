namespace SportsCenter.DataAccess.Entity
{
    public  class LocationOrder
    {
        public int Id { get; set; }
        public int LocationBranchId { get; set; }
        public int MemberId { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }

        public virtual LocationBranch LocationBranch { get; set; }
        public virtual Member Member { get; set; }
    }
}