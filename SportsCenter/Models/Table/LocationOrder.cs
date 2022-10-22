using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace SportsCenter.Models.Table
{
    public class LocationOrder
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("LocationBranch")]
        public int LocationBranch_Id { get; set; }
        [ForeignKey("Member")]
        public int Member_Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }

        public DateTime Time { get; set; }



        //建立關聯
        public virtual Member Member { get; set; }

        public virtual Location LocationBranch { get; set; }
       
    }
}
