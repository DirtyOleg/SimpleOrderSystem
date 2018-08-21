using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class OrderDetailInfo
    {
        public int OrderId { get; set; }
        public int DishInfoId { get; set; }
        public int Count { get; set; }
    }
}
