using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TablesBLL
    {
        private TablesDAL taDAL = new TablesDAL();

        public List<Tables> GetList()
        {
            return taDAL.GetList();
        }

        public int AddTableInfo(Tables table)
        {
            return taDAL.InsertCommand(table);
        }

        public int UpdateTableInfo(Tables table)
        {
            return Convert.ToInt32(taDAL.UpdateCommnad(table));
        }

        public int DeleteTableInfo(Tables table)
        {
            return Convert.ToInt32(taDAL.DeleteCommand(table));
        }
    }
}
