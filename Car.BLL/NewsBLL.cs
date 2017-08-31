using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.DAL;
using Car.Entity;
using System.Web;

namespace Car.BLL
{
    public class NewsBLL
    {
        NewsDAL _NewsDAL;
        /// <summary>
        /// 
        /// </summary>
        public NewsBLL() {
            _NewsDAL = new NewsDAL();
        }


        /// <summary>
        /// 检查文章是否存在
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool Exists(string title)
        {
            DataTable dt = new NewsDAL().GetBaseList(1, string.Format("ntitle = '{0}'", title));

            return dt != null && dt.Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNews(C_News model)
        {
            //判断该文章是否存在
            NewsDAL dal = new NewsDAL();
            if (Exists(model.nTitle))
            {
                return 1;
            }

            return _NewsDAL.Add(model);
            //return new BaseRepository<P_News>().AddEntity(model);
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewsTemp(C_News model)
        {
            //判断该文章是否存在
            NewsDAL dal = new NewsDAL();
            if (Exists(model.nTitle))
            {
                return 1;
            }

            return _NewsDAL.AddTemp(model);
            //return new BaseRepository<P_News>().AddEntity(model);
        }
        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditNews(C_News model)
        {
            return _NewsDAL.Edit(model);
            //return new BaseRepository<P_News>().UpdateEntity(model);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditNewsTemp(C_News model)
        {
            return _NewsDAL.EditTemp(model);
            //return new BaseRepository<P_News>().UpdateEntity(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateStatus(C_News model)
        {
            return _NewsDAL.UpdateStatus(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(C_News model)
        {
            return _NewsDAL.Delete(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteTemp(C_News model)
        {
            return _NewsDAL.DeleteTemp(model);
        }

        /// <summary>
        /// 修改分类数据
        /// </summary>
        public int ChangeClassTemp(C_News model)
        {
            return _NewsDAL.ChangeClassTemp(model);
        }

        /// <summary>
        /// 修改分类数据
        /// </summary>
        public int ChangeClass(C_News model)
        {
            return _NewsDAL.ChangeClass(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Clicks(Guid Id)
        {
            return _NewsDAL.Clicks(Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="var"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        //public IQueryable<P_News> GetPageList<S>(int pageIndex, int pageSize, out int total, Func<P_News, bool> whereLambda, bool isAsc, Func<P_News, S> orderLambda)
        //{
        //    return new BaseRepository<P_News>().LoadPageEntities(pageIndex,pageSize, out total,whereLambda,isAsc,orderLambda);
        //}

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition)
        {
            return _NewsDAL.GetBaseList(Top, Condition);
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
                    dt = _NewsDAL.GetBaseList(Top, Condition);
                    HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddMinutes(cacheMinutes), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            else
            {
                dt = _NewsDAL.GetBaseList(Top, Condition);
            }

            return dt;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _NewsDAL.GetList(Top, Condition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Top">指定返回记录的条数</param>
        /// <param name="Fileds">字段名称，*为所有字段</param>
        /// <param name="Where">查询条件</param>
        /// <returns>数据表</returns>
        public DataTable GetList(int Top, string Fileds, string Where)
        {
            return _NewsDAL.GetList(Top, Fileds, Where);
        }

        /// <summary>
        /// 根据新闻id获取一条信息基本信息
        /// </summary>
        /// <param name="NewId">新闻id</param>
        /// <returns>数据</returns>
        public DataTable GetNewById(int NewId)
        {
            return _NewsDAL.GetNewById(NewId);
        }

        /// <summary>
        /// 根据新闻id获取一条信息基本信息
        /// </summary>
        /// <param name="NewId">新闻id</param>
        /// <returns>数据</returns>
        public DataTable GetNewTempById(int NewId)
        {
            return _NewsDAL.GetNewTempById(NewId);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string Sql)
        {
            return _NewsDAL.ExecuteDataSet(Sql);
        }/// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string Sql)
        {
            return _NewsDAL.ExecuteDataTable(Sql);
        }

        /// <summary>
        /// 获取评论数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataTable GetComment(int Top, string Condition)
        {
            return _NewsDAL.GetComment(Top, Condition);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        {
            return _NewsDAL.GetDataBySql(sql);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetPaging(string condition,int pageSize,int pageIndex,out int totalCount)
        {
            return _NewsDAL.GetPaging(condition,pageIndex, pageSize,out totalCount);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetPaging(string condition,string sort,string group ,int pageSize, int pageIndex, out int totalCount)
        {
            return _NewsDAL.GetPaging(condition,sort,group,pageIndex, pageSize, out totalCount);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetTempPaging(string condition, string sort, string group, int pageSize, int pageIndex, out int totalCount)
        {
            return _NewsDAL.GetTempPaging(condition, sort, group, pageIndex, pageSize, out totalCount);
        }

        /// <summary>
        /// 点赞数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ClickGood(Guid id)
        {
            return _NewsDAL.ClickGood(id);
        }
    }
}
