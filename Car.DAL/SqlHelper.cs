using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

namespace Car.DAL
{
    /// <summary>
    /// ���ݿ��ͨ�÷��ʴ���
    /// ����Ϊ�����࣬������ʵ��������Ӧ��ʱֱ�ӵ��ü���
    /// </summary>
    public abstract class SqlHelper
    {
        //��ȡ���ݿ������ַ����������ھ�̬������ֻ������Ŀ�������ĵ�����ֱ��ʹ�ã��������޸�
        public static readonly string ConnectionStringLocalTransaction = ConfigurationSettings.AppSettings["ConnectionString"];

        // ��ϣ�������洢����Ĳ�����Ϣ����ϣ����Դ洢�������͵Ĳ�����
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());


        #region ִ��һ�������ؽ����SqlCommand��ͨ��һ���Ѿ����ڵ����ݿ�����
        /// <summary>
        ///ִ��һ�������ؽ����SqlCommand��ͨ��һ���Ѿ����ڵ����ݿ����� 
        /// ʹ�ò��������ṩ����
        /// </summary>
        /// <remarks>
        /// ʹ��ʾ����  
        ///  int result = ExecuteNonQuery(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="commandText">�洢���̵����ֻ��� T-SQL ���</param>
        /// <param name="commandParameters">��������ʽ�ṩSqlCommand�������õ��Ĳ����б�</param>
        /// <returns>����һ����ֵ��ʾ��SqlCommand����ִ�к�Ӱ�������</returns>
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

        #region ִ��һ�������ؽ����SqlCommand��ͨ��һ���Ѿ����ڵ����ݿ����ﴦ��
        /// <summary>
        /// ִ��һ�������ؽ����SqlCommand��ͨ��һ���Ѿ����ڵ����ݿ����ﴦ�� 
        /// ʹ�ò��������ṩ����
        /// </summary>
        /// <remarks>
        /// ʹ��ʾ���� 
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">һ�����ڵ� sql ���ﴦ��</param>
        /// <param name="commandType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="commandText">�洢���̵����ֻ��� T-SQL ���</param>
        /// <param name="commandParameters">��������ʽ�ṩSqlCommand�������õ��Ĳ����б�</param>
        /// <returns>����һ����ֵ��ʾ��SqlCommand����ִ�к�Ӱ�������</returns>
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

        #region ִ��һ�����ؽ������SqlCommand���ͨ��ר�õ������ַ�����
        /// <summary>
        /// ִ��һ�����ؽ������SqlCommand���ͨ��ר�õ������ַ�����
        /// ʹ�ò��������ṩ����
        /// </summary>
        ///  /// <remarks>
        /// ʹ��ʾ����  
        ///  Dataset ds = ExecuteDataSet(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="cmdText">�洢���̵����ֻ��� T-SQL ���</param>
        /// <param name="commandParameters">��������ʽ�ṩSqlCommand�������õ��Ĳ����б�</param>
        /// <returns>����һ�����������Dataset</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
            {
                //ͨ��PrePareCommand����������������뵽SqlCommand�Ĳ��������� 
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //���SqlCommand�еĲ����б� 
                cmd.Parameters.Clear();
                return ds;
            }
        }
        #endregion

        #region ִ��һ�����ؽ������SqlCommand���ͨ��ר�õ������ַ�����
        /// <summary>
        /// ִ��һ�����ؽ������SqlCommand���ͨ��ר�õ������ַ�����
        /// ʹ�ò��������ṩ����
        /// </summary>
        ///  /// <remarks>
        /// ʹ��ʾ����  
        ///  Dataset ds = ExecuteDataSet(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="cmdText">�洢���̵����ֻ��� T-SQL ���</param>
        /// <param name="commandParameters">��������ʽ�ṩSqlCommand�������õ��Ĳ����б�</param>
        /// <returns>����һ�����������Dataset</returns>
        public static DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
            {
                //ͨ��PrePareCommand����������������뵽SqlCommand�Ĳ��������� 
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //���SqlCommand�еĲ����б� 
                cmd.Parameters.Clear();
                return dt;
            }
        }
        #endregion

        #region ִ��һ�����ؽ������SqlCommand���ͨ��ר�õ������ַ�����
        /// <summary>
        /// ִ��һ�����ؽ������SqlCommand���ͨ��ר�õ������ַ�����
        /// ʹ�ò��������ṩ����
        /// </summary>
        /// <remarks>
        /// ʹ��ʾ����  
        ///  SqlDataReader r = ExecuteReader(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="commandText">�洢���̵����ֻ��� T-SQL ���</param>
        /// <param name="commandParameters">��������ʽ�ṩSqlCommand�������õ��Ĳ����б�</param>
        /// <returns>����һ�����������SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction);

            // ������ʹ��try/catch��������Ϊ������������쳣����SqlDataReader�Ͳ����ڣ�
            //CommandBehavior.CloseConnection�����Ͳ���ִ�У��������쳣��catch����
            //�ر����ݿ����ӣ���ͨ��throw�ٴ�������׽�����쳣��
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

        #region ִ��һ�����ص�һ����¼��һ�е�SqlCommand���ͨ���Ѿ����ڵ����ݿ����ӡ�
        /// <summary>
        /// ִ��һ�����ص�һ����¼��һ�е�SqlCommand���ͨ���Ѿ����ڵ����ݿ����ӡ�
        /// ʹ�ò��������ṩ����
        /// </summary>
        /// <remarks>
        /// ʹ��ʾ���� 
        ///  Object obj = ExecuteScalar(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="commandText">�洢���̵����ֻ��� T-SQL ���</param>
        /// <param name="commandParameters">��������ʽ�ṩSqlCommand�������õ��Ĳ����б�</param>
        /// <returns>����һ��object���͵����ݣ�����ͨ�� Convert.To{Type}����ת������</returns>
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

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="cacheKey">��������ļ�ֵ</param>
        /// <param name="cmdParms">������Ĳ����б�</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        #endregion

        #region ��ȡ������Ĳ���
        /// <summary>
        /// ��ȡ������Ĳ���
        /// </summary>
        /// <param name="cacheKey">���ڲ��Ҳ�����KEYֵ</param>
        /// <returns>���ػ���Ĳ�������</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            //�½�һ�������Ŀ�¡�б�
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            //ͨ��ѭ��Ϊ��¡�����б�ֵ
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                //ʹ��clone�������Ʋ����б��еĲ���
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region Ϊִ������׼������
        /// <summary>
        /// Ϊִ������׼������
        /// </summary>
        /// <param name="cmd">SqlCommand ����</param>
        /// <param name="conn">�Ѿ����ڵ����ݿ�����</param>
        /// <param name="trans">���ݿ����ﴦ��</param>
        /// <param name="cmdType">SqlCommand�������� (�洢���̣� T-SQL��䣬 �ȵȡ�)</param>
        /// <param name="cmdText">Command text��T-SQL��� ���� Select * from Products</param>
        /// <param name="cmdParms">���ش�����������</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            //�ж����ݿ�����״̬
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //�ж��Ƿ���Ҫ���ﴦ��
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
            1.Tables :������,��ͼ
            2.PrimaryKey :���ؼ���
            3.Sort :������䣬����Order By ���磺NewsID Desc,OrderRows Asc
            4.CurrentPage :��ǰҳ��
            5.PageSize :��ҳ�ߴ�
            6.Filter :������䣬����Where 
            7.Group :Group���,����Group By
         **/
        /// <summary>
        /// ����������ȡ��ҳ����
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
           1.Tables :������,��ͼ
           2.PrimaryKey :���ؼ���
           3.Sort :������䣬����Order By ���磺NewsID Desc,OrderRows Asc
           4.CurrentPage :��ǰҳ��
           5.PageSize :��ҳ�ߴ�
           6.Filter :������䣬����Where 
           7.Group :Group���,����Group By
        **/

        /// <summary>
        /// ����������ȡ��ҳ����
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
