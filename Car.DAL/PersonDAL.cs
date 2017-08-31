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
    public class PersonDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public PersonDAL() { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Person");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
					new SqlParameter("@pId", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            object o = SqlHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            return o != null ? true : false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(C_Person model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Person(");
            strSql.Append("pId,pFirstChar,pCnName,pEnName,pPenName,pSex,pNationality,pNation,pBirthday,pHeight,pWeight,pBWH,pUniversity,pHomeProvince,pHomeCity,pHomeArea,pNowProvice,pNowCity,pNowArea,pNowPlace,pJob,pBloodType,pPhoto,pZodiac,pConstellation,pSpeak,pSinaBlog,pTencentBlog,pHomePage,pTips,pIntroduce,ClassId,pTags)");
            strSql.Append(" values (");
            strSql.Append("@pId,@pFirstChar,@pCnName,@pEnName,@pPenName,@pSex,@pNationality,@pNation,@pBirthday,@pHeight,@pWeight,@pBWH,@pUniversity,@pHomeProvince,@pHomeCity,@pHomeArea,@pNowProvice,@pNowCity,@pNowArea,@pNowPlace,@pJob,@pBloodType,@pPhoto,@pZodiac,@pConstellation,@pSpeak,@pSinaBlog,@pTencentBlog,@pHomePage,@pTips,@pIntroduce,@ClassId,@pTags)");
            SqlParameter[] parameters = {
					new SqlParameter("@pId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pFirstChar", SqlDbType.NVarChar,50),
					new SqlParameter("@pCnName", SqlDbType.NVarChar,50),
					new SqlParameter("@pEnName", SqlDbType.NVarChar,50),
					new SqlParameter("@pPenName", SqlDbType.NVarChar,50),
					new SqlParameter("@pSex", SqlDbType.Bit,1),
					new SqlParameter("@pNationality", SqlDbType.NVarChar,50),
					new SqlParameter("@pNation", SqlDbType.NVarChar,50),
					new SqlParameter("@pBirthday", SqlDbType.DateTime),
					new SqlParameter("@pHeight", SqlDbType.Decimal,9),
					new SqlParameter("@pWeight", SqlDbType.Decimal,9),
					new SqlParameter("@pBWH", SqlDbType.NVarChar,50),
					new SqlParameter("@pUniversity", SqlDbType.NVarChar,50),
					new SqlParameter("@pHomeProvince", SqlDbType.NVarChar,50),
					new SqlParameter("@pHomeCity", SqlDbType.NVarChar,50),
					new SqlParameter("@pHomeArea", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowProvice", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowCity", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowArea", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowPlace", SqlDbType.NVarChar,50),
					new SqlParameter("@pJob", SqlDbType.NVarChar,50),
					new SqlParameter("@pBloodType", SqlDbType.NVarChar,50),
					new SqlParameter("@pPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@pSpeak", SqlDbType.NVarChar,50),
					new SqlParameter("@pSinaBlog", SqlDbType.NVarChar,500),
					new SqlParameter("@pTencentBlog", SqlDbType.NVarChar,500),
					new SqlParameter("@pHomePage", SqlDbType.NVarChar,50),
					new SqlParameter("@pTips", SqlDbType.NVarChar,500),
					new SqlParameter("@pIntroduce", SqlDbType.NText),
					new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pTags", SqlDbType.NVarChar,50),
					new SqlParameter("@pZodiac", SqlDbType.NVarChar,50),
					new SqlParameter("@pConstellation", SqlDbType.NVarChar,50)};

            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.pFirstChar;
            parameters[2].Value = model.pCnName;
            parameters[3].Value = model.pEnName;
            parameters[4].Value = model.pPenName;
            parameters[5].Value = model.pSex;
            parameters[6].Value = model.pNationality;
            parameters[7].Value = model.pNation;
            parameters[8].Value = model.pBirthday;
            parameters[9].Value = model.pHeight;
            parameters[10].Value = model.pWeight;
            parameters[11].Value = model.pBWH;
            parameters[12].Value = model.pUniversity;
            parameters[13].Value = model.pHomeProvince;
            parameters[14].Value = model.pHomeCity;
            parameters[15].Value = model.pHomeArea;
            parameters[16].Value = model.pNowProvice;
            parameters[17].Value = model.pNowCity;
            parameters[18].Value = model.pNowArea;
            parameters[19].Value = model.pNowPlace;
            parameters[20].Value = model.pJob;
            parameters[21].Value = model.pBloodType;
            parameters[22].Value = model.pPhoto;
            parameters[23].Value = model.pSpeak;
            parameters[24].Value = model.pSinaBlog;
            parameters[25].Value = model.pTencentBlog;
            parameters[26].Value = model.pHomePage;
            parameters[27].Value = model.pTips;
            parameters[28].Value = model.pIntroduce;
            parameters[29].Value = model.ClassId;
            parameters[30].Value = model.pTags;
            parameters[31].Value = model.pZodiac;
            parameters[32].Value = model.pConstellation;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(C_Person model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Person set ");
            strSql.Append("pFirstChar=@pFirstChar,");
            strSql.Append("pCnName=@pCnName,");
            strSql.Append("pEnName=@pEnName,");
            strSql.Append("pPenName=@pPenName,");
            strSql.Append("pSex=@pSex,");
            strSql.Append("pNationality=@pNationality,");
            strSql.Append("pNation=@pNation,");
            strSql.Append("pBirthday=@pBirthday,");
            strSql.Append("pHeight=@pHeight,");
            strSql.Append("pWeight=@pWeight,");
            strSql.Append("pBWH=@pBWH,");
            strSql.Append("pUniversity=@pUniversity,");
            strSql.Append("pHomeProvince=@pHomeProvince,");
            strSql.Append("pHomeCity=@pHomeCity,");
            strSql.Append("pHomeArea=@pHomeArea,");
            strSql.Append("pNowProvice=@pNowProvice,");
            strSql.Append("pNowCity=@pNowCity,");
            strSql.Append("pNowArea=@pNowArea,");
            strSql.Append("pNowPlace=@pNowPlace,");
            strSql.Append("pJob=@pJob,");
            strSql.Append("pBloodType=@pBloodType,");
            strSql.Append("pPhoto=@pPhoto,");
            strSql.Append("pSpeak=@pSpeak,");
            strSql.Append("pSinaBlog=@pSinaBlog,");
            strSql.Append("pTencentBlog=@pTencentBlog,");
            strSql.Append("pHomePage=@pHomePage,");
            strSql.Append("pTips=@pTips,");
            strSql.Append("pIntroduce=@pIntroduce,");
            strSql.Append("pTags=@pTags,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("pZodiac=@pZodiac,");
            strSql.Append("pConstellation=@pConstellation");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
					new SqlParameter("@pCnName", SqlDbType.NVarChar,50),
					new SqlParameter("@pEnName", SqlDbType.NVarChar,50),
					new SqlParameter("@pPenName", SqlDbType.NVarChar,50),
					new SqlParameter("@pSex", SqlDbType.Bit,1),
					new SqlParameter("@pNationality", SqlDbType.NVarChar,50),
					new SqlParameter("@pNation", SqlDbType.NVarChar,50),
					new SqlParameter("@pBirthday", SqlDbType.DateTime),
					new SqlParameter("@pHeight", SqlDbType.Decimal,9),
					new SqlParameter("@pWeight", SqlDbType.Decimal,9),
					new SqlParameter("@pBWH", SqlDbType.NVarChar,50),
					new SqlParameter("@pUniversity", SqlDbType.NVarChar,50),
					new SqlParameter("@pHomeProvince", SqlDbType.NVarChar,50),
					new SqlParameter("@pHomeCity", SqlDbType.NVarChar,50),
					new SqlParameter("@pHomeArea", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowProvice", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowCity", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowArea", SqlDbType.NVarChar,50),
					new SqlParameter("@pNowPlace", SqlDbType.NVarChar,50),
					new SqlParameter("@pJob", SqlDbType.NVarChar,50),
					new SqlParameter("@pBloodType", SqlDbType.NVarChar,50),
					new SqlParameter("@pPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@pSpeak", SqlDbType.NVarChar,50),
					new SqlParameter("@pSinaBlog", SqlDbType.NVarChar,500),
					new SqlParameter("@pTencentBlog", SqlDbType.NVarChar,500),
					new SqlParameter("@pHomePage", SqlDbType.NVarChar,50),
					new SqlParameter("@pIntroduce", SqlDbType.NText),
					new SqlParameter("@pTags", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pFirstChar", SqlDbType.NVarChar,50),
					new SqlParameter("@pZodiac", SqlDbType.NVarChar,50),
					new SqlParameter("@pConstellation", SqlDbType.NVarChar,50),
					new SqlParameter("@pId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pTips", SqlDbType.NVarChar,500)};

            parameters[0].Value = model.pCnName;
            parameters[1].Value = model.pEnName;
            parameters[2].Value = model.pPenName;
            parameters[3].Value = model.pSex;
            parameters[4].Value = model.pNationality;
            parameters[5].Value = model.pNation;
            parameters[6].Value = model.pBirthday;
            parameters[7].Value = model.pHeight;
            parameters[8].Value = model.pWeight;
            parameters[9].Value = model.pBWH;
            parameters[10].Value = model.pUniversity;
            parameters[11].Value = model.pHomeProvince;
            parameters[12].Value = model.pHomeCity;
            parameters[13].Value = model.pHomeArea;
            parameters[14].Value = model.pNowProvice;
            parameters[15].Value = model.pNowCity;
            parameters[16].Value = model.pNowArea;
            parameters[17].Value = model.pNowPlace;
            parameters[18].Value = model.pJob;
            parameters[19].Value = model.pBloodType;
            parameters[20].Value = model.pPhoto;
            parameters[21].Value = model.pSpeak;
            parameters[22].Value = model.pSinaBlog;
            parameters[23].Value = model.pTencentBlog;
            parameters[24].Value = model.pHomePage;
            parameters[25].Value = model.pIntroduce;
            parameters[26].Value = model.pTags;
            parameters[27].Value = model.ClassId;
            parameters[28].Value = model.pFirstChar;
            parameters[29].Value = model.pZodiac;
            parameters[30].Value = model.pConstellation;
            parameters[31].Value = model.pId;
            parameters[32].Value = model.pTips;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateStatus(C_Person model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Person set ");
            strSql.Append("pStatus=@pStatus");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
					new SqlParameter("@pStatus", SqlDbType.Int),
					new SqlParameter("@pId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = model.pStatus;
            parameters[1].Value = model.pId;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(Guid pId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Person ");
            strSql.Append(" where pId=@pId ");
            SqlParameter[] parameters = {
					new SqlParameter("@pId", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = pId;

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
                                          new SqlParameter("@pId", SqlDbType.UniqueIdentifier) 
                                      };
            sqlParam[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_Person SET pClicks=pClicks+" + new Random().Next(1, 5) + "  where pId=@pId", sqlParam);

            return rows;
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string pIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Person ");
            strSql.Append(" where pId in (" + pIdlist + ")  ");

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            return rows;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[pId],[pIndex],[pFirstChar],[pCnName],[pEnName],[pPenName],[pSex],[pJob],[pPhoto],[pZodiac],[pConstellation],[pTips],[pClicks],[pAddTime],ClassId,cName,cEnName FROM dbo.v_GetPersonList " + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[pId],[pFirstChar],[pCnName],[pEnName],[pPenName],[pSex],[pNationality],[pNation],[pBirthday],[pHeight],[pWeight],[pBWH],[pUniversity],[pHomeProvince],[pHomeCity],[pHomeArea],[pNowProvice],[pNowCity],[pNowArea],[pNowPlace],[pJob],[pBloodType],[pPhoto],[pSpeak],[pZodiac],[pConstellation],[pSinaBlog],[pTencentBlog],[pHomePage],[pTips],[pIntroduce],[ClassId],[pAddTime] FROM [dbo].[C_Person]" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
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
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? (" TOP " + Top) : ("")) + " " + Fileds + " FROM V_GetPersonList" + (Where != "" ? (" WHERE " + Where) : ("")), null);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetPersonById(Guid Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT [pId],[pIndex],[pFirstChar],[pCnName],[pEnName],[pPenName],[pSex],[pNationality],[pNation],[pBirthday],[pHeight],[pWeight],[pBWH],[pUniversity],[pHomeProvince],[pHomeCity],[pHomeArea],[pNowProvice],[pNowCity],[pNowArea],[pNowPlace],[pJob],[pBloodType],[pPhoto],[pSpeak],[pSinaBlog],[pTencentBlog],[pHomePage],[pTips],[pIntroduce],[pTags],[ClassId],[pAddTime],[pClicks],[pZodiac],[pConstellation],[pFans],cName,cEnName FROM [dbo].v_GetPersonList WHERE pId='" + Id.ToString() + "'", null);
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
            return SqlHelper.GetPaging("v_GetPersonList", "pId", "[pId],[pFirstChar],[pCnName],[pEnName],[pPenName],[pSex],[pJob],[pPhoto],[pTips],[pFans],[pClicks],[pAddTime],pStatus,ClassId,cName,cEnName", Filter, Sort, Group, CurrentPage, PageSize, out TotalCount);
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

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_Person SET pFans=pFans+1 WHERE pId=@Id", sqlParam);

            object o = SqlHelper.ExecuteScalar(CommandType.Text, "select pFans FROM C_Person WHERE pId=@Id", sqlParam);

            return o != null ? Convert.ToInt32(o) : 0;
        }
    }
}
