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
    public class UserBLL
    {
        UserDAL _UserDAL;

        public UserBLL()
        {

            _UserDAL = new UserDAL();
        }
        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="_P_User"></param>
        /// <returns></returns>
        public int AddUser(C_User _P_User)
        {
            return _UserDAL.AddUser(_P_User);
        }
        /// <summary>
        /// 获取完整的用户信息
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public DataTable GetUserById(string uId)
        {
            return _UserDAL.GetUserById(uId);
        }

        /// <summary>
        /// 获取完整的用户信息
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public DataTable GetUserByUName(string uName)
        {
            return _UserDAL.GetUserByUName(uName);
        }

        /// <summary>
        /// 获取完整的用户列表信息
        /// </summary>
        /// <param name="Top">记录条数</param>
        /// <param name="Conditions">获取条件</param>
        /// <returns></returns>
        public DataTable GetList(int Top, string Condition)
        {
            return _UserDAL.GetList(Top, Condition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_P_User"></param>
        /// <returns></returns>
        public int CompleteUser(C_User _P_User)
        {
            return _UserDAL.CompleteUser(_P_User);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="_P_User"></param>
        /// <returns></returns>
        public int EditUser(C_User _P_User)
        {
            return _UserDAL.AddUser(_P_User);
        }

        /// <summary>
        /// 根据用户名检查是否已经注册过
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool IsExsis(string userName)
        {
            return _UserDAL.IsExsis(userName);
        }

        /// <summary>
        /// 根据用户重新设置该用户的登录密码
        /// </summary>
        /// <param name="UName">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public bool ResetPwdByUser(string UName, string Pwd)
        {
            return _UserDAL.ResetPwdByUser(UName, Pwd);
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
            return _UserDAL.ResetPwdSafeByUser(Uname, Question, Answer);
        }


        /// <summary>
        /// 编辑用户最后一次登录的时间和IP
        /// </summary>
        /// <param name="p"></param>
        public bool EditLastDateAndIp(C_User _P_User)
        {
            return _UserDAL.EditLastDateAndIp(_P_User);
        }

        /// <summary>
        ///锁定账户 解锁账户 --0解锁账户，1锁定账户
        /// </summary>
        /// <param name="uId">用户id</param>
        /// <param name="status">操作类型0解锁账户，1锁定账户</param>
        /// <returns></returns>
        public bool LockUser(int uId, int status)
        {
            return _UserDAL.LockUser(uId, status);
        }
    }
}
