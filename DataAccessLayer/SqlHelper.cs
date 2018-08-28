using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CommonUtilityLayer.Model;

namespace DataAccessLayer
{
    public static class SqlHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connStr"].ToString();

        public static int ExecuteNonQuery(string sqlCommand, params SqlParameter[] cmdParams)
        {
            int numberOfAffectedLines = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                cmd.Parameters.AddRange(cmdParams);

                conn.Open();
                numberOfAffectedLines = cmd.ExecuteNonQuery();
            }

            return numberOfAffectedLines;
        }

        public static object ExecuteScalar(string sqlCommand, params SqlParameter[] cmdParams)
        {
            object firstCell = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                cmd.Parameters.AddRange(cmdParams);

                if (!(sqlCommand.Contains("SELECT") || sqlCommand.Contains("INSERT") || sqlCommand.Contains("UPDATE")))
                {
                    //there is a stored procedure for soft delete
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }

                conn.Open();
                firstCell = cmd.ExecuteScalar();
            }

            return firstCell;
        }

        public static DataTable GetFilledTable(string sqlCommand, params SqlParameter[] cmdParams)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, conn))
                {
                    adapter.SelectCommand.Parameters.AddRange(cmdParams);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}
