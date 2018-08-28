using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class OrderDetailBLL
    {
        private OrderDetailDAL odDAL = new OrderDetailDAL();

        public List<OrderDetail> GetList()
        {
            return odDAL.GetList();
        }

        public int AddOrderDetailInfo(OrderDetail od)
        {
            return odDAL.InsertCommand(od);
        }

        public int UpdateOrderDetailInfo(OrderDetail od)
        {
            return Convert.ToInt32(odDAL.UpdateCommnad(od));
        }

        public int DeleteOrderDetailInfo(OrderDetail od)
        {
            return Convert.ToInt32(odDAL.DeleteCommand(od));
        }
    }
}
