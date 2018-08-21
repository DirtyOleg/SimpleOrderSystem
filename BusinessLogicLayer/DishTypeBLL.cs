using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DishTypeBLL
    {
        private DishTypeDAL dtDAL = new DishTypeDAL();

        public List<DishType> GetList()
        {
            return dtDAL.GetList();
        }

        public int AddDishType(DishType dt)
        {
            return dtDAL.InsertCommand(dt);
        }

        public int UpdateDishType(DishType dt)
        {
            return Convert.ToInt32(dtDAL.UpdateCommnad(dt));
        }

        public int DeleteDishType(DishType dt)
        {
            return Convert.ToInt32(dtDAL.DeleteCommand(dt));
        }
    }
}
