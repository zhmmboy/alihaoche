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
    public class CommentDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(C_Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [C_Comment] (");
            strSql.Append("cId,cParentId,cAuthor,cEmail,cUrl,cContent,cType,cAddTime,cStatus)");
            strSql.Append(" values (");
            strSql.Append("@cId,@cParentId,@cAuthor,@cEmail,@cUrl,@cContent,@cType,@cAddTime,@cStatus)");

            SqlParameter[] parameters = {
					new SqlParameter("@cId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cAuthor", SqlDbType.NVarChar,50),
					new SqlParameter("@cEmail", SqlDbType.VarChar,50),
					new SqlParameter("@cUrl", SqlDbType.VarChar,500),
					new SqlParameter("@cContent", SqlDbType.VarChar,500),
					new SqlParameter("@cType", SqlDbType.Int),
                    new SqlParameter("@cStatus", SqlDbType.Int),
					new SqlParameter("@cAddTime", SqlDbType.DateTime)};

            parameters[0].Value = model.cId;
            parameters[1].Value = model.cParentid;
            parameters[2].Value = model.cAuthor;
            parameters[3].Value = model.cEmail;
            parameters[4].Value = model.cUrl;
            parameters[5].Value = model.cContent;
            parameters[6].Value = model.cType;
            parameters[7].Value = model.cStatus;
            parameters[8].Value = model.cAddTime;

            int rows = 0;
            rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid cId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [C_Comment] ");
            strSql.Append(" where cId=@cId ");
            SqlParameter[] parameters = {
					new SqlParameter("@cId", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = cId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 审核一条数据
        /// </summary>
        public int UpdateStatus(C_Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Comment set ");
            strSql.Append("cStatus=@cStatus");
            strSql.Append(" where cId=@cId ");
            SqlParameter[] parameters = {
					new SqlParameter("@cStatus", SqlDbType.Int),
					new SqlParameter("@cId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = model.cStatus;
            parameters[1].Value = model.cId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition)
        {
            return (new SqlExecute()).ProcessSqlDT("C_Comment", "nid,nIndex,ntitle,ntitlepic,ntips,nclicks,nclass1,cName,cEnName,nauthor,ntime", Condition, Top);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "nid,nform,nformurl,nauthor,ntalks,ntime,cName,cEnName,nclicks,ntitle,ntitlepic, ntips,ncontent,ntags,nlinkurl,nispage,nclass2,nstatus FROM v_GetNews" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
        }
        /// <summary>
        /// 获取资讯列表
        /// </summary>
        /// <param name="Top">指定返回记录的条数</param>
        /// <param name="Fileds">字段名称，*为所有字段</param>
        /// <param name="Where">查询条件</param>
        /// <returns>数据表</returns>
        public DataTable GetList(int Top, string Fileds, string Where)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? (" TOP " + Top) : ("")) + " " + Fileds + " FROM v_GetNews" + (Where != "" ? (" WHERE " + Where) : ("")), null);
        }
        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetNewById(Guid Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT nid,nIndex,nclicks,nform,nformurl,nclass1,nclass2,nauthor,uid,ntime,ntitle,ntitlepic,ncontent,ntags,nisrecommand,ntips,personId,cName,cEnName FROM V_GetNews WHERE Nid='" + Id + "'", null);
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
        /// 获取评论数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataTable GetComment(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "a.status,a.adddate,a.rtid,a.ip,a.content,a.title,a.username,a.uid,a.pid,a.id,b.uimgurl as uimgurl FROM gw_Message a inner join gw_users b on a.uid=b.uid WHERE a.status=1" + (Condition.Trim() != "" ? (" AND " + Condition) : ("")), null);
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
        /// <returns></returns>
        public DataTable GetPaging(string Filter, int CurrentPage, int PageSize, out int totalCount)
        {
            return SqlHelper.GetPaging("V_GetNews", "nId", "nId,nIndex,nTitle,nTips,nTitlePic,cName,cEnName,nTime,nGood,nBad,nClicks,nIsRecommand", Filter, "", "", CurrentPage, PageSize, out totalCount);
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
        public DataTable GetPaging(string Filter, string Sort, string Group, int CurrentPage, int PageSize, out int totalCount)
        {
            return SqlHelper.GetPaging("V_GetNews", "nId", "nId,nIndex,nTitle,nTips,nTitlePic,cName,cEnName,nTime,nGood,nBad,nClicks,nIsRecommand", Filter, Sort, Group, CurrentPage, PageSize, out totalCount);
        }
    }
}
