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
    public class QuestionDAL
    {
        /// <summary>
        /// 
        /// </summary>
        public QuestionDAL() { }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_C_Question"></param>
        /// <returns></returns>
        public int Add(C_Question _C_Question)
        {
            SqlParameter[] sqlParams ={ 
                new SqlParameter("@qId",SqlDbType.UniqueIdentifier),
                new SqlParameter("@qTitle",SqlDbType.NVarChar,50),
                new SqlParameter("@qIntro",SqlDbType.NVarChar,500),
                new SqlParameter("@qAsker",SqlDbType.NVarChar,50),
                new SqlParameter("@personId",SqlDbType.UniqueIdentifier),
                new SqlParameter("@qTags",SqlDbType.NVarChar,50),
                new SqlParameter("@qGood",SqlDbType.Int),
                new SqlParameter("@qBad",SqlDbType.Int),
                new SqlParameter("@qClicks",SqlDbType.Int),//一级分类
                new SqlParameter("@qAddTime",SqlDbType.DateTime)
               
            };
            sqlParams[0].Value = _C_Question.qId;
            sqlParams[1].Value = _C_Question.qTitle;
            sqlParams[2].Value = _C_Question.qIntro;
            sqlParams[3].Value = _C_Question.qAsker;
            sqlParams[4].Value = _C_Question.personId;
            sqlParams[5].Value = _C_Question.qTags;
            sqlParams[6].Value = _C_Question.qGood;
            sqlParams[7].Value = _C_Question.qBad;
            sqlParams[8].Value = _C_Question.qClicks;
            sqlParams[9].Value = _C_Question.qAddTime;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [dbo].[C_Question]([qId],[qTitle],[qIntro],[qAsker],[personId],[qTags],[qGood],[qBad],[qClicks],[qAddTime])VALUES(@qId,@qTitle,@qIntro,@qAsker,@personId,@qTags,@qGood,@qBad,@qClicks,@qAddTime)", sqlParams);
            return count;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_News"></param>
        /// <returns></returns>
        public int Edit(C_Question _C_Question)
        {
            SqlParameter[] sqlParams ={ 
                new SqlParameter("@qId",SqlDbType.UniqueIdentifier),
                new SqlParameter("@qTitle",SqlDbType.NVarChar,50),
                new SqlParameter("@qIntro",SqlDbType.NVarChar,500),
                new SqlParameter("@qAsker",SqlDbType.NVarChar,50),
                new SqlParameter("@personId",SqlDbType.UniqueIdentifier),
                new SqlParameter("@qTags",SqlDbType.NVarChar,50)
               
            };
            sqlParams[0].Value = _C_Question.qId;
            sqlParams[1].Value = _C_Question.qTitle;
            sqlParams[2].Value = _C_Question.qIntro;
            sqlParams[3].Value = _C_Question.qAsker;
            sqlParams[4].Value = _C_Question.personId;
            sqlParams[5].Value = _C_Question.qTags;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [dbo].[C_Question] SET [qTitle] = @qTitle,[qIntro] = @qIntro,[qAsker] = @qAsker,[personId] = @personId,[qTags] = @qTags  WHERE [qId] = @qId", sqlParams);
            return count;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetQuestionById(Guid Id)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT [qId],[qTitle],[qAsker],[qAddTime],[personId],[qClicks],[qTags],[qIntro],[qIndex],qGood,pCnName,pEnName,pJob,pSex,cId,cName,cEnName FROM [dbo].[V_GetQuestionList] WHERE QId='" + Id + "'", null);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + "[qId],[qTitle],[qAsker],qIntro,[qAddTime],[personId],[qClicks],pCnName,pEnName,pJob,pSex,pPhoto,cName,cEnName FROM [dbo].[V_GetQuestionList]" + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Fields, string Condition)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + " " + Fields + " FROM dbo.[V_GetQuestionList] " + (Condition.Trim() != "" ? (" WHERE " + Condition) : ("")), null);
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
        /// <returns></returns>
        public DataTable GetPaging(string Filter, string Sort, string Group, int CurrentPage, int PageSize, out int totalCount)
        {
            return SqlHelper.GetPaging("V_GetQuestionList", "qId", "qId,qIndex,qTitle,qAsker,qAddTime,qGood,qBad,qClicks,qIntro,qTags,pPhoto,pCnName,pEnName,cName,cEnName", Filter, Sort, Group, CurrentPage, PageSize, out totalCount);
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

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_Question SET qGood=qGood+1 WHERE qId=@Id", sqlParam);

            object o = SqlHelper.ExecuteScalar(CommandType.Text, "select qGood FROM C_Question WHERE qId=@Id", sqlParam);

            return o != null ? Convert.ToInt32(o) : 0;
        }

        /// <summary>
        /// 点赞数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Clicks(Guid id)
        {
            SqlParameter[] sqlParam = { 
                                          new SqlParameter("@Id", SqlDbType.UniqueIdentifier) 
                                      };
            sqlParam[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE C_Question SET qClicks=qClicks+"+new Random().Next(1,5)+" WHERE qId=@Id", sqlParam);

            return rows;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(Guid id)
        {
            SqlParameter[] sqlParam = { 
                                          new SqlParameter("@Id", SqlDbType.UniqueIdentifier) 
                                      };

            sqlParam[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, "Delete From C_Question WHERE qId=@Id", sqlParam);
            return rows;
        }
    }
}
