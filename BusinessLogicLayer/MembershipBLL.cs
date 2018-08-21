using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MembershipBLL
    {
        private MembershipDAL msDAL = new MembershipDAL();

        public List<Membership> GetList()
        {
            return msDAL.GetList();
        }

        public int AddMembership(Membership membership)
        {
            return msDAL.InsertCommand(membership);
        }

        public int UpdateMembership(Membership membership)
        {
            return Convert.ToInt32(msDAL.UpdateCommnad(membership));
        }

        public int DeleteMembership(Membership membership)
        {
            return Convert.ToInt32(msDAL.DeleteCommand(membership));
        }
    }
}
