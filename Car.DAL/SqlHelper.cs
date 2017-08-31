using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

namespace Car.DAL
{
    /// <summary>
    /// 数据库的通用访问代码
    /// 此类为抽象类，不允许实例化，在应用时直接调用即可
    /// </summary>
    public abstract class SqlHelper
    {
        //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
        public static readonly string ConnectionStringLocalTransaction = ConfigurationSettings.AppSettings["ConnectionString"];

        // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());


        #region 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库连接
        /// <summary>
        ///执行一条不返回结果的SqlCommand，通过一个已经存在的数据库连接 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：  
        ///  int result = ExecuteNonQuery(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库事物处理
        /// <summary>
        /// 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库事物处理 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例： 
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个存在的 sql 事物处理</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            int val = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ee)
            {
               
                trans.Connection.Close();
                throw ee;
            }
            finally
            {
                trans.Connection.Dispose();
            }
            return val;
        }
        #endregion

        #region 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// <summary>
        /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        ///  /// <remarks>
        /// 使用示例：  
        ///  Dataset ds = ExecuteDataSet(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果的Dataset</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //清空SqlCommand中的参数列表 
                cmd.Parameters.Clear();
                return ds;
            }
        }
        #endregion

        #region 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// <summary>
        /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        ///  /// <remarks>
        /// 使用示例：  
        ///  Dataset ds = ExecuteDataSet(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果的Dataset</returns>
        public static DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //清空SqlCommand中的参数列表 
                cmd.Parameters.Clear();
                return dt;
            }
        }
        #endregion

        #region 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// <summary>
        /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：  
        ///  SqlDataReader r = ExecuteReader(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果的SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction);

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                //conn.Dispose();
            }
        }
        #endregion

        #region 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例： 
        ///  Object obj = ExecuteScalar(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 缓存参数数组
        /// <summary>
        /// 缓存参数数组
        /// </summary>
        /// <param name="cacheKey">参数缓存的键值</param>
        /// <param name="cmdParms">被缓存的参数列表</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        #endregion

        #region 获取被缓存的参数
        /// <summary>
        /// 获取被缓存的参数
        /// </summary>
        /// <param name="cacheKey">用于查找参数的KEY值</param>
        /// <returns>返回缓存的参数数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            //新建一个参数的克隆列表
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            //通过循环为克隆参数列表赋值
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                //使用clone方法复制参数列表中的参数
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region 为执行命令准备参数
        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

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
        //public static DataTable GetPaging(string TabName, string PrimaryKey, string Fields, string Filter, string Sort, string Group, int CurrentPage, int PageSize, out int TotalCount)
        //{
        //    SqlParameter[] Params = {
        //                     new SqlParameter("@tblName",SqlDbType.VarChar,255),
        //                     new SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
        //                     new SqlParameter("@fldName",SqlDbType.VarChar,255),
        //                     new SqlParameter("@PageSize",SqlDbType.Int),
        //                     new SqlParameter("@PageIndex",SqlDbType.Int),
        //                     new SqlParameter("@doCount",SqlDbType.Bit),
        //                     new SqlParameter("@OrderType",SqlDbType.Bit),
        //                     new SqlParameter("@strWhere",SqlDbType.VarChar,1500)
        //                     //new SqlParameter("@TotalCount",SqlDbType.Int)
        //                     };

        //    Params[0].Value = TabName;
        //    Params[1].Value = Fields;
        //    Params[2].Value = Sort;
        //    Params[3].Value = PageSize;
        //    Params[4].Value = CurrentPage;
        //    Params[5].Value = 1;
        //    Params[6].Value = 1;
        //    Params[7].Value = Filter;
        //    //Params[8].Direction = ParameterDirection.ReturnValue;

        //    object o = ExecuteScalar(CommandType.Text, "SELECT COUNT(1) FROM " + TabName + (Filter.Trim() != "" ? " WHERE " + Filter : ""), null);

        //    TotalCount = Convert.ToInt32(o);

        //    return ExecuteDataTable(CommandType.StoredProcedure, "C_DoPage", Params);
        //}

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
        public static DataTable GetPaging(string TabName, string PrimaryKey, string Fields, string Filter, string Sort, string Group, int CurrentPage, int PageSize, out int TotalCount)
        {
            SqlParameter[] Params = {
                             new SqlParameter("@Tables",SqlDbType.VarChar,1000),
                             new SqlParameter("@PrimaryKey",SqlDbType.VarChar,100),
                             new SqlParameter("@Filter",SqlDbType.VarChar,1000),
                             new SqlParameter("@Sort",SqlDbType.VarChar,200),
                             new SqlParameter("@Group",SqlDbType.VarChar,1000),
                             new SqlParameter("@CurrentPage",SqlDbType.Int),
                             new SqlParameter("@PageSize",SqlDbType.Int),
                             new SqlParameter("@Fields",SqlDbType.VarChar,1000)
                             //new SqlParameter("@TotalCount",SqlDbType.Int)
                             };

            Params[0].Value = TabName;
            Params[1].Value = PrimaryKey;
            Params[2].Value = Filter;
            Params[3].Value = Sort;
            Params[4].Value = Group;
            Params[5].Value = CurrentPage;
            Params[6].Value = PageSize;
            Params[7].Value = Fields;
            //Params[8].Direction = ParameterDirection.ReturnValue;

            object o = ExecuteScalar(CommandType.Text, "SELECT COUNT(1) FROM " + TabName + (Filter.Trim() != "" ? " WHERE " + Filter : ""), null);

            TotalCount = Convert.ToInt32(o);

            return ExecuteDataTable(CommandType.StoredProcedure, "P_Paging", Params);
        }
    }
}
