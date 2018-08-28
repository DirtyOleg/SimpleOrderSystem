using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberPhone { get; set; }
        public decimal MemberBalance { get; set; }
        public int MembershipType { get; set; }
        public bool DelFlag { get; set; }
    }
}
