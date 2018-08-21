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

        public List<OrderDetailInfo> GetList()
        {
            return odiDAL.GetList();
        }

        public int AddOrderDetailInfo(OrderDetailInfo odi)
        {
            return odiDAL.InsertCommand(odi);
        }

        public int UpdateOrderDetailInfo(OrderDetailInfo odi)
        {
            return Convert.ToInt32(odiDAL.UpdateCommnad(odi));
        }

        public int DeleteOrderDetailInfo(OrderDetailInfo odi)
        {
            return Convert.ToInt32(odiDAL.DeleteCommand(odi));
        }
    }
}
