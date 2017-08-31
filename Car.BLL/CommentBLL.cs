using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Entity;
using Car.DAL;

namespace Car.BLL
{
    public class CommentBLL
    {
        CommentDAL _CommentDAL;

        public CommentBLL()
        {
            _CommentDAL = new CommentDAL();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(C_Comment model)
        {
            return _CommentDAL.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid cId)
        {
            return _CommentDAL.Delete(cId);
        }


        /// <summary>
        /// 审核一条数据
        /// </summary>
        public int UpdateStatus(C_Comment model)
        {
            return _CommentDAL.UpdateStatus(model);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetBaseList(int Top, string Condition)
        {
            return _CommentDAL.GetBaseList(Top, Condition);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _CommentDAL.GetBaseList(Top, Condition);
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
            return _CommentDAL.GetList(Top, Fileds, Where);
        }
        /// <summary>
        /// 根据id获取一条信息基本信息
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>数据</returns>
        public DataTable GetNewById(Guid Id)
        {
            return _CommentDAL.GetNewById(Id);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string Sql)
        {
            return _CommentDAL.ExecuteDataSet(Sql);
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string Sql)
        {
            return _CommentDAL.ExecuteDataTable(Sql);
        }

        /// <summary>
        /// 获取评论数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataTable GetComment(int Top, string Condition)
        {
            return _CommentDAL.GetComment(Top, Condition);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        {
            return _CommentDAL.GetDataBySql(sql);
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
            return _CommentDAL.GetPaging(Filter, CurrentPage, PageSize, out totalCount);
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
            return _CommentDAL.GetPaging(Filter, Sort, Group, CurrentPage, PageSize, out totalCount);
        }
    }
}
