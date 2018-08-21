using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class EmployeeInfo
    {
        public int EId { get; set; }
        public string EName { get; set; }
        public string EPwd { get; set; }
        public string EPosition { get; set; }
        public bool DelFlag { get; set; }
    }
}
