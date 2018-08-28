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
    public class EmployeeDAL
    {
        public List<Employee> GetList()
        {
            //Obtain all the Employee infomation from database
            string sqlCommand = "SELECT EmployeeId, EmployeeName, EmployeePwd, EmployeePosition FROM [dbo].[Employee] WHERE DelFlag <> 'True'";
            DataTable empDataTable = SqlHelper.GetFilledTable(sqlCommand);

            //Obtain data from the filled datatable, and store them into a EmployeeInfo List
            List<Employee> EmpList = new List<Employee>();
            foreach (DataRow row in empDataTable.Rows)
            {
                EmpList.Add(new Employee()
                {
                    EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                    EmployeeName = row["EmployeeName"].ToString(),
                    EmployeePwd = row["EmployeePwd"].ToString(),
                    EmployeePosition = row["EmployeePosition"].ToString()
                });
            }

            return EmpList;
        }

        /// <summary>
        /// Search one specific employee based on EId and EPwd
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The EmployeeInfo instance with EId, EPwd and EPosition</returns>
        public Employee CommandForLogin(Employee emp)
        {
            string sqlCommand = "SELECT EmployeePosition FROM [dbo].[Employee] WHERE EmployeeId=@EmployeeId AND EmployeePwd=@EmployeePwd AND DelFlag = 'False' "; SqlParameter[] cmdParams = {
                new SqlParameter("@EmployeeId", emp.EmployeeId),
                new SqlParameter("@EmployeePwd", emp.EmployeePwd)
            };

            try
            {
                string EmployeePosition = SqlHelper.ExecuteScalar(sqlCommand, cmdParams).ToString();

                if (!string.IsNullOrEmpty(EmployeePosition))
                {
                    emp.EmployeePosition = EmployeePosition;
                    return emp; 
                }
                else
                {
                    return null;
                }                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Add a new employee based on EName, EPwd, EPosition
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The Number of affected line</returns>
        public int CommandForAddNewEmployee(Employee emp)
        {
            string sqlCommand = "INSERT INTO Employee(EmployeeName, EmployeePwd, EmployeePosition) VALUES(@name,@pwd,@position)";
            SqlParameter[] cmdParams = {
                new SqlParameter("@name",emp.EmployeeName),
                new SqlParameter("@pwd",emp.EmployeePwd),
                new SqlParameter("@position",emp.EmployeePosition)
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

        /// <summary>
        /// Update a employee information based on EId, EName, EPosition
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The EId of the employee</returns>
        public object CommnadForUpdateEmployeeInfo(Employee emp)
        {
            string sqlCommand = string.Empty;
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (string.IsNullOrEmpty(emp.EmployeePwd))
            {
                //user do not change the password
                sqlCommand = "UPDATE [dbo].[Employee] SET [EmployeeName]=@name,[EmployeePosition]=@position OUTPUT INSERTED.EmployeeId WHERE [EmployeeId]=@id";
                sqlParams.Add(new SqlParameter("@id", emp.EmployeeId));
                sqlParams.Add(new SqlParameter("@name", emp.EmployeeName));
                sqlParams.Add(new SqlParameter("@position", emp.EmployeePosition));
            }
            else
            {
                //user change the password
                sqlCommand = "UPDATE [dbo].[Employee] SET [EmployeeName]=@name,[EmployeePwd]=@pwd,[EmployeePosition]=@position OUTPUT INSERTED.EmployeeId WHERE [EmployeeId]=@id";
                sqlParams.Add(new SqlParameter("@id", emp.EmployeeId));
                sqlParams.Add(new SqlParameter("@name", emp.EmployeeName));
                sqlParams.Add(new SqlParameter("@pwd", emp.EmployeePwd));
                sqlParams.Add(new SqlParameter("@position", emp.EmployeePosition));
            };

            try
            {
                return SqlHelper.ExecuteScalar(sqlCommand, sqlParams.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }            
        }

        /// <summary>
        /// Set the DelFlag true
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The EId of the employee</returns>
        public object CommandForDeleteEmployeeInfo(Employee emp)
        {
            string sqlCommand = "[dbo].[SetDelFlagTrue]";

            SqlParameter[] cmdParams = {
                new SqlParameter("@id", emp.EmployeeId),
                new SqlParameter("@tableName","Employee")
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
