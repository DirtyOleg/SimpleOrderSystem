using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class OrderSummary
    {
        public int OrderSummaryId { get; set; }
        public DateTime Date { get; set; }
        public decimal TatalCostBeforeDiscount { get; set; }
        public decimal DiscountType { get; set; }
        public decimal TatalCostAfterDiscount { get; set; }
        public int MemberId { get; set; }
        public int TableId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsPaid { get; set; }
    }
}
