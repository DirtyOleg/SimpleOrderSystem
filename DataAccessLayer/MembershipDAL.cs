using CommonUtilityLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MembershipDAL
    {
        public List<Membership> GetList()
        {
            string sqlCommand = "SELECT MembershipId, MembershipTitle, DiscountType, DelFlag FROM [dbo].[Membership] WHERE DelFlag <> 'True'";
            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);

            List<Membership> membershipList = new List<Membership>();
            foreach (DataRow row in dt.Rows)
            {
                membershipList.Add(new Membership
                {
                    MembershipId = Convert.ToInt16(row["MembershipId"]),
                    MembershipTitle = row["MembershipTitle"].ToString(),
                    DiscountType = Convert.ToDecimal(row["DiscountType"])
                });
            }

            return membershipList;
        }
        
        public int SelectCommand(Membership membership)
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
        
        public int InsertCommand(Membership membership)
        {
            string sqlCommand = "INSERT INTO [dbo].[Membership](MembershipTitle, DiscountType) VALUES(@title,@discount)";
            SqlParameter[] cmdParams = {
                new SqlParameter("@title",membership.MembershipTitle),
                new SqlParameter("@discount",membership.DiscountType)
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
        
        public object UpdateCommnad(Membership membership)
        {
            //[dbo].[Membership] MembershipId, MembershipTitle, DiscountType
            string sqlCommand = "UPDATE [dbo].[Membership] SET MembershipTitle=@title, DiscountType=@discount OUTPUT INSERTED.MembershipId WHERE MembershipId=@id";
            SqlParameter[] cmdParams = {
                new SqlParameter("@title",membership.MembershipTitle),
                new SqlParameter("@discount",membership.DiscountType),
                new SqlParameter("@id",membership.MembershipId)
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
        
        public object DeleteCommand(Membership membership)
        {
            string sqlCommand = "[dbo].[SetDelFlagTrue]";

            SqlParameter[] cmdParams = {
                new SqlParameter("@id",membership.MembershipId),
                new SqlParameter("@tableName","Membership")
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
