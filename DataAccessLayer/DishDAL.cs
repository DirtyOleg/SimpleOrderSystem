﻿using CommonUtilityLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DishDAL
    {
        public List<Dish> GetList()
        {
            string sqlCommand = "";
            DataTable dt = SqlHelper.GetFilledTable(sqlCommand);

            List<Dish> dishList = new List<Dish>();
            foreach (DataRow row in dt.Rows)
            {

            }

            return dishList;
        }


        public int SelectCommand(Dish dish)
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


        public int InsertCommand(Dish dish)
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


        public object UpdateCommnad(Dish dish)
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


        public object DeleteCommand(Dish dish)
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
