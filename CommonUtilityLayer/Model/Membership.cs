using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public string MembershipName { get; set; }
        public decimal DiscountType { get; set; }
        public bool DelFlag { get; set; }
    }
}
