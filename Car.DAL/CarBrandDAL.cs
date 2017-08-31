using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Entity;

namespace Car.DAL
{
    public class CarBrandDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public CarBrandDAL() { }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_C_CarBrand"></param>
        /// <returns></returns>
        public int Add(C_CarBrand _C_CarBrand)
        {
            return 0;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int Edit(C_CarBrand _C_CarBrand)
        {
            return 0;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[cbId],[cbName],[cbFirstChar],[cbEnName],[cbParentId],[cbOrderIndex] FROM [dbo].[C_CarBrand]" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string Sql)
        {
            return SqlHelper.ExecuteDataSet(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string Sql)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, sql, null);
        }
    }
}
