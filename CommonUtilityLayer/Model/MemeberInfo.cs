using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class MemeberInfo
    {
        public int MId { get; set; }
        public string MName { get; set; }
        public string MPhone { get; set; }
        public decimal MBalance { get; set; }
        public int MMemType { get; set; }
        public bool DelFlag { get; set; }
    }
}
