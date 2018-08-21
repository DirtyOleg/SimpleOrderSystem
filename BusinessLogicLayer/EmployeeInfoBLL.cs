using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
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
        /// 
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>Delete an existed employee information. NOTE: this is soft deletion</returns>
        public int DeleteEmployeeInfo(EmployeeInfo emp)
        {
           return Convert.ToInt32(miDAL.DeleteCommand(emp));
        }
    }
}
