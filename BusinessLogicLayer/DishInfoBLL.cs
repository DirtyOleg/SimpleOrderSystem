using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DishInfoBLL
    {
        private DishInfoDAL diDAL = new DishInfoDAL();

        public List<DishInfo> GetList()
        {
            return diDAL.GetList();
        }
        
        public int AddDishInfo(DishInfo dish)
        {
            return diDAL.InsertCommand(dish);
        }

        public int UpdateDishInfo(DishInfo dish)
        {
            return Convert.ToInt32(diDAL.UpdateCommnad(dish));
        }

        public int DeleteDishInfo(DishInfo dish)
        {
            return Convert.ToInt32(diDAL.DeleteCommand(dish));
        }
    }
}
