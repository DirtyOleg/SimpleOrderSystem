using CommonUtilityLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TableInfoBLL
    {
        private TableInfoDAL diDAL = new TableInfoDAL();

        public List<TableInfo> GetList()
        {
            return diDAL.GetList();
        }

        public int AddTableInfo(TableInfo table)
        {
            return diDAL.InsertCommand(table);
        }

        public int UpdateTableInfo(TableInfo table)
        {
            return Convert.ToInt32(diDAL.UpdateCommnad(table));
        }

        public int DeleteTableInfo(TableInfo table)
        {
            return Convert.ToInt32(diDAL.DeleteCommand(table));
        }
    }
}
