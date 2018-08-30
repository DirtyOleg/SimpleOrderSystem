using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MemberBLL
    {
        private MemberDAL meDAL = new MemberDAL();

        public List<Member> GetList()
        {
            return meDAL.GetList();
        }

        public Dictionary<int, string> GetDic()
        {
            return meDAL.GetDic();
        }

        public int AddMemberInfo(Member member)
        {
            return meDAL.InsertCommand(member);
        }

        public int UpdateMemberInfo(Member member)
        {
            return Convert.ToInt32(meDAL.UpdateCommnad(member));
        }

        public int DeleteMemberInfo(Member member)
        {
            return Convert.ToInt32(meDAL.DeleteCommand(member));
        }
    }
}
