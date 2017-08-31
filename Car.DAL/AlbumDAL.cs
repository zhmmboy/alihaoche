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
    public class AlbumDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public AlbumDAL() { }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_C_Album"></param>
        /// <returns></returns>
        public int Add(C_Album _C_Album)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [C_Album] (");
            strSql.Append("aId,aName,aPhoto,aIntro,personId,aAddTime,aClicks,atags,classId)");
            strSql.Append(" values (");
            strSql.Append("@aId,@aName,@aPhoto,@aIntro,@personId,@aAddTime,@aClicks,@atags,@classId)");
            SqlParameter[] parameters = {
					new SqlParameter("@aId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aName", SqlDbType.NVarChar,50),
					new SqlParameter("@aPhoto", SqlDbType.VarChar,50),
					new SqlParameter("@aIntro", SqlDbType.NVarChar,500),
					new SqlParameter("@personId", SqlDbType.NVarChar,50),
					new SqlParameter("@aAddTime", SqlDbType.DateTime),
					new SqlParameter("@aClicks", SqlDbType.Int,4),
					new SqlParameter("@atags", SqlDbType.NVarChar,200),
					new SqlParameter("@classId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = _C_Album.aId;
            parameters[1].Value = _C_Album.aName;
            parameters[2].Value = _C_Album.aPhoto;
            parameters[3].Value = _C_Album.aIntro;
            parameters[4].Value = _C_Album.personId;
            parameters[5].Value = _C_Album.aAddTime;
            parameters[6].Value = _C_Album.aClicks;
            parameters[7].Value = _C_Album.aTags;
            parameters[8].Value = _C_Album.classId;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return count;
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_C_AlbumInfo"></param>
        /// <returns></returns>
        public int AddAlbumInfo(C_AlbumInfo _C_AlbumInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [dbo].[C_AlbumInfo]([aiId],[aiUrl],[aiDesc],[albumId],[aiAddTime])VALUES(@aiId,@aiUrl,@aiDesc,@albumId,@aiAddTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@aiId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aiUrl", SqlDbType.NVarChar,500),
					new SqlParameter("@aiDesc", SqlDbType.VarChar,500),
					new SqlParameter("@albumId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aiAddTime", SqlDbType.DateTime)};

            parameters[0].Value = _C_AlbumInfo.aiId;
            parameters[1].Value = _C_AlbumInfo.aiUrl;
            parameters[2].Value = _C_AlbumInfo.aiDesc;
            parameters[3].Value = _C_AlbumInfo.albumId;
            parameters[4].Value = _C_AlbumInfo.aiAddTime;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return count;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int Edit(C_Album _C_Album)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [C_Album] set ");
            strSql.Append("aName=@aName,");
            strSql.Append("aPhoto=@aPhoto,");
            strSql.Append("aIntro=@aIntro,");
            strSql.Append("personId=@personId,");
            strSql.Append("classId=@classId,");
            strSql.Append("aTags=@aTags");
            strSql.Append(" where aId=@aId ");

            SqlParameter[] parameters = {
					new SqlParameter("@aName", SqlDbType.NVarChar,50),
					new SqlParameter("@aPhoto", SqlDbType.VarChar,50),
					new SqlParameter("@aIntro", SqlDbType.NVarChar,500),
					new SqlParameter("@personId", SqlDbType.NVarChar,50),
					new SqlParameter("@aTags", SqlDbType.NVarChar,200),
					new SqlParameter("@aId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@classId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = _C_Album.aName;
            parameters[1].Value = _C_Album.aPhoto;
            parameters[2].Value = _C_Album.aIntro;
            parameters[3].Value = _C_Album.personId;
            parameters[4].Value = _C_Album.aTags;
            parameters[5].Value = _C_Album.aId;
            parameters[6].Value = _C_Album.classId;

            int rows = 0;
            rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int EditAlbumInfo(List<C_AlbumInfo> _lstAlbumInfo)
        {
            int rows = 0;
            //
            if (_lstAlbumInfo != null && _lstAlbumInfo.Count > 0)
            {
                string strSql = string.Empty;

                for (int i = 0; i < _lstAlbumInfo.Count; i++)
                {
                    SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@aiId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aiUrl", SqlDbType.NVarChar,500),
					new SqlParameter("@aiDesc", SqlDbType.VarChar,500),
					new SqlParameter("@albumId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@aiAddTime", SqlDbType.DateTime)};

                    parameters[0].Value = _lstAlbumInfo[i].aiId;
                    parameters[1].Value = _lstAlbumInfo[i].aiUrl;
                    parameters[2].Value = _lstAlbumInfo[i].aiDesc;
                    parameters[3].Value = _lstAlbumInfo[i].albumId;
                    parameters[4].Value = _lstAlbumInfo[i].aiAddTime;

                    if (_lstAlbumInfo[i].aiAction.ToLower() == "add")
                    {
                        //添加
                        rows = AddAlbumInfo(_lstAlbumInfo[i]);  
                    }
                    else if (_lstAlbumInfo[i].aiAction.ToLower() == "edit")
                    {
                        //修改
                        strSql = "UPDATE [dbo].[C_AlbumInfo] SET [aiUrl] = @aiUrl,[aiDesc] = @aiDesc WHERE [aiId] =@aiId";
                        rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                    }
                    else
                    {
                        //删除
                        //strSql.Append("UPDATE [dbo].[C_AlbumInfo] SET [aiUrl] = @aiUrl,[aiDesc] = @aiDesc,[albumId] = @albumId,[aiAddTime] = @aiAddTime WHERE [aiId] =@aiId");
                        rows = DeleteAlbumInfo(_lstAlbumInfo[i]);
                    }
                }
            }
            return rows;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int Delete(C_Album _C_Album)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [C_Album] where aId=@aId ");

            SqlParameter[] parameters = {
					new SqlParameter("@aId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = _C_Album.aId;

            int rows = 0;
            rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int DeleteAlbumInfo(C_AlbumInfo _C_AlbumInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [C_AlbumInfo] WHERE aiId=@aiId ");

            SqlParameter[] parameters = {
					new SqlParameter("@aiId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = _C_AlbumInfo.aiId;

            int rows = 0;
            rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string aName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [C_Album]");
            strSql.Append(" where aName=@aName ");

            SqlParameter[] parameters = {
					new SqlParameter("@aName", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = aName;

            object obj = SqlHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (obj != null && Convert.ToInt32(obj) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[aId],[aName],[aPhoto],[aIntro],[personId],[aAddTime],aClicks,aTags,aIndex,cName,cEnName,pPhoto FROM dbo.V_GetAlbumList" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
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
        public DataTable GetPaging(string Filter, string Sort, string Group, int PageSize, int CurrentPage, out int TotalCount)
        {
            return SqlHelper.GetPaging("v_GetAlbumList", "aId", "[aId],[aName],[aPhoto],[aIntro],[aClicks],[aTags],[personId],[aAddTime],[aClicks],[cName],[cEnName],[cId],[pCnName],[pPenName],[pEnName],[cId],[cName],[cEnName]", Filter, Sort, Group, CurrentPage, PageSize, out TotalCount);
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
        public DataTable GetAlbumInfoPaging(string Filter, string Sort, string Group, int PageSize, int CurrentPage, out int TotalCount)
        {
            return SqlHelper.GetPaging("V_GetAlbumInfoList", "aiId", "[aId],[aName],[aPhoto],[personId],[aiId],[aiUrl],[aiDesc],[aiAddTime],[cId],[pCnName],[pPenName],[pEnName],[cId],[cName],[cEnName]", Filter, Sort, Group, CurrentPage, PageSize, out TotalCount);
        }


        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetAlbumById(Guid Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT [aId],[aName],[aPhoto],[aIntro],[personId],[aAddTime],[aClicks],[aTags],pCnName,pPhoto,cName,cEnName FROM v_GetAlbumList WHERE AId='" + Id + "'", null);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetAlbumInfoById(Guid Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT [aiId],[aiUrl],[aiDesc],[albumId],[aiAddTime],aId,aName,aClicks,aPhoto,aTags,aIntro,aIndex,personId,cId,cName,cEnName FROM V_GetAlbumInfoList WHERE albumId='" + Id + "'", null);
        }

        /// <summary>
        /// 点赞数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ClickGood(Guid id)
        {
            SqlParameter[] sqlParam = { 
                                          new SqlParameter("@Id", SqlDbType.UniqueIdentifier) 
                                      };

            sqlParam[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_Album SET aClicks=aClicks+1 WHERE aId=@Id", sqlParam);

            object o = SqlHelper.ExecuteScalar(CommandType.Text, "select aClicks FROM C_Album WHERE aId=@Id", sqlParam);

            return o != null ? Convert.ToInt32(o) : 0;
        }
    }
}
