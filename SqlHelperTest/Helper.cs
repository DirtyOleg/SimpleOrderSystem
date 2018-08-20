using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperTest
{
    public static class Helper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connStr"].ToString();

        public static int ExecuteNonQuery(string sqlCommand, params SqlParameter[] cmdParams)
        {
            int numberOfAffectedLines = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand);
                cmd.Parameters.AddRange(cmdParams);

                conn.Open();
                numberOfAffectedLines = cmd.ExecuteNonQuery();
            }


            return numberOfAffectedLines;
        }

        public static object ExecuteScalar(string sqlCommand,params SqlParameter[] cmdParams)
        {
            object firstCell = null;

            using (SqlConnection conn= new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand);
                cmd.Parameters.AddRange(cmdParams);

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
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, conn);
                adapter.SelectCommand.Parameters.AddRange(cmdParams);
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
