using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class DishInfo
    {
        public int DId { get; set; }
        public int DTypeId { get; set; }
        public string DTitle { get; set; }
        public decimal DPrice { get; set; }
        public string DShortcut { get; set; }
        public bool DelFlag { get; set; }
    }
}
