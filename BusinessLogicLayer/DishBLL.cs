using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DishBLL
    {
        private DishDAL diDAL = new DishDAL();

        public List<Dish> GetList()
        {
            return diDAL.GetList();
        }
        
        public int AddDishInfo(Dish dish)
        {
            return diDAL.InsertCommand(dish);
        }

        public int UpdateDishInfo(Dish dish)
        {
            return Convert.ToInt32(diDAL.UpdateCommnad(dish));
        }

        public int DeleteDishInfo(Dish dish)
        {
            return Convert.ToInt32(diDAL.DeleteCommand(dish));
        }
    }
}
