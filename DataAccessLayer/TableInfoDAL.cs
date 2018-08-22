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
    public class TableInfoDAL
    {
        public List<TableInfo> GetList()
        {
            string sqlCommand = "";
            DataTable dt= SqlHelper.GetFilledTable(sqlCommand);

            List <TableInfo> tableInfoList = new List<TableInfo>();
            foreach (DataRow row in dt.Rows)
            {

            }

            return tableInfoList;
        }


        public int SelectCommand(TableInfo tableInfo)
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


        public int InsertCommand(TableInfo tableInfo)
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


        public object UpdateCommnad(TableInfo tableInfo)
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


        public object DeleteCommand(TableInfo tableInfo)
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
