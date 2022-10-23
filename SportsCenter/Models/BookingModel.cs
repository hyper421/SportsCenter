namespace SportsCenter.Controllers.Api
{
    public class BookingModel
    {
        public int ProductId { get; set; }
        public int Location_Id { get; set; }
        public string? Location_Branch { get; set; }
        public string? Order_Date { get; set; }
        public string? Order_Duration { get; set; }
    }
}