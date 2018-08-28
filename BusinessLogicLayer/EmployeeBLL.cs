using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeBLL
    {
        private EmployeeDAL emDAL = new EmployeeDAL();

        public List<Employee> GetList()
        {
            return emDAL.GetList();
        }

        /// <summary>
        /// Add new employee to the database
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int AddNewEmployeeInfo(Employee emp)
        {
            return emDAL.CommandForAddNewEmployee(emp);
        }

        /// <summary>
        /// Update an existed employee information
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The ID of the employee, whose infomation had been modified.</returns>
        public int UpdateEmployeeInfo(Employee emp)
        {
            return Convert.ToInt32(emDAL.CommnadForUpdateEmployeeInfo(emp));
        }

        /// <summary>
        /// "Delete" an existed employee information
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The ID of the employee, whose infomation had been modified.</returns>
        public int DeleteEmployeeInfo(Employee emp)
        {
            return Convert.ToInt32(emDAL.CommandForDeleteEmployeeInfo(emp));
        }

        /// <summary>
        /// Based on input EId and EPwd, check if the user is valid
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool EmployeeLogin(Employee emp)
        {
            return emDAL.CommandForLogin(emp) == null ? false : true;
        }
    }
}
