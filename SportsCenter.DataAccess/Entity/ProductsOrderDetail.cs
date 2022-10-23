namespace SportsCenter.DataAccess.Entity
{
    public class ProductsOrderDetail
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int Count { get; set; }
        public int ProductsPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductOrderId { get; set; }

        public virtual ProductsOrder ProductOrder { get; set; }
    }
}