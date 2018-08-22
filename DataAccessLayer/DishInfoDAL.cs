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
    public class DishInfoDAL
    {
        public List<DishInfo> GetList()
        {
            string sqlCommand = "";
            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);

            List<DishInfo> dishInfoList = new List<DishInfo>();
            foreach (DataRow row in dt.Rows)
            {

            }

            return dishInfoList;
        }


        public int SelectCommand(DishInfo dishInfo)
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


        public int InsertCommand(DishInfo dishInfo)
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


        public object UpdateCommnad(DishInfo dishInfo)
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


        public object DeleteCommand(DishInfo dishInfo)
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
