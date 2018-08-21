using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtilityLayer;
using CommonUtilityLayer.Model;

namespace DataAccessLayer
{
    public class EmployeeInfoDAL
    {
        public List<EmployeeInfo> GetList()
        {
            //Obtain all the Employee infomation from database
            string sqlCommand = "SELECT EId, EName, EPwd, EPosition FROM [dbo].[EmployeeInfo] WHERE DelFlag <> 'True'";
            DataTable empDataTable = SqlHelper.GetFilledTable(sqlCommand);

            //Obtain data from the filled datatable, and store them into a EmployeeInfo List
            List<EmployeeInfo> EmpList = new List<EmployeeInfo>();
            foreach (DataRow row in empDataTable.Rows)
            {
                EmpList.Add(new EmployeeInfo()
                {
                    EId = Convert.ToInt32(row["EId"]),
                    EName = row["EName"].ToString(),
                    EPwd = row["EPwd"].ToString(),
                    EPosition = row["EPosition"].ToString()
                });
            }

            return EmpList;
        }

        public int InsertCommand(EmployeeInfo emp)
        {
            string sqlCommand = "INSERT INTO EmployeeInfo(EName, EPwd, EPosition) VALUES(@name,@pwd,@position)";
            SqlParameter[] cmdParams = {
                new SqlParameter("@name",emp.EName),
                new SqlParameter("pwd",emp.EPwd),
                new SqlParameter("@position",emp.EPosition)
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

        public object UpdateCommnad(EmployeeInfo emp)
        {
            string sqlCommand = string.Empty;
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (string.IsNullOrEmpty(emp.EPwd))
            {
                //user do not change the password
                sqlCommand = "UPDATE [dbo].[EmployeeInfo] SET [EName]=@name,[EPosition]=@position OUTPUT INSERTED.EId WHERE [EId]=@id";
                sqlParams.Add(new SqlParameter("@id", emp.EId));
                sqlParams.Add(new SqlParameter("@name", emp.EName));
                sqlParams.Add(new SqlParameter("@position", emp.EPosition));
            }
            else
            {
                //user change the password
                sqlCommand = "UPDATE [dbo].[EmployeeInfo] SET [EName]=@name,[EPwd]=@pwd,[EPosition]=@position OUTPUT INSERTED.EId WHERE [EId]=@id";
                sqlParams.Add(new SqlParameter("@id", emp.EId));
                sqlParams.Add(new SqlParameter("@name", emp.EName));
                sqlParams.Add(new SqlParameter("@pwd", emp.EPwd));
                sqlParams.Add(new SqlParameter("@position", emp.EPosition));
            };

            return SqlHelper.ExecuteScalar(sqlCommand, sqlParams.ToArray());
        }

        public object DeleteCommand(EmployeeInfo emp)
        {
            string sqlCommand = "[dbo].[SetDelFlagTrue]";

            SqlParameter[] cmdParams = {
                new SqlParameter("@id", emp.EId),
                new SqlParameter("@tableName","EmployeeInfo")
            };
            return SqlHelper.ExecuteScalar(sqlCommand, cmdParams);
        }
    }
}
