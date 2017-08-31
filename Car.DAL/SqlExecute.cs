using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Car.DAL
{
    public class SqlExecute
    {
        public SqlExecute() { }

        /// <summary>
        /// 执行sql语句，返回受影响的行数
        /// </summary>
        /// <param name="stringsql">sql语句</param>
        /// <returns>返回受影响的行数</returns>
        public int RunSql(string stringsql)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, stringsql, null);
        }

        /// <summary>
        /// 查询相关记录
        /// </summary>
        /// <param name="stringsql">sql语句</param>
        /// <returns>返回查询的记录集行数</returns>
        public DataSet ExecuteDataSet(string stringsql)
        {
           return SqlHelper.ExecuteDataSet(CommandType.Text,stringsql,null);
       }/// <summary>
       /// 查询相关记录
       /// </summary>
       /// <param name="stringsql">sql语句</param>
       /// <returns>返回查询的记录集行数</returns>
       public DataTable ExecuteDataTable(string stringsql)
       {
           return SqlHelper.ExecuteDataTable(CommandType.Text, stringsql, null);
       }

        /// <summary>
        /// 查询相关记录
        /// </summary>
        /// <param name="_EN_bj_brand">记录实体</param>
        /// <returns>返回受影响的行数</returns>
        public DataSet ProcessSql(string tablename, string fields, string condition, int toprows)
        {
            SqlParameter[] sqlParams = 
                {   new SqlParameter("@tablename", SqlDbType.NVarChar),
                    new SqlParameter("@fields", SqlDbType.NVarChar), 
                    new SqlParameter("@condition", SqlDbType.NVarChar),
                    new SqlParameter("@toprows", SqlDbType.Int) };
            sqlParams[0].Value = tablename;
            sqlParams[1].Value = fields;
            sqlParams[2].Value = condition;
            sqlParams[3].Value = toprows;
            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "P_QueryBySql", sqlParams);
        }

        /// <summary>
        /// 查询相关记录
        /// </summary>
        /// <param name="_EN_bj_brand">记录实体</param>
        /// <returns>返回受影响的行数</returns>
        public DataTable ProcessSqlDT(string tablename, string fields, string condition, int toprows)
        {
            SqlParameter[] sqlParams = 
                {   new SqlParameter("@tablename", SqlDbType.NVarChar),
                    new SqlParameter("@fields", SqlDbType.NVarChar), 
                    new SqlParameter("@condition", SqlDbType.NVarChar),
                    new SqlParameter("@toprows", SqlDbType.Int) };
            sqlParams[0].Value = tablename;
            sqlParams[1].Value = fields;
            sqlParams[2].Value = condition;
            sqlParams[3].Value = toprows;
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "P_QueryBySql", sqlParams);
        }
        /// <summary>
        /// 查询相关记录
        /// </summary>
        /// <param name="_EN_bj_brand">记录实体</param>
        /// <returns>返回受影响的行数</returns>
        public DataSet selectModelclass(string tablename, string fields, string condition, int toprows)
        {
            SqlParameter[] sqlParams = 
                {   new SqlParameter("@tablename", SqlDbType.NVarChar),
                    new SqlParameter("@fields", SqlDbType.NVarChar), 
                    new SqlParameter("@condition", SqlDbType.NVarChar),
                    new SqlParameter("@toprows", SqlDbType.Int) };
            sqlParams[0].Value = tablename;
            sqlParams[1].Value = fields;
            sqlParams[2].Value = condition;
            sqlParams[3].Value = toprows;
            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "P_QueryBySql", sqlParams);
        }

        /// <summary>
        /// 查询相关记录
        /// </summary>
        /// <param name="_EN_bj_brand">记录实体</param>
        /// <returns>返回受影响的行数</returns>
        public DataTable GetDTBySql(string tablename, string fields, string condition, int toprows)
        {
            SqlParameter[] sqlParams = 
                {   new SqlParameter("@tablename", SqlDbType.NVarChar),
                    new SqlParameter("@fields", SqlDbType.NVarChar), 
                    new SqlParameter("@condition", SqlDbType.NVarChar),
                    new SqlParameter("@toprows", SqlDbType.Int) };
            sqlParams[0].Value = tablename;
            sqlParams[1].Value = fields;
            sqlParams[2].Value = condition;
            sqlParams[3].Value = toprows;
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "P_QueryBySql", sqlParams);
        }
        /**
            1.Tables :表名称,视图
            2.PrimaryKey :主关键字
            3.Sort :排序语句，不带Order By 比如：NewsID Desc,OrderRows Asc
            4.CurrentPage :当前页码
            5.PageSize :分页尺寸
            6.Filter :过滤语句，不带Where 
            7.Group :Group语句,不带Group By
         **/
        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetPaging(string TabName, string PrimaryKey, string Fields, string Filter, string Sort, string Group, int CurrentPage, int PageSize)
        {
            SqlParameter[] Params= {
                             new SqlParameter("@Tables",SqlDbType.VarChar,1000),
                             new SqlParameter("@PrimaryKey",SqlDbType.VarChar,100),
                             new SqlParameter("@Filter",SqlDbType.VarChar,1000),
                             new SqlParameter("@Sort",SqlDbType.VarChar,200),
                             new SqlParameter("@Group",SqlDbType.VarChar,1000),
                             new SqlParameter("@CurrentPage",SqlDbType.Int),
                             new SqlParameter("@PageSize",SqlDbType.Int),
                             new SqlParameter("@Fields",SqlDbType.VarChar,1000)
                             };

            Params[0].Value = TabName;
            Params[1].Value = PrimaryKey;
            Params[2].Value = Filter;
            Params[3].Value = Sort;
            Params[4].Value = Group;
            Params[5].Value = CurrentPage;
            Params[6].Value = PageSize;
            Params[7].Value = Fields;
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "P_Paging", Params);
        }

        /// <summary>
        /// 根据条件获取符合条件的数据记录数
        /// </summary>
        /// <param name="TabName"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public int GetRowCount(string TabName, string Filter)
        {
            object o = SqlHelper.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM "+TabName+(Filter.Trim()!=""?(" WHERE "+Filter):""), null);
            if (o != null)
            {
                return Convert.ToInt32(o);
            } return 0;
        }
    }
}
