namespace SportsCenter.Models
{
    public class TradeInfo
    {
        public string MerchantID { get; set; }
        public string RespondType { get; set; }
        public string TimeStamp { get; set; }
        public string Version { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Amt { get; set; }
        public string ItemDesc { get; set; }
        public string? ReturnURL { get; set; }
        public string? NotifyURL { get; set; }
        public string? Credit { get; set; }
        public int CREDIT { get; internal set; }
        public string? LinePay { get; set; }
        public string? AndroidPay { get; set; }
        public string? Email { get; internal set; }
        public int EmailModify { get; internal set; }
    }
}
