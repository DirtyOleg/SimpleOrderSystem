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
    public class OrderInfoDAL
    {
        public DataTable DataTable { get; private set; }

        public List<OrderInfo> GetList()
        {
            string sqlCommand = "";
            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);

            List<OrderInfo> orderInfoList = new List<OrderInfo>();
            foreach (DataRow row in dt.Rows)
            {

            }

            return orderInfoList;
        }


        public int SelectCommand(OrderInfo orderInfo)
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


        public int InsertCommand(OrderInfo orderInfo)
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


        public object UpdateCommnad(OrderInfo orderInfo)
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


        public object DeleteCommand(OrderInfo orderInfo)
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
