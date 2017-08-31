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
    public class TagsBLL
    {
        TagsDAL _TagsDAL;

        /// <summary>
        /// 
        /// </summary>
        public TagsBLL()
        {

            _TagsDAL = new TagsDAL();
        }

        /// <summary>
        /// 批量保存标签
        /// </summary>
        /// <param name="InputTags"></param>
        /// <param name="MainId"></param>
        /// <param name="ClassId"></param>
        /// <param name="TType"></param>
        /// <returns></returns>
        public int Add(string InputTags, int MainId, int ClassId,int TType)
        {
            C_Tags _P_Tags = new C_Tags();
            string[] Tags = InputTags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Tag in Tags)
            {
                _P_Tags.tName = Tag;
                _P_Tags.tClicks = 0;
                _P_Tags.tIsValid = false;
                _P_Tags.mainId = MainId;
                _P_Tags.classId = ClassId;
                _P_Tags.newsId = 0;
                _P_Tags.tAddTime = System.DateTime.Now;
                _P_Tags.tType = TType;

                Add(_P_Tags);
            }
            return 1;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(C_Tags model)
        {
            //判断该标签是否存在
            DataTable dt = _TagsDAL.GetList(1, "tName='" + model.tName + "' AND classId="+model.classId+" And mainId="+model.mainId);
            if (dt != null && dt.Rows.Count > 0)
            {
                return 0;
            }

            return _TagsDAL.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(C_Tags model)
        {
            return _TagsDAL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(Guid tId)
        {
            return _TagsDAL.Delete(tId);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string tIdlist)
        {
            return _TagsDAL.DeleteList(tIdlist);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _TagsDAL.GetList(Top, Condition);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Condition">条件</param>
        /// <param name="isCache"></param>
        /// <param name="cacheName"></param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition, bool isCache, string cacheName, int cacheMinutes)
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
                    dt = _TagsDAL.GetList(Top, Condition);
                    HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddMinutes(cacheMinutes), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            else
            {
                dt = _TagsDAL.GetList(Top, Condition);
            }
            return dt;
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="tId">id</param>
        /// <returns>数据</returns>
        public DataTable GetTagById(Guid tId)
        {
            return _TagsDAL.GetTagById(tId);
        }


        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return _TagsDAL.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        {
            return _TagsDAL.GetDataBySql(sql);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetPaging(string condition,string sort,string group,int pageSize, int pageIndex, out int totalCount)
        {
            return _TagsDAL.GetPaging(condition, sort, group, pageSize, pageIndex, out totalCount);
        }
    }
}
