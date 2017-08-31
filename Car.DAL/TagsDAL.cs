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
    public class TagsDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public TagsDAL() { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(C_Tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Tags(");
            strSql.Append("tName,tAddTime,tIsValid,classId,mainId,tType,newsId)");
            strSql.Append(" values (");
            strSql.Append("@tName,@tAddTime,@tIsValid,@classId,@mainId,@tType,@newsId)");
            SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.NVarChar,50),
					new SqlParameter("@tAddTime", SqlDbType.DateTime),
					new SqlParameter("@tIsValid", SqlDbType.Bit,1),
					new SqlParameter("@classId", SqlDbType.Int),
					new SqlParameter("@mainId", SqlDbType.Int),
					new SqlParameter("@tType", SqlDbType.Int),
                    new SqlParameter("@newsId", SqlDbType.Int)};

            parameters[0].Value = model.tName;
            parameters[1].Value = model.tAddTime;
            parameters[2].Value = model.tIsValid;
            parameters[3].Value = 0;
            parameters[4].Value = 0;
            parameters[5].Value = model.tType;
            parameters[6].Value = model.newsId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(C_Tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Tags set ");
            strSql.Append("tName=@tName,");
            strSql.Append("tAddTime=@tAddTime,");
            strSql.Append("tIsValid=@tIsValid,");
            strSql.Append("classId=@classId,");
            strSql.Append("mainId=@mainId,");
            strSql.Append("tType=@tType");
            strSql.Append(" where tId=@tId ");
            SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.NVarChar,50),
					new SqlParameter("@tAddTime", SqlDbType.DateTime),
					new SqlParameter("@tIsValid", SqlDbType.Bit,1),
					new SqlParameter("@classId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@mainId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@tId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@tType", SqlDbType.Int)};
            parameters[0].Value = model.tName;
            parameters[1].Value = model.tAddTime;
            parameters[2].Value = model.tIsValid;
            parameters[3].Value = model.classId;
            parameters[4].Value = model.mainId;
            parameters[5].Value = model.tId;
            parameters[6].Value = model.tType;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(Guid tId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Tags ");
            strSql.Append(" where tId=@tId ");
            SqlParameter[] parameters = {
					new SqlParameter("@tId", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = tId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string tIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Tags ");
            strSql.Append(" where tId in (" + tIdlist + ")  ");

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            return rows;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[tId],[tName],[tAddTime],[tIsValid],[tClicks],[classId],[mainId],[tType] FROM [dbo].[C_Tags]" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
        }

       
        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="tId">id</param>
        /// <returns>数据</returns>
        public DataTable GetTagById(Guid tId)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT [tId],[tName],[tAddTime],[tIsValid],[classId],[mainId],[tType] FROM [dbo].[C_Tags] WHERE TId='" + tId + "'", null);
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
        /// <param name="Filter">过滤语句，不带Where </param>
        /// <param name="CurrentPage">当前页码</param>
        /// <param name="PageSize">分页尺寸</param>
        /// <returns></returns>
        public DataTable GetPaging(string Filter,string Sort,string Group, int PageSize, int CurrentPage, out int TotalCount)
        {
            return SqlHelper.GetPaging("C_Tags", "tId", "[tId],[tName],[tClicks],[tAddTime]", Filter, Sort, Group, CurrentPage, PageSize, out TotalCount);
        }
    }
}
