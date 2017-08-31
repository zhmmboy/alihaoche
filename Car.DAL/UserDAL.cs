using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Entity;

namespace Car.DAL
{
    public class UserDAL
    {
        public UserDAL() { }
        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_C_User"></param>
        /// <returns></returns>
        public int AddUser(C_User _C_User)
        {
            SqlParameter[] sqlParams = {
					new SqlParameter("@uId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@uName", SqlDbType.NVarChar,20),
					new SqlParameter("@uNickName", SqlDbType.NVarChar,20),
					new SqlParameter("@uPwd", SqlDbType.VarChar,50),
					new SqlParameter("@uRegIp", SqlDbType.VarChar,20)};

            sqlParams[0].Value = _C_User.uId;
            sqlParams[1].Value = _C_User.uName;
            sqlParams[2].Value = _C_User.uNickName;
            sqlParams[3].Value = _C_User.uPwd;
            sqlParams[4].Value = _C_User.uRegIp;

            int count = 0;
            count = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "C_AddUser", sqlParams);
            return count;
        }

        /// <summary>
        /// 获取完整的用户信息
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public DataTable GetUserById(string uId)
        {
            //private string _unickname = "";//昵称
            // private string _utruename = "";//真实姓名
            // private string _uphone = "";//电话
            // private string _umobile = "";//手机
            // private string _usex = 0;//默认男性同胞
            // private string _ubirth_year = "";//出生年
            // private string _ubirth_month = "";//出生月
            // private string _ubirth_day = "";//出生日
            // private string _uprovince = "";//出生省份
            // private string _ucity = "";//出生城市
            // private string _uarea = "";//出生地区
            // private string _uaddress = "";//出生地址
            // private string _upost = "";//邮编
            // private string _uqq = "";//qq
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT * FROM C_User WHERE uId='" + uId + "'", null);
        }

        /// <summary>
        /// 获取完整的用户信息
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public DataTable GetUserByUName(string uName)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT * FROM C_User WHERE uName='" + uName + "'", null);
        }

        /// <summary>
        /// 获取完整的用户列表信息
        /// </summary>
        /// <param name="Top">记录条数</param>
        /// <param name="Conditions">获取条件</param>
        /// <returns></returns>
        public DataTable GetList(int Top, string Condition)
        {
            //private string _unickname = "";//昵称
            // private string _utruename = "";//真实姓名
            // private string _uphone = "";//电话
            // private string _umobile = "";//手机
            // private string _usex = 0;//默认男性同胞
            // private string _ubirth_year = "";//出生年
            // private string _ubirth_month = "";//出生月
            // private string _ubirth_day = "";//出生日
            // private string _uprovince = "";//出生省份
            // private string _ucity = "";//出生城市
            // private string _uarea = "";//出生地区
            // private string _uaddress = "";//出生地址
            // private string _upost = "";//邮编
            // private string _uqq = "";//qq
            return SqlHelper.ExecuteDataTable(CommandType.Text, "SELECT " + (Top > 0 ? " TOP " + Top : "") + " * FROM gw_Users" + (Condition.Trim() != "" ? " WHERE " + Condition : ""), null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_C_User"></param>
        /// <returns></returns>
        public int CompleteUser(C_User _C_User)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_User set ");
            strSql.Append("uNickName=@uNickName,");
            strSql.Append("uPhoto=@uPhoto,");
            strSql.Append("uAge=@uAge,");
            strSql.Append("uSex=@uSex,");
            strSql.Append("uMobile=@uMobile,");
            strSql.Append("uPhone=@uPhone,");
            strSql.Append("uProvince=@uProvince,");
            strSql.Append("uCity=@uCity,");
            strSql.Append("uZipCode=@uZipCode,");
            strSql.Append("uAddr=@uAddr,");
            strSql.Append("uBirth=@uBirth,");
            strSql.Append(" where uId=@uId ");
            SqlParameter[] parameters = {
					new SqlParameter("@uNickName", SqlDbType.NVarChar,50),
					new SqlParameter("@uPhoto", SqlDbType.NChar,10),
					new SqlParameter("@uAge", SqlDbType.Int,4),
					new SqlParameter("@uSex", SqlDbType.Bit,1),
					new SqlParameter("@uMobile", SqlDbType.Char,11),
					new SqlParameter("@uPhone", SqlDbType.VarChar,20),
					new SqlParameter("@uProvince", SqlDbType.NVarChar,30),
					new SqlParameter("@uCity", SqlDbType.NVarChar,30),
					new SqlParameter("@uZipCode", SqlDbType.VarChar,6),
					new SqlParameter("@uAddr", SqlDbType.NVarChar,50),
					new SqlParameter("@uBirth", SqlDbType.DateTime),
					new SqlParameter("@uId", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = _C_User.uNickName;
            parameters[1].Value = _C_User.uPhoto;
            parameters[2].Value = _C_User.uAge;
            parameters[3].Value = _C_User.uSex;
            parameters[4].Value = _C_User.uMobile;
            parameters[5].Value = _C_User.uPhone;
            parameters[6].Value = _C_User.uProvince;
            parameters[7].Value = _C_User.uCity;
            parameters[8].Value = _C_User.uZipCode;
            parameters[9].Value = _C_User.uAddr;
            parameters[10].Value = _C_User.uBirth;
            parameters[11].Value = _C_User.uId;

            int count = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            return count;
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_C_User"></param>
        /// <returns></returns>
        public int EditUser(C_User _C_User)
        {
            //SqlParameter[] sqlParams ={ 
            //    new SqlParameter("uloginpassword",SqlDbType.NVarChar,100),
            //    new SqlParameter("uemail",SqlDbType.NVarChar,50),
            //    new SqlParameter("uid",SqlDbType.Int),
            //    new SqlParameter("uquestion",SqlDbType.NVarChar,50),
            //    new SqlParameter("uanswer",SqlDbType.NVarChar,50)

            //};
            //sqlParams[0].Value = _C_User.uloginpassword;
            //sqlParams[1].Value = _C_User.uemail;
            //sqlParams[2].Value = _C_User.uid;
            //sqlParams[3].Value = _C_User.uquestion;
            //sqlParams[4].Value = _C_User.uanswer;

            //return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_EditUser", sqlParams);
            return 0;
        }

        /// <summary>
        /// 根据用户名检查是否已经注册过
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool IsExsis(string userName)
        {
            SqlParameter[] sqlParams = {
             new SqlParameter("@uName",SqlDbType.NVarChar,20)
            };
            sqlParams[0].Value = userName;
            SqlDataReader _sqlReader = SqlHelper.ExecuteReader(CommandType.Text, "SELECT uName FROM C_User WHERE uName=@uName", sqlParams);
            return _sqlReader.Read() ? true : false;
        }

        /// <summary>
        /// 根据用户重新设置该用户的登录密码
        /// </summary>
        /// <param name="UName">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public bool ResetPwdByUser(string UName, string Pwd)
        {
            SqlParameter[] sqlparams = {
                new SqlParameter("@uname",SqlDbType.NVarChar,20),
                new SqlParameter("@pwd",SqlDbType.NVarChar,100)
            };
            sqlparams[0].Value = UName;
            sqlparams[1].Value = Pwd;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE gw_users SET uloginpassword=@pwd where uloginname=@uname", sqlparams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据用户重新设置该用户的密码保护问题
        /// </summary>
        /// <param name="Uname">当前用户名</param>
        /// <param name="Question">密码保护问题</param>
        /// <param name="Answer">密码答案</param>
        /// <returns></returns>
        public bool ResetPwdSafeByUser(string Uname, string Question, string Answer)
        {
            SqlParameter[] sqlparams = {
                new SqlParameter("@uname",SqlDbType.NVarChar,20),
                new SqlParameter("@uquestion",SqlDbType.NVarChar,50),
                new SqlParameter("@uanswer",SqlDbType.NVarChar,50)
            };
            sqlparams[0].Value = Uname;
            sqlparams[1].Value = Question;
            sqlparams[2].Value = Answer;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE gw_users SET uquestion=@uquestion,uanswer=@uanswer where uloginname=@uname", sqlparams) > 0 ? true : false;
        }

        /// <summary>
        /// 用户积分转现金
        /// </summary>
        /// <param name="UserId">当前用户id</param>
        /// <param name="Money">要转换成的现金数</param>
        /// <returns></returns>
        public bool PointsConvertMoney(int UserId, int Points, int Money)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE gw_Users SET ugrade=ugrade-" + Points + ", umoney=umoney+" + Money + " WHERE uid=" + UserId, null) > 0 ? true : false;
        }
        /// <summary>
        /// 系统积分赠送
        /// </summary>
        /// <param name="UserId">当前赠送userid</param>
        /// <param name="ToUserName">被赠送的用户id</param>
        /// <param name="Points">赠送的积分</param>
        /// <returns>0：该用户不存在，1赠送成功</returns>
        public int GivePoints(int UserId, string ToUserName, int Points)
        {
            SqlParameter[] sqlpar = { 
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@username",SqlDbType.NVarChar,20),
                new SqlParameter("@points",SqlDbType.Int),
                new SqlParameter("@returnid",SqlDbType.Int)
            };
            sqlpar[0].Value = UserId;
            sqlpar[1].Value = ToUserName;
            sqlpar[2].Value = Points;
            sqlpar[3].Direction = ParameterDirection.ReturnValue;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_GievPoints", sqlpar);
            return Convert.ToInt32(sqlpar[3].Value);//返回执行结果
        }

        /// <summary>
        /// 编辑用户最后一次登录的时间和IP
        /// </summary>
        /// <param name="p"></param>
        public bool EditLastDateAndIp(C_User _C_User)
        {
            SqlParameter[] paramters ={ 
                new SqlParameter("uid",SqlDbType.UniqueIdentifier),
                new SqlParameter("lastip",SqlDbType.NChar,20)
            };
            paramters[0].Value = _C_User.uId;
            paramters[1].Value = _C_User.uLastIp;
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_editlastdateandip", paramters) > 0 ? true : false;
        }

        /// <summary>
        ///锁定账户 解锁账户 --0解锁账户，1锁定账户
        /// </summary>
        /// <param name="UId">用户id</param>
        /// <param name="Status">操作类型0解锁账户，1锁定账户</param>
        /// <returns></returns>
        public bool LockUser(int UId, int Status)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE gw_Users SET ustatus=" + Status + " WHERE uid=" + UId, null) > 0 ? true : false;
        }
    }
}
