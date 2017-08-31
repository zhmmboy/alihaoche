using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Entity;
using System.Web;
using Car.DAL;

namespace Car.BLL
{
    public class AlbumBLL
    {
        AlbumDAL _AlbumDAL;

        /// <summary>
        /// 
        /// </summary>
        public AlbumBLL()
        {
            _AlbumDAL = new AlbumDAL();
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_P_Album"></param>
        /// <returns></returns>
        public int Add(C_Album _P_Album)
        {
            return _AlbumDAL.Add(_P_Album);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_P_News"></param>
        /// <returns></returns>
        public int Edit(C_Album _P_Album)
        {
            return _AlbumDAL.Edit(_P_Album);
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_P_AlbumInfo"></param>
        /// <returns></returns>
        public int AddAblumInfo(C_AlbumInfo _P_AlbumInfo)
        {
            return _AlbumDAL.AddAlbumInfo(_P_AlbumInfo);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_P_News"></param>
        /// <returns></returns>
        public int EditAblumInfo(List<C_AlbumInfo> _lstAlbumInfo)
        {
            return _AlbumDAL.EditAlbumInfo(_lstAlbumInfo);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetAlbumById(Guid Id)
        {
            return _AlbumDAL.GetAlbumById(Id);
        }

        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetAlbumInfoById(Guid Id)
        {
            return _AlbumDAL.GetAlbumInfoById(Id);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _AlbumDAL.GetList(Top, Condition);
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
                    dt = _AlbumDAL.GetList(Top, Condition);
                    HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddMinutes(cacheMinutes), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            else
            {
                dt = _AlbumDAL.GetList(Top, Condition);
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
            return _AlbumDAL.ExecuteDataSet(Sql);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string Sql)
        {
            return _AlbumDAL.ExecuteDataTable(Sql);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string Sql)
        {
            return _AlbumDAL.GetDataBySql(Sql);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetPaging(string condition, string Sort, string Group, int pageSize, int pageIndex, out int totalCount)
        {
            return _AlbumDAL.GetPaging(condition, Sort, Group, pageSize, pageIndex, out totalCount);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="condition">分页查询条件</param>
        /// <param name="pageSize">每页显示记录条数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetAlbumInfoPaging(string condition, string Sort, string Group, int pageSize, int pageIndex, out int totalCount)
        {
            return _AlbumDAL.GetAlbumInfoPaging(condition, Sort, Group, pageSize, pageIndex, out totalCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ClickGood(Guid id)
        {
            return _AlbumDAL.ClickGood(id);
        }
    }
}
