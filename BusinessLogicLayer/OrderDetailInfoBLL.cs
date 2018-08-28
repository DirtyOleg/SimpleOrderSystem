using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class OrderDetailInfoBLL
    {
        private OrderDetailInfoDAL odiDAL = new OrderDetailInfoDAL();

        public List<OrderDetail> GetList()
        {
            return odiDAL.GetList();
        }

        public int AddOrderDetailInfo(OrderDetail odi)
        {
            return odiDAL.InsertCommand(odi);
        }

        public int UpdateOrderDetailInfo(OrderDetail odi)
        {
            return Convert.ToInt32(odiDAL.UpdateCommnad(odi));
        }

        public int DeleteOrderDetailInfo(OrderDetail odi)
        {
            return Convert.ToInt32(odiDAL.DeleteCommand(odi));
        }
    }
}
