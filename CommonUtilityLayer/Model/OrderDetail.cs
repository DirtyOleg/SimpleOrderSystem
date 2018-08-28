using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class OrderDetail
    {
        public int OrderSummaryId { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }
    }
}
