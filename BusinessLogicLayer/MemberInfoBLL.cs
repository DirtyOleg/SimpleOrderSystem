using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MemberInfoBLL
    {
        private MemberInfoDAL miDAL = new MemberInfoDAL();

        public List<MemberInfo> GetList()
        {
            return miDAL.GetList();
        }

        public int AddMemberInfo(MemberInfo member)
        {
            return miDAL.InsertCommand(member);
        }

        public int UpdateMemberInfo(MemberInfo member)
        {
            return Convert.ToInt32(miDAL.UpdateCommnad(member));
        }

        public int DeleteMemberInfo(MemberInfo member)
        {
            return Convert.ToInt32(miDAL.DeleteCommand(member));
        }
    }
}
