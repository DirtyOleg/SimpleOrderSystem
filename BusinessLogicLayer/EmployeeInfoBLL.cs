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
    public class EmployeeInfoBLL
    {
        private EmployeeInfoDAL miDAL = new EmployeeInfoDAL();

        public List<EmployeeInfo> GetList()
        {
            return miDAL.GetList();
        }

        /// <summary>
        /// Add new employee to the database
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int AddNewEmployeeInfo(EmployeeInfo emp)
        {
            return miDAL.InsertCommand(emp);
        }

        /// <summary>
        /// Update an existed employee information
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The ID of the employee, whose infomation had been modified.</returns>
        public int UpdateEmployeeInfo(EmployeeInfo emp)
        {
            return Convert.ToInt32(miDAL.UpdateCommnad(emp));
        }

        /// <summary>
        /// "Delete" an existed employee information
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>The ID of the employee, whose infomation had been modified.</returns>
        public int DeleteEmployeeInfo(EmployeeInfo emp)
        {
            return Convert.ToInt32(miDAL.DeleteCommand(emp));
        }

        /// <summary>
        /// Based on input EId and EPwd, check if the user is valid
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool EmployeeLogin(EmployeeInfo emp)
        {
            return miDAL.SelectCommand(emp) > 0 ? true : false;
        }
    }
}
