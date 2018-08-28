using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class EmployeeInfo
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePwd { get; set; }
        public string EmployeePosition { get; set; }
        public bool DelFlag { get; set; }
    }
}
