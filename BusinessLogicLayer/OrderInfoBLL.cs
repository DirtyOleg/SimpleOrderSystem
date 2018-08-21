using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class OrderInfoBLL
    {
        private OrderInfoDAL oiDAL = new OrderInfoDAL();

        public List<OrderInfo> GetList()
        {
            return oiDAL.GetList();
        }

        public int AddOrderInfo(OrderInfo order)
        {
            return oiDAL.InsertCommand(order);
        }

        public int UpdateOrderInfo(OrderInfo order)
        {
            return Convert.ToInt32(oiDAL.UpdateCommnad(order));
        }

        public int DeleteOrderInfo(OrderInfo order)
        {
            return Convert.ToInt32(oiDAL.DeleteCommand(order));
        }
    }
}
