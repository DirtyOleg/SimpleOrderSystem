using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class Membership
    {
        public int MId { get; set; }
        public string MName { get; set; }
        public decimal MDiscountType { get; set; }
        public bool DelFlag { get; set; }
    }
}
