using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class OrderInfo
    {
        public int OId { get; set; }
        public int TableId { get; set; }
        public DateTime ODate { get; set; }
        public decimal OTatalCost { get; set; }
        public bool isPaid { get; set; }
        public decimal DiscountType { get; set; }
        public int MemberId { get; set; }
        public int EmpId { get; set; }
    }
}
