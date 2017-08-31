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
    public class PersonBLL
    {
        PersonDAL _personDAL;
        /// <summary>
        /// 
        /// </summary>
        public PersonBLL()
        {
            _personDAL = new PersonDAL();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            return _personDAL.Exists(Id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(C_Person model)
        {
            return _personDAL.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(C_Person model)
        {
            return _personDAL.Update(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataTable GetPaging(string v1, int v2, int pageIndex, out int totalCount)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateStatus(C_Person model)
        {
            return _personDAL.UpdateStatus(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(Guid pId)
        {
            return _personDAL.Delete(pId);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string pIdlist)
        {
            return _personDAL.DeleteList(pIdlist);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition)
        {
            return _personDAL.GetBaseList(Top, Condition);
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
                    dt = _personDAL.GetBaseList(Top, Condition);
                    HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddMinutes(cacheMinutes), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            else
            {
                dt = _personDAL.GetBaseList(Top, Condition);
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
            return _personDAL.GetList(Top, Condition);
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
            return _personDAL.GetList(Top, Fileds, Where);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetPersonById(Guid Id)
        {
            return _personDAL.GetPersonById(Id);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string Sql)
        {
            return _personDAL.ExecuteDataSet(Sql);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return _personDAL.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        {
            return _personDAL.GetDataBySql(sql);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetPaging(string condition, string sort, string group, int pageSize, int pageIndex, out int totalCount)
        {
            return _personDAL.GetPaging(condition, sort, group, pageSize, pageIndex, out totalCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public int ClickGood(Guid Id)
        {
            return _personDAL.ClickGood(Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        public int Clicks(Guid Id)
        {
            return _personDAL.Clicks(Id);
        }
    }
}
