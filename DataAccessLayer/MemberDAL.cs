using CommonUtilityLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MemberDAL
    {
        public List<Member> GetList()
        {
            string sqlCommand = @"SELECT MemberId, MemberName, MemberPhone, MemberBalance, MembershipTitle 
                                  FROM [dbo].[Member] as m, [dbo].[Membership] as ms 
                                  WHERE m.DelFlag <> 'true' AND m.MembershipId = ms.MembershipId";
            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);

            List<Member> memberList = new List<Member>();
            foreach (DataRow row in dt.Rows)
            {
                memberList.Add(new Member {
                    MemberId = Convert.ToInt32(row["MemberId"].ToString()),
                    MemberName = row["MemberName"].ToString(),
                    MemberBalance = Convert.ToDecimal(row["MemberBalance"].ToString()),
                    MemberPhone = row["MemberPhone"].ToString(),
                    MembershipType = row["MembershipTitle"].ToString()
                });
            }

            return memberList;
        }

        public Dictionary<int,string> GetDic()
        {   
            string sqlCommand= @"SELECT MembershipId, MembershipTitle
                                 FROM [dbo].[Membership]
                                 WHERE DelFlag <> 'true'";

            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);
            Dictionary<int, string> dic = new Dictionary<int, string>();

            foreach (DataRow row in dt.Rows)
            {
                dic.Add(Convert.ToInt32(row["MembershipId"].ToString()), row["MembershipTitle"].ToString());
            }            

            return dic;
        }

        public int SelectCommand(Member member)
        {
            string sqlCommand = "";
            SqlParameter[] cmdParams = {

            };

            try
            {
                return Convert.ToInt32(SqlHelper.ExecuteScalar(sqlCommand, cmdParams));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }


        public int InsertCommand(Member member)
        {
            string sqlCommand = "";
            SqlParameter[] cmdParams = {
            };

            try
            {
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(sqlCommand, cmdParams));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }


        public object UpdateCommnad(Member member)
        {
            string sqlCommand = "";
            SqlParameter[] cmdParams = {
            };

            try
            {
                return SqlHelper.ExecuteScalar(sqlCommand, cmdParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public object DeleteCommand(Member member)
        {
            string sqlCommand = "[dbo].[SetDelFlagTrue]";

            SqlParameter[] cmdParams = {
            };

            try
            {
                return SqlHelper.ExecuteScalar(sqlCommand, cmdParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
