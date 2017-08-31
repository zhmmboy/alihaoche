using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Entity;
using Car.DAL;
using System.Web;

namespace Car.BLL
{
    public class QuestionBLL
    {
        QuestionDAL _QuestionDAL;
        /// <summary>
        /// 
        /// </summary>
        public QuestionBLL() { _QuestionDAL = new QuestionDAL(); }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_P_Question"></param>
        /// <returns></returns>
        public int Add(C_Question _P_Question)
        {
            return _QuestionDAL.Add(_P_Question);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_P_News"></param>
        /// <returns></returns>
        public int Edit(C_Question _P_Question)
        {
            return _QuestionDAL.Edit(_P_Question);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _QuestionDAL.GetList(Top, Condition);
        }


        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetQuestionById(Guid Id)
        {
            return _QuestionDAL.GetQuestionById(Id);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top,string Fields,string Condition)
        {
            return _QuestionDAL.GetList(Top, Fields,Condition);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Top">返回记录条数</param>
        /// <param name="Condition">条件</param>
        /// <param name="isCache">是否缓存数据</param>
        /// <param name="cacheName">缓存数据名称</param>
        /// <param name="cacheMinutes">缓存分钟数</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition, bool isCache, string cacheName, int cacheMinutes)
        {
            DataTable dt = null;

            if (isCache)
            {
                if (HttpContext.Current.Cache[cacheName] != null)
                {
                    dt = HttpContext.Current.Cache[cacheName] as DataTable;
                }
                else
                {
                    dt = _QuestionDAL.GetList(Top, Condition);
                    HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddMinutes(cacheMinutes), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            else
            {
                dt = _QuestionDAL.GetList(Top, Condition);
            }

            return dt;
        }


        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string Sql)
        {
            return _QuestionDAL.ExecuteDataSet(Sql);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string Sql)
        {
            return _QuestionDAL.ExecuteDataTable(Sql);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        { return _QuestionDAL.GetDataBySql(sql); }


        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetPaging(string condition,string sort,string group, int pageSize, int pageIndex, out int totalCount)
        {
            return _QuestionDAL.GetPaging(condition,sort,group, pageIndex, pageSize, out totalCount);
        }

        /// <summary>
        /// 点赞数
        /// </summary>
        /// <param name="id"></param>
        public int ClickGood(Guid id)
        {
            return _QuestionDAL.ClickGood(id);
        }

        /// <summary>
        /// 阅读数
        /// </summary>
        /// <param name="id"></param>
        public int Clicks(Guid id)
        {
            return _QuestionDAL.Clicks(id);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="guid"></param>
        public int Delete(Guid id)
        {
            return _QuestionDAL.Delete(id);
        }
    }
}
