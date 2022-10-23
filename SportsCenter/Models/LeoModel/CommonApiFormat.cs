using System.Reflection.Metadata.Ecma335;

namespace SportsCenter.Models.LeoModel
{
    public class CommonApiFormat<T>
    {
        public bool Status { get; set; }
        public  T Data { get; set; }
    }
}
