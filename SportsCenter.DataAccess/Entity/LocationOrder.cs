namespace SportsCenter.DataAccess.Entity
{
    public  class LocationOrder
    {
        public int Id { get; set; }
        public int LocationBranchId { get; set; }
        public int MemberId { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int? LocationBranchId1 { get; set; }

        public virtual Location LocationBranch { get; set; }
        public virtual LocationBranch LocationBranchId1Navigation { get; set; }
        public virtual Member Member { get; set; }
    }
}