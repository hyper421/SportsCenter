namespace SportsCenter.DataAccess.Entity
{
    public  class Products
    {
        public int ProductsId { get; set; }
        public int ItemId { get; set; }
        public string ProductsName { get; set; }
        public int ProductsPrice { get; set; }
        public DateTime ProductsDateTime { get; set; }
        public int ProductsInventory { get; set; }
        public string ProductsImagePath { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
    }
}