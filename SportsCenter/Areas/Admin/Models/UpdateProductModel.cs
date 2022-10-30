namespace SportsCenter.Areas.Admin.Models
{
    public class UpdateProductModel
    {
        public int ProductsId { get; set; }
        public string ItemName { get; set; }
        public string ProductsName { get; set; }
        public int ProductsPrice { get; set; }
        public IFormFile Image { get; set; }
        public int ProductsInventory { get; set; }
    }
}
