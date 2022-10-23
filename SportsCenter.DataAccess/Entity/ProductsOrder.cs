namespace SportsCenter.DataAccess.Entity
{
    public  class ProductsOrder
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberAddress { get; set; }
        public string MemberCellphone { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<ProductsOrderDetail> ProductsOrderDetail { get; set; }
    }
}