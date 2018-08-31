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
        public void GetList(out List<Member> memberList, out Dictionary<int, string> membershipDic)
        {
            //initialize Dictionary<int, string> membershipDic
            string sqlCommand = @"SELECT MembershipId, MembershipTitle
                                 FROM [dbo].[Membership]
                                 WHERE DelFlag <> 'true'";
            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);

            membershipDic = new Dictionary<int, string>();
            foreach (DataRow row in dt.Rows)
            {
                membershipDic.Add(Convert.ToInt32(row["MembershipId"].ToString()), row["MembershipTitle"].ToString());
            }

            //initialize List<Member> memberList
            sqlCommand = @"SELECT MemberId, MemberName, MemberPhone, MemberBalance, MembershipId 
                                  FROM [dbo].[Member]
                                  WHERE DelFlag <> 'true'";
            dt = SqlHelper.GetFilledTable(sqlCommand);

            memberList = new List<Member>();
            foreach (DataRow row in dt.Rows)
            {
                memberList.Add(new Member
                {
                    MemberId = Convert.ToInt32(row["MemberId"].ToString()),
                    MemberName = row["MemberName"].ToString(),
                    MemberBalance = Convert.ToDecimal(row["MemberBalance"].ToString()),
                    MemberPhone = row["MemberPhone"].ToString(),
                    MembershipId = Convert.ToInt32(row["MembershipId"].ToString()),
                    MembershipTitle = membershipDic[Convert.ToInt32(row["MembershipId"].ToString())]
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public List<int> SelectCommand(Member member)
        {
            string sqlCommand = "SELECT MemberId " +
                                "FROM [dbo].[Member] " +
                                "WHERE MemberName LIKE @name AND MemberPhone LIKE @phone AND DelFlag <> 'True'";
            SqlParameter[] cmdParams = {
                new SqlParameter("@name",String.Format($"%{member.MemberName}%")),
                new SqlParameter("@phone",String.Format($"%{member.MemberPhone}%"))
            };

            DataTable dt = new DataTable();
            List<int> idList = new List<int>();

            try
            {
                dt = SqlHelper.GetFilledTable(sqlCommand, cmdParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                foreach (DataRow row in dt.Rows)
                {
                    idList.Add(Convert.ToInt32(row["MemberId"].ToString()));
                }
            }

            return idList;
        }


        public int InsertCommand(Member member)
        {
            string sqlCommand = "INSERT INTO [dbo].[Member](MemberName, MemberPhone, MemberBalance, MembershipId) VALUES(@name,@phone,@balance,@membershipId)";
            SqlParameter[] cmdParams = {
                new SqlParameter("@name",member.MemberName),
                new SqlParameter("@phone",member.MemberPhone),
                new SqlParameter("@balance",member.MemberBalance),
                new SqlParameter("@membershipId",member.MembershipId)
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
            string sqlCommand = @"UPDATE [dbo].[Member] 
                                  SET MemberName=@name, MemberPhone=@phone, MemberBalance=@balance, MembershipId=@membershipId
                                  OUTPUT INSERTED.MemberId
                                  WHERE MemberId=@id";
            SqlParameter[] cmdParams = {
                new SqlParameter("@name",member.MemberName),
                new SqlParameter("@phone",member.MemberPhone),
                new SqlParameter("@balance",member.MemberBalance),
                new SqlParameter("@membershipId",member.MembershipId),
                new SqlParameter("@id",member.MemberId)
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
                new SqlParameter("@id",member.MemberId),
                new SqlParameter("tableName","Member")
            };

            try
            {
                return SqlHelper.ExecuteScalar(sqlCommand, cmdParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
