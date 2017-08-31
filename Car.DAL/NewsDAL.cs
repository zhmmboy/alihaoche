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
    public class NewsDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public NewsDAL() { }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(C_News model)
        {
            SqlParameter[] sqlParams ={ 
                new SqlParameter("@nform",SqlDbType.NVarChar,50),
                new SqlParameter("@nauthor",SqlDbType.NVarChar,30),
                new SqlParameter("@ntitle",SqlDbType.NVarChar,100),
                new SqlParameter("@ntitlepic",SqlDbType.NVarChar,200),
                new SqlParameter("@ntips",SqlDbType.NVarChar,500),
                new SqlParameter("@ncontent",SqlDbType.NText),
                new SqlParameter("@ntags",SqlDbType.NVarChar,100),
                new SqlParameter("@nispage",SqlDbType.Bit),
                new SqlParameter("@nclass1",SqlDbType.Int),//一级分类
                new SqlParameter("@nclass2",SqlDbType.Int),//二级分类
                new SqlParameter("@nlevel",SqlDbType.Int),//新闻优先级别
                new SqlParameter("@carId",SqlDbType.Int),
                new SqlParameter("@nformurl",SqlDbType.NVarChar,500),
                new SqlParameter("@nIsRecommand",SqlDbType.Bit),
                new SqlParameter("@ntitleseo",SqlDbType.NVarChar,100),

            };

            sqlParams[0].Value = model.nForm;
            sqlParams[1].Value = model.nAuthor;
            sqlParams[2].Value = model.nTitle;
            sqlParams[3].Value = model.nTitlepic;
            sqlParams[4].Value = model.nTips;
            sqlParams[5].Value = model.nContent;
            sqlParams[6].Value = model.nTags;
            sqlParams[7].Value = model.nIsPage;
            sqlParams[8].Value = model.nclass1;
            sqlParams[9].Value = model.nClass2;
            sqlParams[10].Value = model.nLevel;
            sqlParams[11].Value = model.carId;
            sqlParams[12].Value = model.nFormurl;
            sqlParams[13].Value = model.nIsRecommand;
            sqlParams[14].Value = model.nTitleSeo;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_Car_AddNews", sqlParams);
            return count;
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTemp(C_News model)
        {
            SqlParameter[] sqlParams ={
                new SqlParameter("@nform",SqlDbType.NVarChar,50),
                new SqlParameter("@nauthor",SqlDbType.NVarChar,30),
                new SqlParameter("@ntitle",SqlDbType.NVarChar,100),
                new SqlParameter("@ntitlepic",SqlDbType.NVarChar,200),
                new SqlParameter("@ntips",SqlDbType.NVarChar,500),
                new SqlParameter("@ncontent",SqlDbType.NText),
                new SqlParameter("@ntags",SqlDbType.NVarChar,100),
                new SqlParameter("@nispage",SqlDbType.Bit),
                new SqlParameter("@nclass1",SqlDbType.Int),//一级分类
                new SqlParameter("@nclass2",SqlDbType.Int),//二级分类
                new SqlParameter("@nlevel",SqlDbType.Int),//新闻优先级别
                new SqlParameter("@carId",SqlDbType.Int),
                new SqlParameter("@nformurl",SqlDbType.NVarChar,500),
                new SqlParameter("@ntitleseo",SqlDbType.NVarChar,100)

            };
            sqlParams[0].Value = model.nForm;
            sqlParams[1].Value = model.nAuthor;
            sqlParams[2].Value = model.nTitle;
            sqlParams[3].Value = model.nTitlepic;
            sqlParams[4].Value = model.nTips;
            sqlParams[5].Value = model.nContent;
            sqlParams[6].Value = model.nTags;
            sqlParams[7].Value = model.nIsPage;
            sqlParams[8].Value = model.nclass1;
            sqlParams[9].Value = model.nClass2;
            sqlParams[10].Value = model.nLevel;
            sqlParams[11].Value = model.carId;
            sqlParams[12].Value = model.nFormurl;
            sqlParams[13].Value = model.nTitleSeo;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_Car_AddNewsTemp", sqlParams);
            return count;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditTemp(C_News model)
        {
            SqlParameter[] sqlParams ={
                new SqlParameter("@nform",SqlDbType.NVarChar,30),
                new SqlParameter("@nauthor",SqlDbType.NVarChar,30),
                new SqlParameter("@ntitle",SqlDbType.NVarChar,100),
                new SqlParameter("@ntitlepic",SqlDbType.NVarChar,200),
                new SqlParameter("@ntips",SqlDbType.NVarChar,500),
                new SqlParameter("@ncontent",SqlDbType.NText),
                new SqlParameter("@ntags",SqlDbType.NVarChar,100),
                new SqlParameter("@nlinkurl",SqlDbType.NVarChar,100),
                new SqlParameter("@nispage",SqlDbType.Bit),
                new SqlParameter("@nclass1",SqlDbType.Int),
                new SqlParameter("@nclass2",SqlDbType.SmallInt),
                new SqlParameter("@nid",SqlDbType.Int),
                new SqlParameter("@nlevel",SqlDbType.TinyInt),
                new SqlParameter("@nformurl",SqlDbType.NVarChar,500),
                new SqlParameter("@nStatus",SqlDbType.TinyInt),
                new SqlParameter("@nIsRecommand",SqlDbType.Bit),
                new SqlParameter("@ntitleseo",SqlDbType.NVarChar,100)

            };
            sqlParams[0].Value = model.nForm;
            sqlParams[1].Value = model.nAuthor;
            sqlParams[2].Value = model.nTitle;
            sqlParams[3].Value = model.nTitlepic;
            sqlParams[4].Value = model.nTips;
            sqlParams[5].Value = model.nContent;
            sqlParams[6].Value = model.nTags;
            sqlParams[7].Value = model.nLinkurl;
            sqlParams[8].Value = model.nIsPage;
            sqlParams[9].Value = model.nclass1;
            sqlParams[10].Value = model.nClass2;
            sqlParams[11].Value = model.nId;
            sqlParams[12].Value = model.nLevel;
            sqlParams[13].Value = model.nFormurl;
            sqlParams[14].Value = model.nStatus;
            sqlParams[15].Value = model.nIsRecommand;
            sqlParams[16].Value = model.nTitleSeo;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_Car_EditNewsTemp", sqlParams);
            return count;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(C_News model)
        {
            SqlParameter[] sqlParams ={ 
                new SqlParameter("@nform",SqlDbType.NVarChar,30),
                new SqlParameter("@nauthor",SqlDbType.NVarChar,30),
                new SqlParameter("@ntitle",SqlDbType.NVarChar,100),
                new SqlParameter("@ntitlepic",SqlDbType.NVarChar,200),
                new SqlParameter("@ntips",SqlDbType.NVarChar,500),
                new SqlParameter("@ncontent",SqlDbType.NText),
                new SqlParameter("@ntags",SqlDbType.NVarChar,100),
                new SqlParameter("@nlinkurl",SqlDbType.NVarChar,100),
                new SqlParameter("@nispage",SqlDbType.Bit),
                new SqlParameter("@nclass1",SqlDbType.Int),
                new SqlParameter("@nclass2",SqlDbType.SmallInt),
                new SqlParameter("@nid",SqlDbType.Int),  
                new SqlParameter("@nlevel",SqlDbType.TinyInt),
                new SqlParameter("@nformurl",SqlDbType.NVarChar,500),
                new SqlParameter("@ntitleseo",SqlDbType.NVarChar,100)

            };
            sqlParams[0].Value = model.nForm;
            sqlParams[1].Value = model.nAuthor;
            sqlParams[2].Value = model.nTitle;
            sqlParams[3].Value = model.nTitlepic;
            sqlParams[4].Value = model.nTips;
            sqlParams[5].Value = model.nContent;
            sqlParams[6].Value = model.nTags;
            sqlParams[7].Value = model.nLinkurl;
            sqlParams[8].Value = model.nIsPage;
            sqlParams[9].Value = model.nclass1;
            sqlParams[10].Value = model.nClass2;
            sqlParams[11].Value = model.nId;
            sqlParams[12].Value = model.nLevel;
            sqlParams[13].Value = model.nFormurl;
            sqlParams[14].Value = model.nTitleSeo;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_Car_EditNews", sqlParams);
            return count;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateStatus(C_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_NewsTemp set ");
            strSql.Append("nStatus=@nStatus");
            strSql.Append(" where nId=@nId ");
            SqlParameter[] parameters = {
					new SqlParameter("@nStatus", SqlDbType.Int),
					new SqlParameter("@nId", SqlDbType.Int)};

            parameters[0].Value = model.nStatus;
            parameters[1].Value = model.nId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(C_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM C_News where nId=@nId ");
            SqlParameter[] parameters = {
					new SqlParameter("@nId", SqlDbType.Int)};

            parameters[0].Value = model.nId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        // <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteTemp(C_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM C_NewsTemp where nId=@nId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@nId", SqlDbType.Int)};

            parameters[0].Value = model.nId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        public int ChangeClassTemp(C_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_NewsTemp SET nclass1=@classId where nId=@nId ");
            SqlParameter[] parameters = {
					new SqlParameter("@classId", SqlDbType.Int),
					new SqlParameter("@nId", SqlDbType.Int)};

            parameters[0].Value = model.nclass1;
            parameters[1].Value = model.nId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        public int ChangeClass(C_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE C_News SET nclass1=@classId where nId=@nId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@classId", SqlDbType.Int),
                    new SqlParameter("@nId", SqlDbType.Int)};

            parameters[0].Value = model.nclass1;
            parameters[1].Value = model.nId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 点赞数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Clicks(Guid id)
        {
            SqlParameter[] sqlParam = { 
                                          new SqlParameter("@nId", SqlDbType.Int) 
                                      };
            sqlParam[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_News SET nClicks=nClicks+" + new Random().Next(1, 5) + "  where nId=@nId", sqlParam);

            return rows;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition)
        {
            return (new SqlExecute()).ProcessSqlDT("V_Car_GetNews", "nid,nIndex,ntitle,ntitlepic,ntips,nclicks,nclass1,cbName,cbEnName,nauthor,naddtime", Condition, Top);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "nid,nform,nformurl,nauthor,ntalks,naddtime,cbName,cbEnName,nclicks,ntitle,ntitlepic, ntips,ncontent,ntags,nlinkurl,nispage,nclass2,nstatus FROM V_Car_GetNews" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
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
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? (" TOP " + Top) : ("")) + " " + Fileds + " FROM V_Car_GetNews" + (Where != "" ? (" WHERE " + Where) : ("")), null);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetNewById(int Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT nid,nIndex,nclicks,nform,nformurl,nclass1,nclass2,nauthor,uid,naddtime,ntitle,ntitleseo,ntitlepic,ncontent,ntags,nisrecommand,ntips,nGood,carId,cbName,cbEnName FROM V_Car_GetNews WHERE Nid=" + Id, null);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetNewTempById(int Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT nid,nIndex,nclicks,nform,nformurl,nclass1,nclass2,nauthor,uid,naddtime,ntitle,ntitleseo,ntitlepic,ncontent,ntags,nisrecommand,ntips,nGood,carId,cbName,cbEnName FROM V_Car_GetNewsTemp WHERE Nid=" + Id, null);
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
            return SqlHelper.GetPaging("V_Car_GetNews", "nId", "nId,nIndex,nTitle,nTips,nTitlePic,cbName,cbEnName,naddTime,nGood,nBad,nClicks,nIsRecommand", Filter, "", "", CurrentPage, PageSize, out totalCount);
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
        public DataTable GetTempPaging(string Filter, string Sort, string Group, int CurrentPage, int PageSize, out int totalCount)
        {
            return SqlHelper.GetPaging("V_Car_GetNewsTemp", "nId", "nId,nIndex,nTitle,nTips,nTitlePic,cbName,nAddTime,nGood,nBad,nStatus,nClicks,nIsRecommand", Filter, Sort, Group, CurrentPage, PageSize, out totalCount);
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
            return SqlHelper.GetPaging("V_Car_GetNews", "nId", "nId,nIndex,nTitle,nTips,nTitlePic,cbName,nAddTime,nGood,nBad,nClicks,nIsRecommand", Filter, Sort, Group, CurrentPage, PageSize, out totalCount);
        }

        /// <summary>
        /// 点赞数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ClickGood(Guid id)
        {
            SqlParameter[] sqlParam = { 
                                          new SqlParameter("@Id", SqlDbType.Int) 
                                      };

            sqlParam[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_News SET nGood=nGood+1 WHERE nId=@Id", sqlParam);

            object o = SqlHelper.ExecuteScalar(CommandType.Text, "select nGood FROM C_News WHERE nId=@Id", sqlParam);

            return o != null ? Convert.ToInt32(o) : 0;
        }
    }
}
