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
    public class AnswerDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public AnswerDAL() { }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_C_Answer"></param>
        /// <returns></returns>
        public int Add(C_Answer _C_Answer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [C_Answer] (");
            strSql.Append("aId,aAddTime,aContent,qId,aGood,aBad,aNickName,aEmail)");
            strSql.Append(" values (");
            strSql.Append("@aId,@aAddTime,@aContent,@qId,@aGood,@aBad,@aNickName,@aEmail)");

            SqlParameter[] parameters = {
					new SqlParameter("@aId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aAddTime", SqlDbType.DateTime),
					new SqlParameter("@aContent", SqlDbType.NVarChar,500),
					new SqlParameter("@qId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aGood", SqlDbType.Int,4),
					new SqlParameter("@aBad", SqlDbType.Int,4),
					new SqlParameter("@aNickName", SqlDbType.NVarChar,50),
					new SqlParameter("@aEmail", SqlDbType.NVarChar,50)};

            parameters[0].Value = _C_Answer.aId;
            parameters[1].Value = _C_Answer.aAddTime;
            parameters[2].Value = _C_Answer.aContent;
            parameters[3].Value = _C_Answer.qId;
            parameters[4].Value = _C_Answer.aGood;
            parameters[5].Value = _C_Answer.aBad;
            parameters[6].Value = _C_Answer.aNickName;
            parameters[7].Value = _C_Answer.aEmail;

            int rows = 0;
            rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int Edit(C_Answer _C_Answer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [C_Answer] SET aContent=@aContent,aNickName=@aNickName,aEmail=@aEmail where aId=@aId");

            SqlParameter[] parameters = {
					new SqlParameter("@aId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aContent", SqlDbType.NVarChar,500),
					new SqlParameter("@aNickName", SqlDbType.NVarChar,50),
					new SqlParameter("@aEmail", SqlDbType.NVarChar,50)};

            parameters[0].Value = _C_Answer.aId;
            parameters[1].Value = _C_Answer.aContent;
            parameters[2].Value = _C_Answer.aNickName;
            parameters[3].Value = _C_Answer.aEmail;

            int rows = 0;
            rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[aId],[aContent],[aEmail],[aNickName],[aAddTime] FROM [dbo].[C_Answer]" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public object Delete(Guid guid)
        {
            SqlParameter[] sqlParam = { 
                                          new SqlParameter("@Id", SqlDbType.UniqueIdentifier) 
                                      };

            sqlParam[0].Value = guid;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "Delete From C_Answer WHERE aId=@Id", sqlParam);
            return rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataTable GetPaging(string Filter,string Sort,string Group,int CurrentPage,int PageSize, out int totalCount)
        {
            return SqlHelper.GetPaging("V_GetAnswerList", "aId", "aId,aContent,aGood,aBad,aAddTime,qId,qTitle,pPhoto,pCnName,pEnName", Filter, Sort, Group, CurrentPage, PageSize, out totalCount);
        }
    }
}
