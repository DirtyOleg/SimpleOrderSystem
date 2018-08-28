using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class OrderSummaryBLL
    {
        private OrderSummaryDAL osDAL = new OrderSummaryDAL();

        public List<OrderSummary> GetList()
        {
            return osDAL.GetList();
        }

        public int AddOrderInfo(OrderSummary orderSummary)
        {
            return osDAL.InsertCommand(orderSummary);
        }

        public int UpdateOrderInfo(OrderSummary orderSummary)
        {
            return Convert.ToInt32(osDAL.UpdateCommnad(orderSummary));
        }

        public int DeleteOrderInfo(OrderSummary orderSummary)
        {
            return Convert.ToInt32(osDAL.DeleteCommand(orderSummary));
        }
    }
}
