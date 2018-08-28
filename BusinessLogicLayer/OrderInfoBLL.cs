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

        public List<OrderSummary> GetList()
        {
            return oiDAL.GetList();
        }

        public int AddOrderInfo(OrderSummary order)
        {
            return oiDAL.InsertCommand(order);
        }

        public int UpdateOrderInfo(OrderSummary order)
        {
            return Convert.ToInt32(oiDAL.UpdateCommnad(order));
        }

        public int DeleteOrderInfo(OrderSummary order)
        {
            return Convert.ToInt32(oiDAL.DeleteCommand(order));
        }
    }
}
