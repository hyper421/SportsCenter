namespace SportsCenter.DataAccess.Entity
{
    public  class ProductsCart
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ProductsId { get; set; }
        public int Count { get; set; }

        public virtual Member Member { get; set; }
        public virtual Products Products { get; set; }
    }
}