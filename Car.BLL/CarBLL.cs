using System.Data;
using Car.Entity;
using Car.DAL;

namespace Car.BLL
{
    public class CarBLL
    {
        CarDAL _CarDAL;

        /// <summary>
        /// 
        /// </summary>
        public CarBLL()
        {
            _CarDAL = new CarDAL();
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(C_Class model)
        {
            return 0;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(C_Car model)
        {
            return 0;
        }

        /// <summary>
        /// 根据条件获取相关记录
        /// </summary>
        /// <param name="Condition">条件</param>
        /// <returns>返回数据集</returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _CarDAL.GetList(Top, Condition);
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
    }
}
