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
    public class AnswerBLL
    {
        AnswerDAL _AnswerDAL;
        /// <summary>
        /// 
        /// </summary>
        public AnswerBLL() { _AnswerDAL = new AnswerDAL(); }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_P_Answer"></param>
        /// <returns></returns>
        public int Add(C_Answer _P_Answer)
        {
            return _AnswerDAL.Add(_P_Answer);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_P_News"></param>
        /// <returns></returns>
        public int Edit(C_Answer _P_Answer)
        {
            return _AnswerDAL.Edit(_P_Answer);
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        { 
            return _AnswerDAL.GetList(Top, Condition); 
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string Sql)
        { 
            return _AnswerDAL.ExecuteDataSet(Sql); 
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string Sql)
        {
            return _AnswerDAL.ExecuteDataTable(Sql);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataBySql(string sql)
        {
            return _AnswerDAL.GetDataBySql(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        public void Delete(Guid guid)
        {
            _AnswerDAL.Delete(guid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataTable GetPaging(string Filter, string Sort, string Group, int CurrentPage, int PageSize, out int totalCount)
        {
            return _AnswerDAL.GetPaging(Filter,Sort,Group,CurrentPage,PageSize, out totalCount);
        }
    }
}
