using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer.Model
{
    public class Dish
    {
        public int DishId { get; set; }
        public int DishTypeId { get; set; }
        public string DishTitle { get; set; }
        public decimal DishPrice { get; set; }
        public string DishShortcut { get; set; }
        public bool DelFlag { get; set; }
    }
}
