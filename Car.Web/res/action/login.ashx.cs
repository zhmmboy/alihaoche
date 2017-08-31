using Car.BLL;
using Car.Common;
using Car.Entity;
using System;
using System.Data;
using System.Web;

namespace Car.Web.res.action
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {
        ReturnInfo returnInfo;
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/json";

            string action = HttpContext.Current.Request["action"];

            if (!string.IsNullOrEmpty(action))
            {
                string email = HttpContext.Current.Request["email"];
                string password = HttpContext.Current.Request["password"];

                switch (action)
                {
                    case "signin":
                        string remember = HttpContext.Current.Request["remember"];
                        Login(email, password, remember); break;
                    case "signup":
                        string nickName = HttpContext.Current.Request["name"];
                        Reg(nickName, email, password);
                        break;
                }
            }

            HttpContext.Current.Response.Write(JsonHelper.Serialize(returnInfo));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="nickName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        private void Reg(string nickName, string email, string password)
        {
            UserBLL _UserBLL = new UserBLL();
            returnInfo = new ReturnInfo();
            string uName = PageValidateHelper.Filter(email);
            DataTable dt = _UserBLL.GetUserByUName(email);
            if (dt != null && dt.Rows.Count > 0)
            {
                returnInfo.error = "001";
                returnInfo.msg = "该用户已经被注册了！";
                returnInfo.gourl = string.Empty;
            }
            else
            {
                C_User _P_User = new C_User();
                _P_User.uId = Guid.NewGuid();
                _P_User.uNickName = nickName;
                _P_User.uName = email;
                _P_User.uRegIp = HttpContext.Current.Request.UserHostAddress;
                _P_User.uPwd = EncryptHelper.Md5(password, false, false);


                int count = _UserBLL.AddUser(_P_User);
                if (count > 0)
                {
                    //注册成功
                    returnInfo.error = string.Empty;
                    returnInfo.msg = string.Empty;
                    returnInfo.gourl = "www.alihaoche.com";
                }
                else
                {
                    returnInfo.error = "002";
                    returnInfo.msg = "系统异常，注册失败！";
                    returnInfo.gourl = string.Empty;
                }
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        private void Login(string email, string password, string remember)
        {
            returnInfo = new ReturnInfo();

            UserBLL _UserBLL = new UserBLL();
            string uName = PageValidateHelper.Filter(email);

            DataTable dt = _UserBLL.GetUserByUName(email);
            if (dt != null && dt.Rows.Count > 0)
            {
                //用户密码
                string pwd = dt.Rows[0]["upwd"].ToString();
                //将输入的密码进行Md5加密后进行对比
                string inputPwd = EncryptHelper.Md5(password, false, false);

                if (!pwd.Equals(inputPwd))
                {
                    returnInfo.error = "001";
                    returnInfo.msg = "密码错误！";
                    returnInfo.gourl = string.Empty;
                }
                else
                {
                    //登陆成功，写入cookie
                    HttpCookie uCookie = new HttpCookie("user");
                    uCookie.Values["id"] = dt.Rows[0]["uId"].ToString();
                    uCookie.Values["name"] = dt.Rows[0]["uname"].ToString();
                    uCookie.Values["nickname"] = dt.Rows[0]["unickname"].ToString();
                    uCookie.Values["logintime"] = dt.Rows[0]["ulogintime"].ToString();
                    uCookie.Values["lastip"] = dt.Rows[0]["ulastip"].ToString();
                    HttpContext.Current.Response.Cookies.Add(uCookie);
                    uCookie.Expires = System.DateTime.Now.AddHours(2);
                    uCookie.HttpOnly = false;

                    returnInfo.gourl = "www.baidu.com";
                }
            }
            else
            {
                returnInfo.error = "001";
                returnInfo.msg = "该用户不存在！";
                returnInfo.gourl = string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ReturnInfo
        {
            public string error { get; set; }
            public string msg { get; set; }
            public string gourl { get; set; }
        }
    }
}