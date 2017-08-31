using System;
using System.Data;
using System.Web;
using Car.BLL;

/// <summary>
/// CommonUtility 的摘要说明
/// </summary>
namespace Car.Web
{
    public class CommonUtility
    {
        public CommonUtility()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 检查系统后台用户是否已经登陆了
        /// </summary>
        public static void CheckUserLogin()
        {
            if (HttpContext.Current.Session["sys_username"] == null
                   || HttpContext.Current.Session["sys_username"].ToString().Trim() == ""
                   || HttpContext.Current.Session["sys_username"].ToString().Trim() != "admin")
            {
                HttpContext.Current.Response.Redirect("~/Manage/Login.aspx");
            }
        }
        //        /*
        //        /// <summary>
        //        /// 将当前用户信息保存到会话中
        //        /// </summary>
        //        /// <param name="_DS_User">用户数据集合</param>
        //        public static void SaveCurrentUserToCookie(DataSet _DS_User)
        //        {
        //            //添加到会话集合里
        //            HttpCookie cookie = new HttpCookie("user");
        //            cookie.Values["uemail"] = _DS_User.Tables[0].Rows[0]["uemail"].ToString();
        //            cookie.Values["ugrade"] = _DS_User.Tables[0].Rows[0]["ugrade"].ToString();
        //            cookie.Values["sysgrade"] = _DS_User.Tables[0].Rows[0]["sysgrade"].ToString();
        //            cookie.Values["uid"] = _DS_User.Tables[0].Rows[0]["uid"].ToString();
        //            cookie.Values["uloginname"] = _DS_User.Tables[0].Rows[0]["uloginname"].ToString();
        //            //cookie.Values["unickname"] = _DS_User.Tables[0].Rows[0]["unickname"].ToString();
        //            cookie.Values["umoney"] = _DS_User.Tables[0].Rows[0]["umoney"].ToString();
        //            cookie.Values["uyongjin"] = _DS_User.Tables[0].Rows[0]["uyongjin"].ToString();
        //            cookie.Values["ustatus"] = _DS_User.Tables[0].Rows[0]["ustatus"].ToString();
        //            cookie.Values["uregdate"] = _DS_User.Tables[0].Rows[0]["uregdate"].ToString();
        //            cookie.Values["ulastdate"] = _DS_User.Tables[0].Rows[0]["ulastdate"].ToString();
        //            //将该用户的购物车物品数量添加到会话集合里
        //            DataTable _DT = null;// new DataAccess.DA_gw_ShoppingCar().GetShoppingCar("uid=" + int.Parse(_DS_User.Tables[0].Rows[0]["uid"].ToString()));
        //            if (GetDataTable(_DT))
        //                cookie.Values["shoppingcount"] = _DT.Rows.Count.ToString();
        //            else
        //                cookie.Values["shoppingcount"] = "0";
        //            HttpContext.Current.Response.Cookies.Add(cookie);
        //            FormsAuthentication.SetAuthCookie("user", false);//设置验证，禁止跨浏览器访问
        //            cookie.Expires = System.DateTime.Now.AddHours(2);//2小时后过期
        //        }
        //        /// <summary>
        //        /// 将当前用户信息保存到会话中
        //        /// </summary>
        //        /// <param name="_DS_User">用户数据集合</param>
        //        public static void SaveCurrentUserToCookie(Entity.EN_gw_User _EN_gw_User)
        //        {
        //            //添加到会话集合里
        //            if (GetCookie("user") != null)
        //            {
        //                HttpContext.Current.Request.Cookies.Remove("user");
        //            }
        //            HttpCookie cookie = new HttpCookie("user");
        //            //cookie.Values["uemail"] = _EN_gw_User.uemail;
        //            cookie.Values["ugrade"] = _EN_gw_User.ugrade.ToString();
        //            cookie.Values["sysgrade"] = _EN_gw_User.sysgrade.ToString();
        //            cookie.Values["uid"] = _EN_gw_User.uid.ToString();
        //            cookie.Values["uloginname"] = _EN_gw_User.uloginname;
        //            cookie.Values["unickname"] = _EN_gw_User.unickname;
        //            cookie.Values["umoney"] = _EN_gw_User.umoney.ToString();
        //            cookie.Values["uyongjin"] = _EN_gw_User.uyongjin.ToString();
        //            cookie.Values["ustatus"] = _EN_gw_User.ustatus.ToString();
        //            cookie.Values["uregdate"] = _EN_gw_User.uregdate.ToString();
        //            cookie.Values["ulastdate"] = _EN_gw_User.ulastdate.ToString();
        //            //HttpContext.Current.Request.Cookies.Remove("user");
        //            cookie.Expires = System.DateTime.Now.AddHours(2);//2小时后过期
        //            //cookie.Domain = ".8to28.com";
        //            cookie.Domain = "";
        //            //将该用户的购物车物品数量添加到会话集合里
        //            HttpContext.Current.Response.AppendCookie(new HttpCookie("shoppingcount", new DataAccess.DA_gw_ShoppingCar().GeShoppingCountByUId(_EN_gw_User.uid).ToString()));
        //            HttpContext.Current.Response.AppendCookie(cookie);
        //            FormsAuthentication.SetAuthCookie("user", false);//设置验证，禁止跨浏览器访问
        //        }

        //        /// <summary>
        //        /// 将当前用户信息保存到会话中
        //        /// </summary>
        //        /// <param name="_DS_User">用户数据集合</param>
        //        public static void SaveCurrentUserToCookie_Shopping(Entity.EN_gw_User _EN_gw_User)
        //        {
        //            //添加到会话集合里
        //            if (GetCookie("user") != null)
        //            {
        //                HttpContext.Current.Request.Cookies.Remove("user");
        //            }
        //            HttpCookie cookie = new HttpCookie("user");
        //            cookie.Values["uemail"] = _EN_gw_User.uemail;
        //            cookie.Values["ugrade"] = _EN_gw_User.ugrade.ToString();
        //            cookie.Values["sysgrade"] = _EN_gw_User.sysgrade.ToString();
        //            cookie.Values["uid"] = _EN_gw_User.uid.ToString();
        //            cookie.Values["uloginname"] = _EN_gw_User.uloginname;
        //            //cookie.Values["unickname"] = _EN_gw_User.unickname;
        //            cookie.Values["umoney"] = _EN_gw_User.umoney.ToString();
        //            cookie.Values["uyongjin"] = _EN_gw_User.uyongjin.ToString();
        //            cookie.Values["ustatus"] = _EN_gw_User.ustatus.ToString();
        //            cookie.Values["uregdate"] = _EN_gw_User.uregdate.ToString();
        //            cookie.Values["ulastdate"] = _EN_gw_User.ulastdate.ToString();
        //            //HttpContext.Current.Request.Cookies.Remove("user");
        //            cookie.Expires = System.DateTime.Now.AddHours(2);//2小时后过期
        //            //cookie.Domain = ".ppeep.com";
        //            //将该用户的购物车物品数量添加到会话集合里
        //            HttpContext.Current.Response.AppendCookie(new HttpCookie("shoppingcount", new DataAccess.DA_gw_ShoppingCar().GeShoppingCountByUId(_EN_gw_User.uid).ToString()));
        //            HttpContext.Current.Response.AppendCookie(cookie);
        //            FormsAuthentication.SetAuthCookie("user", false);//设置验证，禁止跨浏览器访问
        //        }

        //        /// <summary>
        //        /// 获取当前登录的用户信息
        //        /// </summary>
        //        /// <returns></returns>
        //        public static Entity.EN_gw_User GetCurrentUser()
        //        {
        //            ///必须有6项以上cookie值
        //            if (HttpContext.Current.Request.Cookies["user"] != null && HttpContext.Current.Request.Cookies["user"].Values.Count > 6)
        //            {
        //                Entity.EN_gw_User _EN_User = new Entity.EN_gw_User();
        //                _EN_User.uloginname = HttpContext.Current.Request.Cookies["user"]["uloginname"].ToString();
        //                _EN_User.unickname = HttpContext.Current.Request.Cookies["user"]["unickname"].ToString();
        //                _EN_User.ugrade = Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["ugrade"]);
        //                _EN_User.sysgrade = Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["sysgrade"]);
        //                _EN_User.uid = Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["uid"]);
        //                _EN_User.umoney = Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["umoney"]);
        //                _EN_User.ustatus = Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["ustatus"]);
        //                _EN_User.uyongjin = Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["uyongjin"]);
        //                _EN_User.uregdate = Convert.ToDateTime(HttpContext.Current.Request.Cookies["user"]["uregdate"]);
        //                _EN_User.ulastdate = Convert.ToDateTime(HttpContext.Current.Request.Cookies["user"]["ulastdate"]);
        //                return _EN_User;
        //            } return null;
        //        }

        //        /// <summary>
        //        /// 退出当前的用户登录
        //        /// </summary>
        //        public static void ExitCurrentUser()
        //        {
        //            if (GetCurrentUser() != null)
        //            {
        //                HttpCookie CurrentCookie = new HttpCookie("user");
        //                CurrentCookie.Value = "";
        //                FormsAuthentication.SignOut();
        //                CurrentCookie.Expires = System.DateTime.MinValue;

        //                HttpContext.Current.Response.Cookies.Add(CurrentCookie);
        //            }
        //        }
        //        /// <summary>
        //        /// 获取md5加密后的字符串
        //        /// </summary>
        //        /// <param name="key">要加密的字符串</param>
        //        /// <returns></returns>
        //        public static string EncryptByMD5(string key)
        //        {
        //            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
        //        }
        //        /// <summary>
        //        /// 获取客户端ip地址
        //        /// </summary>
        //        /// <returns></returns>
        //        public static string GetClientIP(System.Web.UI.Page CurrentPage)
        //        {
        //            return CurrentPage.Request.UserHostAddress;
        //        }

        //        /// <summary>
        //        /// 获取当前结束后要跳转的页面url
        //        /// </summary>
        //        /// <param name="DefaultUrl">如果没有请求的url，则跳转默认url</param>
        //        /// <returns></returns>
        //        public static string GetCurrentReturnUrl(string DefaultUrl)
        //        {
        //            return (HttpContext.Current.Request["url"] != null && HttpContext.Current.Request["url"].ToString() != "") ? HttpContext.Current.Request["url"].ToString() : DefaultUrl;
        //        }
        //        /// <summary>
        //        /// 获取当前验证码
        //        /// </summary>
        //        /// <returns></returns>
        //        public static string GetValidCode()
        //        {
        //            return (HttpContext.Current.Request.Cookies["ValidCode"] != null) ? HttpContext.Current.Request.Cookies["ValidCode"].Value : "";
        //        }

        //        #region 通用repeater 分页
        //        /// </summary>
        //        /// <param name="ds">DataSet实例</param>
        //        /// <param name="repeater">repeater名称</param>
        //        /// <param name="pagesize">分页大小</param>
        //        /// <param name="search">关键字</param>
        //        public static string GetPageNum(DataTable DtData, Repeater rptControl, Hashtable htKeyValue, int PageSize)
        //        {
        //            PagedDataSource objPds = new PagedDataSource();
        //            objPds.DataSource = DtData.DefaultView;
        //            objPds.AllowPaging = true;
        //            int total = DtData.Rows.Count;
        //            objPds.PageSize = PageSize;
        //            int page;
        //            if (GetQueryInt("page", 0) > 0)//如果页数为0，就出现错误了
        //                page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
        //            else
        //                page = 1;
        //            objPds.CurrentPageIndex = page - 1;
        //            rptControl.DataSource = objPds;
        //            rptControl.DataBind();
        //            int allpage = 0;
        //            int next = 0;
        //            int pre = 0;
        //            int startcount = 0;
        //            int endcount = 0;
        //            string pagestr = "";

        //            if (page < 1) { page = 1; }
        //            //计算总页数
        //            if (PageSize != 0)
        //            {
        //                allpage = (total / PageSize);
        //                allpage = ((total % PageSize) != 0 ? allpage + 1 : allpage);
        //                allpage = (allpage == 0 ? 1 : allpage);
        //            }
        //            next = page + 1;
        //            pre = page - 1;
        //            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //            //中间页终止序号
        //            endcount = page < 5 ? 10 : page + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
        //            pagestr = "第" + page.ToString() + "页/共" + allpage + "页";

        //            /**用hashtable拼接成一个字符串**/
        //            string conditionstring = "";
        //            if (htKeyValue != null)
        //            {
        //                IDictionaryEnumerator idictory = htKeyValue.GetEnumerator();
        //                while (idictory.MoveNext())
        //                {
        //                    conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //                }
        //            }
        //            pagestr += page > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=1\" target=\"_self\">首页</a><a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\" target=\"_self\">上一页</a>" : "";
        //            //中间页处理，这个增加时间复杂度，减小空间复杂度
        //            for (int i = startcount; i <= endcount; i++)
        //            {
        //                pagestr += page == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\" target=\"_self\">" + i + "</a>";
        //            }
        //            pagestr += page != allpage ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\" target=\"_self\">下一页</a><a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + allpage + "\" target=\"_self\">末页</a>" : "";
        //            return pagestr;
        //        }
        //        #endregion

        //        #region 通用repeater 分页
        //        /// </summary>
        //        /// <param name="ds">DataSet实例</param>
        //        /// <param name="repeater">repeater名称</param>
        //        /// <param name="pagesize">分页大小</param>
        //        /// <param name="search">关键字</param>
        //        public string GetPageNum(string CurrentPageName, DataTable DtData, Repeater rptControl, Hashtable htKeyValue, int PageSize, bool IsUrlRewrite)
        //        {
        //            PagedDataSource objPds = new PagedDataSource();
        //            objPds.DataSource = DtData.DefaultView;
        //            objPds.AllowPaging = true;
        //            int total = DtData.Rows.Count;
        //            objPds.PageSize = PageSize;
        //            int page;
        //            if (HttpContext.Current.Request.QueryString["page"] != null && HttpContext.Current.Request.QueryString["page"].ToString() != "0")//如果页数为0，就出现错误了
        //                page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
        //            else
        //                page = 1;
        //            objPds.CurrentPageIndex = page - 1;
        //            rptControl.DataSource = objPds;
        //            rptControl.DataBind();
        //            int allpage = 0;
        //            int next = 0;
        //            int pre = 0;
        //            int startcount = 0;
        //            int endcount = 0;
        //            string pagestr = "";

        //            if (page < 1) { page = 1; }
        //            //计算总页数
        //            if (PageSize != 0)
        //            {
        //                allpage = (total / PageSize);
        //                allpage = ((total % PageSize) != 0 ? allpage + 1 : allpage);
        //                allpage = (allpage == 0 ? 1 : allpage);
        //            }
        //            next = page + 1;
        //            pre = page - 1;
        //            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //            //中间页终止序号
        //            endcount = page < 5 ? 10 : page + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
        //            pagestr = "共" + allpage + "页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        //            /**用hashtable拼接成一个字符串**/
        //            string conditionstring = "";
        //            IDictionaryEnumerator idictory = htKeyValue.GetEnumerator();

        //            //如果启用url重写
        //            if (IsUrlRewrite)
        //            {
        //                while (idictory.MoveNext())
        //                {
        //                    conditionstring += "_" + idictory.Value.ToString();
        //                }
        //                pagestr += page > 1 ? "<a href=\"" + CurrentPageName + conditionstring + "_1\">首页</a>&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + pre + ".html\">上一页</a>" : "首页 上一页";
        //                //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                for (int i = startcount; i <= endcount; i++)
        //                {
        //                    pagestr += page == i ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + i + "</font>" : "&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + i + ".html\">[" + i + "]</a>";
        //                }
        //                pagestr += page != allpage ? "&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + next + "\">下一页</a>&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + allpage + ".html\">末页</a>" : " 下一页 末页";
        //            }
        //            else
        //            {
        //                while (idictory.MoveNext())
        //                {
        //                    conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //                }
        //                pagestr += page > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=1\">首页</a>&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\">上一页</a>" : "首页 上一页";
        //                //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                for (int i = startcount; i <= endcount; i++)
        //                {
        //                    pagestr += page == i ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + i + "</font>" : "&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\">[" + i + "]</a>";
        //                }
        //                pagestr += page != allpage ? "&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\">下一页</a>&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + allpage + "\">末页</a>" : " 下一页 末页";

        //            }
        //            return pagestr;
        //        }
        //        #endregion

        //        #region 通用datalist 分页
        //        /// </summary>
        //        /// <param name="ds">DataSet实例</param>
        //        /// <param name="repeater">repeater名称</param>
        //        /// <param name="pagesize">分页大小</param>
        //        /// <param name="search">关键字</param>
        //        public string GetPageNum(string CurrentPageName, DataTable DtData, DataList DlControl, Hashtable htKeyValue, int PageSize, bool IsUrlRewrite)
        //        {
        //            PagedDataSource objPds = new PagedDataSource();
        //            objPds.DataSource = DtData.DefaultView;
        //            objPds.AllowPaging = true;
        //            int total = DtData.Rows.Count;
        //            objPds.PageSize = PageSize;
        //            int page;
        //            if (HttpContext.Current.Request.QueryString["page"] != null && HttpContext.Current.Request.QueryString["page"].ToString() != "0")//如果页数为0，就出现错误了
        //                page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
        //            else
        //                page = 1;
        //            objPds.CurrentPageIndex = page - 1;
        //            DlControl.DataSource = objPds;
        //            DlControl.DataBind();
        //            int allpage = 0;
        //            int next = 0;
        //            int pre = 0;
        //            int startcount = 0;
        //            int endcount = 0;
        //            string pagestr = "";

        //            if (page < 1) { page = 1; }
        //            //计算总页数
        //            if (PageSize != 0)
        //            {
        //                allpage = (total / PageSize);
        //                allpage = ((total % PageSize) != 0 ? allpage + 1 : allpage);
        //                allpage = (allpage == 0 ? 1 : allpage);
        //            }
        //            next = page + 1;
        //            pre = page - 1;
        //            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //            //中间页终止序号
        //            endcount = page < 5 ? 10 : page + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
        //            pagestr = "共" + allpage + "页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        //            /**用hashtable拼接成一个字符串**/
        //            string conditionstring = "";
        //            IDictionaryEnumerator idictory = htKeyValue.GetEnumerator();

        //            //如果启用url重写
        //            if (IsUrlRewrite)
        //            {
        //                while (idictory.MoveNext())
        //                {
        //                    conditionstring += "_" + idictory.Value.ToString();
        //                }
        //                pagestr += page > 1 ? "<a href=\"" + CurrentPageName + conditionstring + "_1\">首页</a>&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + pre + ".html\">上一页</a>" : "首页 上一页";
        //                //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                for (int i = startcount; i <= endcount; i++)
        //                {
        //                    pagestr += page == i ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + i + "</font>" : "&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + i + ".html\">[" + i + "]</a>";
        //                }
        //                pagestr += page != allpage ? "&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + next + "\">下一页</a>&nbsp;&nbsp;<a href=\"" + CurrentPageName + conditionstring + "_" + allpage + ".html\">末页</a>" : " 下一页 末页";
        //            }
        //            else
        //            {
        //                while (idictory.MoveNext())
        //                {
        //                    conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //                }
        //                pagestr += page > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=1\">首页</a>&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\">上一页</a>" : "首页 上一页";
        //                //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                for (int i = startcount; i <= endcount; i++)
        //                {
        //                    pagestr += page == i ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + i + "</font>" : "&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\">[" + i + "]</a>";
        //                }
        //                pagestr += page != allpage ? "&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\">下一页</a>&nbsp;&nbsp;<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + allpage + "\">末页</a>" : " 下一页 末页";

        //            }
        //            return pagestr;
        //        }
        //        #endregion

        /// <summary>
        /// 截取指定长度的字符串
        /// </summary>
        /// <param name="str">要截取字符串</param>
        /// <param name="subLenght">截取长度</param>
        /// <returns>截取后的字符串</returns>
        public static string SubString(string str, int subLenght)
        {
            if (str.Length > subLenght)
                return str.Substring(0, subLenght);
            return str;
        }

        /// <summary>
        /// 获取指定参数的整数形式
        /// </summary>
        /// <param name="RequestStr">请求参数名称</param>
        /// <param name="DefaultValue">默认值（请求参数为空）</param>
        /// <returns></returns>
        public static int GetQueryInt(string RequestStr, int DefaultValue)
        {
            try
            {
                return GetQueryString(RequestStr) != "" ? Convert.ToInt32(GetQueryString(RequestStr)) : DefaultValue;
            }
            catch (Exception ex) { return 0; }
        }

        /// <summary>
        /// 根据请求字符串参数名获取该参数的值
        /// </summary>
        /// <param name="RequestStr">请求的参数名</param>
        /// <param name="IsSafeCheck">是否进行参数的安全检测</param>
        /// <returns></returns>
        public static string GetQueryString(string RequestStr, bool IsSafeCheck)
        {
            if (IsSafeCheck)
            {
                return IsSafeRequestString(GetQueryString(RequestStr)) ? GetQueryString(RequestStr) : "";
            }
            return GetQueryString(RequestStr);
        }

        public static string GetQueryString(string RequestStr)
        {
            return HttpContext.Current.Request[RequestStr] != null ? HttpContext.Current.Request[RequestStr].ToString().Trim() : "";
        }

        public static string GetFormString(string RequestStr, bool IsSafeCheck)
        {
            if (IsSafeCheck)
                return (FilterSQLKeys(GetFormString(RequestStr)) == GetFormString(RequestStr)) ? GetFormString(RequestStr) : "";
            return GetFormString(RequestStr);
        }

        public static string GetFormString(string RequestStr)
        {
            return (HttpContext.Current.Request.Form != null && HttpContext.Current.Request.Form[RequestStr] != null) ? HttpContext.Current.Request.Form[RequestStr].ToString().Trim() : "";
        }

        public static bool GetDataSet(DataSet DS)
        {
            return DS != null && DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0 ? true : false;
        }
        public static bool GetForm(object FormObj)
        {
            return FormObj != null ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public static bool GetDataTable(DataTable DT)
        {
            return DT != null && DT.Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// 判断当前用户是否登录,默认跳转到登陆页面login.aspx?from=Commonuility.GetUrl();
        /// </summary>
        /// <param name="RedirectUrl">如果用户没有登录，此为跳转的页面URL</param>
        /// <returns></returns>
        public static void IsLogin(string RedirectUrl)
        {
            //if (GetCurrentUser() == null)
            //{
            //    HttpContext.Current.Response.Redirect((RedirectUrl.Trim() != "" ? RedirectUrl : ("login.html?from=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.RawUrl))));
            //}
        }
        /// <summary>
        /// 获取当前请求的原始URL(相对根目录路径)
        /// </summary>
        /// <returns></returns>
        public static string GetVirtualUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }
        /// <summary>
        /// 获取当前请求的原始URL(绝对路径：http://www.by007.cn)
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 过滤请求的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterSQLKeys(string str)
        {
            if (str == null || str.Trim() == "")
                return "";
            str = str.Replace(";", "");
            str = str.Replace("'", "");
            str = str.Replace("&", "");
            str = str.Replace("%20", "");
            str = str.Replace("--", "");
            str = str.Replace("==", "");
            str = str.Replace("<", "");
            str = str.Replace(">", "");
            str = str.Replace("%", "");
            str = str.Replace("+", "");
            //str = str.Replace("-", "");
            str = str.Replace("=", "");
            str = str.Replace(",", "");
            return str;
        }

        //        /// <summary>
        //        /// 绑定数据源到指定的数据控件上
        //        /// </summary>
        //        /// <param name="repeater">控件名称</param>
        //        /// <param name="_DS_Product">数据集</param>
        //        public static void BindRepeater(Repeater repeater, DataSet _DS)
        //        {
        //            if (GetDataSet(_DS))
        //            {
        //                repeater.DataSource = _DS.Tables[0];
        //                repeater.DataBind();
        //            }
        //        }

        //        /// <summary>
        //        /// 根据自定义天数间隔生成文件夹
        //        /// </summary>
        //        /// <param name="Days">天数间隔</param>
        //        /// <returns></returns>
        //        public static string GetFolderName(int Days)
        //        {
        //            if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath((System.DateTime.Now.Year + System.DateTime.Now.Month).ToString())))
        //                System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath((System.DateTime.Now.Year + System.DateTime.Now.Month).ToString()));
        //            return (System.DateTime.Now.Year + System.DateTime.Now.Month).ToString();
        //        }
        //        /// <summary>
        //        /// 根据当前时间生成文件名称
        //        /// </summary>
        //        /// <returns></returns>
        //        public static string CreateFolderName()
        //        {
        //            return System.DateTime.Now.ToLongDateString().Replace(":", "").Replace("-", "").Replace("/", "").Replace(" ", "");
        //        }
        //        /// <summary>
        //        /// 获取指定名称的Cookie的值
        //        /// </summary>
        //        /// <param name="Name">cookie名称</param>
        //        /// <returns></returns>
        //        public static string GetCookie(string Name)
        //        {
        //            return (HttpContext.Current.Request.Cookies[Name] != null) ? HttpContext.Current.Request.Cookies[Name].Value.Trim() : "";
        //        }

        //        /// <summary>
        //        /// 获取指定名称的Session的值
        //        /// </summary>
        //        /// <param name="Name">Session名称</param>
        //        /// <returns></returns>
        //        public static string GetSession(string Name)
        //        {
        //            return (HttpContext.Current.Session[Name] != null) ? HttpContext.Current.Session[Name].ToString().Trim() : "";
        //        }

        //        /// <summary>
        //        /// 获取指定名称的Session的值
        //        /// </summary>
        //        /// <param name="Name">Session名称</param>
        //        /// <param name="DefaultValue">默认值</param>
        //        /// <returns></returns>
        //        public static string GetSession(string Name, string DefaultValue)
        //        {
        //            return (HttpContext.Current.Session[Name] != null) ? HttpContext.Current.Session[Name].ToString().Trim() : DefaultValue;
        //        }

        //        /// <summary>
        //        /// 向指定的email邮箱发送邮件
        //        /// <param name="FromEmail">邮件发件人</param>
        //        /// <param name="ToEmail">邮件收件人</param>
        //        /// <param name="Title">邮件主题,邮件标题</param>
        //        /// <param name="MailLevel">邮件优先级别</param>
        //        /// <param name="MailFor">邮件格式，Text文本格式和HTML格式</param>
        //        ///<param name="SmtpSer">SmtpSer邮件服务器名称</param>
        //        /// <param name="Body">邮件主题内容</param>
        //        /// <param name="AccessoriesName">邮件的附件文件名称AccessoriesName</param>
        //        /// </summary>
        //        public static void SendEmail(string FromEmail, string ToEmail, string Title, MailPriority MailLevel, MailFormat MailFor, string Body, string SmtpSer, string AccessoriesName)
        //        {
        //            try
        //            {
        //                MailMessage myMail = new MailMessage();
        //                myMail.From = FromEmail;    //发件人信箱 
        //                myMail.To = ToEmail;    //收件人信箱 
        //                myMail.Subject = Title;    //主题 
        //                myMail.Priority = MailLevel;    //优先级 
        //                myMail.BodyFormat = MailFor;
        //                myMail.Body = Body;    //内容 
        //                SmtpMail.SmtpServer = SmtpSer; //SMTP服务器名称 
        //                //附件的添加 
        //                MailAttachment _attach = null;
        //                if (AccessoriesName != "")    //客户端的'浏览文件'控件 
        //                {
        //                    _attach = new MailAttachment(AccessoriesName);
        //                    myMail.Attachments.Add(_attach);
        //                }
        //                SmtpMail.Send(myMail);
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        //        /// <summary>
        //        /// 根据邮箱地址，返回进入该邮箱的Href连接地址
        //        /// </summary>
        //        /// <param name="emailAddr"></param>
        //        /// <returns></returns>
        //        public static string GetEmailLink(string emailAddr)
        //        {
        //            string MailName = emailAddr.Substring(emailAddr.LastIndexOf('@') + 1, emailAddr.LastIndexOf('.') - emailAddr.LastIndexOf('@') - 1);
        //            switch (MailName.Trim().ToLower())
        //            {
        //                case "163": MailName = "mail.163.com"; break;
        //                case "126": MailName = "mail.sina.com"; break;
        //                case "139": MailName = "mail.139.com"; break;
        //                case "sina": MailName = "mail.sina.com"; break;
        //                case "sohu": MailName = "mail.sohu.com"; break;
        //                case "tom": MailName = "mail.tom.com"; break;
        //                case "qq": MailName = "mail.qq.com"; break;
        //                case "yahoo": MailName = "mail.yahoo.com.cn"; break;
        //                case "gmail": MailName = "www.gmail.com"; break;
        //                case "hotmail": MailName = "www.hotmail.com"; break;
        //                case "21cn": MailName = "mail.21cn.com"; break;
        //                case "sogou": MailName = "mail.sogou.com"; break;
        //                case "alibaba": MailName = "mail.china.alibaba.com/index.htm"; break;
        //                default: MailName = ""; break;
        //            } return MailName;



        //        }
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="_NewClassId"></param>
        //        /// <returns></returns>
        //        public static string GetNavString(int _NewClassId)
        //        {
        //            if (_NewClassId == 30)
        //            {
        //                return "<a href=\"http://www.8to28.com/star/\">明星频道</a>&gt;<a href=\"http://www.8to28.com/star/huaxing.html\">大陆明星</a>";
        //            }
        //            else if (_NewClassId == 31)
        //            {
        //                return "<a href=\"http://www.8to28.com/star/\">明星频道</a>&gt;<a href=\"http://www.8to28.com/sex/oumei.html\">港澳台明星</a>";
        //            }
        //            else if (_NewClassId == 32)
        //            {
        //                return "<a href=\"http://www.8to28.com/star/\">明星频道</a>&gt;<a href=\"http://www.8to28.com/star/oumei.html\">欧美明星</a>";
        //            }
        //            else if (_NewClassId == 33)
        //            {
        //                return "<a href=\"http://www.8to28.com/star/\">明星频道</a>&gt;<a href=\"http://www.8to28.com/sex/rihan.html\">日韩明星</a>";
        //            }
        //            else if (_NewClassId == 34)
        //            {
        //                return "<a href=\"http://www.8to28.com/shishang/\">时尚频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 38)
        //            {
        //                return "<a href=\"http://www.8to28.com/shenghuo/\">生活频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 42)
        //            {
        //                return "<a href=\"http://www.8to28.com/sex/\">青春频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 46)
        //            {
        //                return "<a href=\"http://www.8to28.com/sex/\">两性频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 50)
        //            {
        //                return "<a href=\"http://www.8to28.com/pic/\">情感频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 54)
        //            {
        //                return "<a href=\"http://www.8to28.com/pic/\">创业频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 58)
        //            {
        //                return "<a href=\"http://www.8to28.com/it/\">IT/科技频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 62)
        //            {
        //                return "<a href=\"http://www.8to28.com/3G/\">3G/互联网频道</a>&gt;";
        //            }
        //            else if (_NewClassId == 66)
        //            {
        //                return "<a href=\"http://www.8to28.com/pic/\">美图频道</a>&gt;<a href=\"http://www.8to28.com/pic/mote.html\">模特</a>";
        //            }
        //            else if (_NewClassId == 67)
        //            {
        //                return "<a href=\"http://www.8to28.com/pic/\">美图频道</a>&gt;<a href=\"http://www.8to28.com/pic/xiezhen.html\">写真</a>";
        //            }
        //            else if (_NewClassId == 68)
        //            {
        //                return "<a href=\"http://www.8to28.com/pic/\">美图频道</a>&gt;<a href=\"http://www.8to28.com/pic/bizhi.html\">壁纸</a>";
        //            } return "<a href=\"http://www.8to28.com/news/\">资讯大全</a>&gt;详细信息";
        //        }
        //        /// <summary>
        //        /// 根据新闻分类获取新闻分类名称
        //        /// </summary>
        //        /// <param name="_NewClassId"></param>
        //        /// <returns></returns>
        //        public static string GetClassName(int _NewClassId)
        //        {
        //            if (_NewClassId == 30)
        //            {
        //                return "大陆明星_明星频道";
        //            }
        //            else if (_NewClassId == 31)
        //            {
        //                return "港澳台明星_明星频道";
        //            }
        //            else if (_NewClassId == 32)
        //            {
        //                return "欧美明星_明星频道";
        //            }
        //            else if (_NewClassId == 33)
        //            {
        //                return "日韩明星_明星频道";
        //            }
        //            else if (_NewClassId == 34)
        //            {
        //                return "时尚频道";
        //            }
        //            else if (_NewClassId == 38)
        //            {
        //                return "生活频道";
        //            }
        //            else if (_NewClassId == 42)
        //            {
        //                return "青春频道";
        //            }
        //            else if (_NewClassId == 46)
        //            {
        //                return "两性频道";
        //            }
        //            else if (_NewClassId == 50)
        //            {
        //                return "情感频道";
        //            }
        //            else if (_NewClassId == 54)
        //            {
        //                return "创业频道";
        //            }
        //            else if (_NewClassId == 58)
        //            {
        //                return "IT/科技频道";
        //            }
        //            else if (_NewClassId == 62)
        //            {
        //                return "3G/互联网频道";
        //            }
        //            else if (_NewClassId == 66)
        //            {
        //                return "模特图片_美图频道";
        //            }
        //            else if (_NewClassId == 67)
        //            {
        //                return "写真图片_美图频道";
        //            }
        //            else if (_NewClassId == 68)
        //            {
        //                return "图片壁纸_美图频道";
        //            } return "资讯大全";
        //        }
        //        /// <summary>
        //        /// 根据运动鞋分类获取运动鞋分类名称
        //        /// </summary>
        //        /// <param name="_NewClassId"></param>
        //        /// <returns></returns>
        //        public static string GetProductClassName(int _ProClassId)
        //        {
        //            if (_ProClassId == 1)
        //            {
        //                return "正品运动男鞋";
        //            }
        //            else if (_ProClassId == 2)
        //            {
        //                return "正品运动女鞋";
        //            }
        //            else if (_ProClassId == 5)
        //            {
        //                return "时尚搭配/流行配饰";
        //            } return "正品运动鞋";
        //        }

        //        /// <summary>
        //        /// 获取资讯详细信息分页字符串
        //        /// </summary>
        //        /// <param name="currentpage">当前页</param>
        //        /// <param name="pagecount">要分页的数量</param>
        //        /// <param name="newid">资讯id</param>
        //        /// <returns></returns>
        //        public static string GetNewsNavStr(int currentpage, int pagecount, int newid)
        //        {
        //            if (pagecount > 1 && newid > 0)
        //            {
        //                string navstring = " <a href=\"newinfo.aspx?nid=" + newid + "&page=1\">首页</a> <a href=\"newinfo.aspx?nid=" + newid + "&page=" + (currentpage - 1) + "\">上一页</a>";

        //                for (int i = 1; i < pagecount + 1; i++)
        //                {
        //                    navstring += (currentpage == i ? " <strong>" + i + "</strong>" : " <a href=\"newinfo.aspx?nid=" + newid + "&page=" + i + "\">" + i + "</a>");
        //                }
        //                return navstring + " <a href=\"newinfo.aspx?nid=" + newid + "&page=" + (currentpage + 1) + "\">下一页</a> <a href=\"newinfo.aspx?nid=" + newid + "&page=" + pagecount + "\">尾页</a>";
        //            }
        //            else
        //                return "";
        //        }

        /// <summary>
        /// 检测该字符串是否安全
        /// </summary>
        /// <param name="checkText">要检查的文本</param>
        /// <returns></returns>
        public static bool IsSafeRequestString(string checkText)
        {
            //说明：不能存在'+空格的存在，并且，不能有空格+字符+空格的命令存在
            string sqlString = @" |and|exec|insert|select|delete|update|count|\*|\%|chr|mid|master|truncate|char|declare|from|drop|char|xp_cmdshell|exec master|net localgroup administrators|not user|or|net|-|<|>|'|""|script";
            bool isSafe = true;
            for (int i = 0; i < sqlString.Split('|').Length; i++)
            {
                if (checkText.ToLower().IndexOf(sqlString.Split('|')[i]) > 0)
                {
                    isSafe = false; break;//发现不安全字符，退出循环，直接返回
                }
            }
            return isSafe;
        }


        //        /**
        //            1.Tables :表名称,视图
        //            2.PrimaryKey :主关键字
        //            3.Sort :排序语句，不带Order By 比如：NewsID Desc,OrderRows Asc
        //            4.CurrentPage :当前页码
        //            5.PageSize :分页尺寸
        //            6.Filter :过滤语句，不带Where 
        //            7.Group :Group语句,不带Group By
        //         **/
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="rpt"></param>
        //        /// <param name="ht"></param>
        //        /// <param name="TabName"></param>
        //        /// <param name="PrimaryKey"></param>
        //        /// <param name="Sort"></param>
        //        /// <param name="CurrentPage"></param>
        //        /// <param name="PageSize"></param>
        //        /// <param name="Filter"></param>
        //        /// <param name="GroupBy"></param>
        //        /// <returns></returns>
        //        public static string GetPaging(Repeater rpt, Hashtable ht, string TabName, string PrimaryKey, string Fields, string Filter, string Sort, string Group, int CurrentPage, int PageSize)
        //        {
        //            DataTable _Dt = new DataAccess.DA_RunSql().GetPaging(TabName, PrimaryKey, Fields, Filter, Sort, Group, CurrentPage, PageSize);
        //            int RowCount = new DataAccess.DA_RunSql().GetRowCount(TabName, Filter);//总共数据记录数
        //            int allpage = RowCount % PageSize == 0 ? RowCount / PageSize : (RowCount / PageSize + 1); //总共几页
        //            int page = GetQueryInt("page", 1);//当前第几页
        //            string pagestr = "第" + page.ToString() + "页/共" + allpage + "页";
        //            int pre = CurrentPage - 1;//上一页
        //            int next = CurrentPage + 1;//下一页

        //            int startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //            //中间页终止序号
        //            int endcount = page < 5 ? 10 : page + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内

        //            /**用hashtable拼接成一个字符串**/
        //            string conditionstring = "";
        //            IDictionaryEnumerator idictory = ht.GetEnumerator();
        //            while (idictory.MoveNext())
        //            {
        //                conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //            }
        //            pagestr += page > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=1\" target=\"_self\">首页</a><a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\" target=\"_self\">上一页</a>" : "";
        //            //中间页处理，这个增加时间复杂度，减小空间复杂度
        //            for (int i = startcount; i <= endcount; i++)
        //            {
        //                pagestr += page == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\" target=\"_self\">" + i + "</a>";
        //            }
        //            pagestr += page != allpage ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\" target=\"_self\">下一页</a><a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + allpage + "\" target=\"_self\">末页</a>" : "";


        //            //绑定到数据显示控件 
        //            rpt.DataSource = _Dt;
        //            rpt.DataBind();
        //            return pagestr;
        //        }

        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="rpt"></param>
        //        /// <param name="ht"></param>
        //        /// <param name="TabName"></param>
        //        /// <param name="PrimaryKey"></param>
        //        /// <param name="Sort"></param>
        //        /// <param name="CurrentPage"></param>
        //        /// <param name="PageSize"></param>
        //        /// <param name="Filter"></param>
        //        /// <param name="GroupBy"></param>
        //        /// <returns></returns>
        //        public static string GetPaging(Repeater rpt, Hashtable ht, string TabName, string PrimaryKey, string Fields, string Filter, string Sort, string Group, int CurrentPage, int PageSize, string CacheName)
        //        {
        //            DataTable _Dt = new DataTable();
        //            CacheName = CacheName + "_" + CurrentPage;
        //            if (HttpContext.Current.Cache[CacheName] == null)
        //            {
        //                _Dt = new DataAccess.DA_RunSql().GetPaging(TabName, PrimaryKey, Fields, Filter, Sort, Group, CurrentPage, PageSize);
        //                HttpContext.Current.Cache.Add(CacheName, _Dt, null, DateTime.Now.AddHours(2), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
        //            }
        //            else
        //            {
        //                if ((HttpContext.Current.Cache[CacheName] as DataTable).Rows.Count == 0)
        //                {
        //                    _Dt = new DataAccess.DA_RunSql().GetPaging(TabName, PrimaryKey, Fields, Filter, Sort, Group, CurrentPage, PageSize);
        //                    HttpContext.Current.Cache.Add(CacheName, _Dt, null, DateTime.Now.AddHours(2), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
        //                }
        //                else
        //                    _Dt = HttpContext.Current.Cache[CacheName] as DataTable;
        //            }
        //            int RowCount = new DataAccess.DA_RunSql().GetRowCount(TabName, Filter);//总共数据记录数
        //            int allpage = RowCount % PageSize == 0 ? RowCount / PageSize : (RowCount / PageSize + 1); //总共几页
        //            int page = GetQueryInt("page", 1);//当前第几页
        //            string pagestr = "Total：" + page.ToString() + "&nbsp;/&nbsp;" + allpage + "&nbsp;&nbsp;";
        //            int pre = CurrentPage - 1;//上一页
        //            int next = CurrentPage + 1;//下一页

        //            int startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //            //中间页终止序号
        //            int endcount = page < 5 ? 10 : page + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内

        //            /**用hashtable拼接成一个字符串**/
        //            string conditionstring = "";
        //            if (ht != null)
        //            {
        //                IDictionaryEnumerator idictory = ht.GetEnumerator();
        //                while (idictory.MoveNext())
        //                {
        //                    conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //                }
        //            }
        //            pagestr += page > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\" target=\"_self\">&lt;上一页</a>" : "";
        //            //中间页处理，这个增加时间复杂度，减小空间复杂度
        //            for (int i = startcount; i <= endcount; i++)
        //            {
        //                pagestr += page == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\" target=\"_self\">" + i + "</a>";
        //            }
        //            pagestr += page != allpage ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\" target=\"_self\">下一页&gt;</a>" : "";


        //            //绑定到数据显示控件 
        //            rpt.DataSource = _Dt;
        //            rpt.DataBind();
        //            return pagestr;
        //        }

        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="rpt"></param>
        //        /// <param name="ht"></param>
        //        /// <param name="TabName"></param>
        //        /// <param name="PrimaryKey"></param>
        //        /// <param name="Sort">a desc "|| b asc</param>
        //        /// <param name="CurrentPage"></param>
        //        /// <param name="PageSize"></param>
        //        /// <param name="Filter"></param>
        //        /// <param name="GroupBy"></param>
        //        /// <returns></returns>
        //        public static string GetPaging(Repeater rpt, Hashtable _Ht, string TabName, string PrimaryKey, string Fields, string Filter, string Sort, string Group, int _CurrentPage, int PageSize, string CacheName, bool IsRewrite, string PageUrl)
        //        {
        //            DataTable _Dt = new DataTable();
        //            CacheName = CacheName + "_" + _CurrentPage;
        //            if (HttpContext.Current.Cache[CacheName] == null)
        //            {
        //                _Dt = new DataAccess.DA_RunSql().GetPaging(TabName, PrimaryKey, Fields, Filter, Sort, Group, _CurrentPage, PageSize);
        //                HttpContext.Current.Cache.Add(CacheName, _Dt, null, DateTime.Now.AddHours(2), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
        //            }
        //            else
        //            {
        //                if ((HttpContext.Current.Cache[CacheName] as DataTable).Rows.Count == 0)
        //                {
        //                    _Dt = new DataAccess.DA_RunSql().GetPaging(TabName, PrimaryKey, Fields, Filter, Sort, Group, _CurrentPage, PageSize);
        //                    HttpContext.Current.Cache.Add(CacheName, _Dt, null, DateTime.Now.AddHours(2), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
        //                }
        //                else
        //                    _Dt = HttpContext.Current.Cache[CacheName] as DataTable;
        //            }
        //            int RowCount = new DataAccess.DA_RunSql().GetRowCount(TabName, Filter);//总共数据记录数
        //            int allpage = RowCount % PageSize == 0 ? RowCount / PageSize : (RowCount / PageSize + 1); //总共几页
        //            int page = _CurrentPage;//当前第几页
        //            string pagestr = "Total：" + page.ToString() + "&nbsp;/&nbsp;" + allpage + "&nbsp;&nbsp;";
        //            int pre = _CurrentPage - 1;//上一页
        //            int next = _CurrentPage + 1;//下一页

        //            int startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //            //中间页终止序号
        //            int endcount = page < 5 ? 10 : page + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内

        //            if (RowCount > 0)
        //            {
        //                if (IsRewrite)
        //                {  /**用hashtable拼接成一个字符串**/
        //                    string conditionstring = "";
        //                    if (_Ht != null)
        //                    {
        //                        IDictionaryEnumerator idictory = _Ht.GetEnumerator();
        //                        while (idictory.MoveNext())
        //                        {
        //                            conditionstring += idictory.Value.ToString() + "_";
        //                        }
        //                    }
        //                    if (conditionstring.Trim() == "")
        //                        conditionstring = "_";

        //                    pagestr += _CurrentPage > 1 ? "<a href=\"" + PageUrl + conditionstring + "1.html\" target=\"_self\">首页</a><a href=\"" + PageUrl + conditionstring + pre + ".html\" target=\"_self\">上一页</a>" : "";
        //                    //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                    for (int i = startcount; i <= endcount; i++)
        //                    {
        //                        pagestr += _CurrentPage == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + PageUrl + conditionstring + i + ".html\" target=\"_self\">" + i + "</a>";
        //                    }
        //                    pagestr += _CurrentPage != allpage ? "<a href=\"" + PageUrl + conditionstring + next + ".html\" target=\"_self\">下一页</a><a href=\"" + PageUrl + conditionstring + allpage + ".html\" target=\"_self\">末页</a>" : "";

        //                }
        //                else
        //                {   /**用hashtable拼接成一个字符串**/
        //                    string conditionstring = "";
        //                    if (_Ht != null)
        //                    {
        //                        IDictionaryEnumerator idictory = _Ht.GetEnumerator();
        //                        while (idictory.MoveNext())
        //                        {
        //                            conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //                        }
        //                    }

        //                    pagestr += page > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\" target=\"_self\">&lt;上一页</a>" : "";
        //                    //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                    for (int i = startcount; i <= endcount; i++)
        //                    {
        //                        pagestr += page == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\" target=\"_self\">" + i + "</a>";
        //                    }
        //                    pagestr += page != allpage ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\" target=\"_self\">下一页&gt;</a>" : "";
        //                }
        //            }

        //            //绑定到数据显示控件 
        //            rpt.DataSource = _Dt;
        //            rpt.DataBind();
        //            return pagestr;
        //        }



        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="_RowCount"></param>
        //        /// <param name="_Ht"></param>
        //        /// <param name="_CurrentPage"></param>
        //        /// <param name="_PageSize"></param>
        //        /// <returns></returns>
        //        public static string GetPaging(bool IsRewrite, string PageUrl, int _RowCount, Hashtable _Ht, int _CurrentPage, int _PageSize)
        //        {
        //            int allpage = _RowCount % _PageSize == 0 ? _RowCount / _PageSize : (_RowCount / _PageSize + 1); //总共几页
        //            //int page = GetQueryInt("page", 1);//当前第几页
        //            string pagestr = "第" + _CurrentPage.ToString() + "页/共" + allpage + "页";
        //            int pre = _CurrentPage - 1;//上一页
        //            int next = _CurrentPage + 1;//下一页

        //            int startcount = (_CurrentPage + 5) > allpage ? allpage - 9 : _CurrentPage - 4;//中间页起始序号
        //            //中间页终止序号
        //            int endcount = _CurrentPage < 5 ? 10 : _CurrentPage + 5;
        //            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        //            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内

        //            if (IsRewrite)
        //            {  /**用hashtable拼接成一个字符串**/
        //                string conditionstring = "";
        //                if (_Ht != null)
        //                {
        //                    IDictionaryEnumerator idictory = _Ht.GetEnumerator();
        //                    while (idictory.MoveNext())
        //                    {
        //                        conditionstring += idictory.Value.ToString() + "_";
        //                    }
        //                }
        //                pagestr += _CurrentPage > 1 ? "<a href=\"" + PageUrl + conditionstring + "1.html\" target=\"_self\">首页</a><a href=\"" + PageUrl + conditionstring + pre + ".html\" target=\"_self\">上一页</a>" : "";
        //                //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                for (int i = startcount; i <= endcount; i++)
        //                {
        //                    pagestr += _CurrentPage == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + PageUrl + conditionstring + i + ".html\" target=\"_self\">" + i + "</a>";
        //                }
        //                pagestr += _CurrentPage != allpage ? "<a href=\"" + PageUrl + conditionstring + next + ".html\" target=\"_self\">下一页</a><a href=\"" + PageUrl + conditionstring + allpage + ".html\" target=\"_self\">末页</a>" : "";

        //            }
        //            else
        //            {
        //                /**用hashtable拼接成一个字符串**/
        //                string conditionstring = "";
        //                if (_Ht != null)
        //                {
        //                    IDictionaryEnumerator idictory = _Ht.GetEnumerator();
        //                    while (idictory.MoveNext())
        //                    {
        //                        conditionstring += idictory.Key.ToString() + "=" + idictory.Value.ToString() + "&";
        //                    }
        //                }
        //                pagestr += _CurrentPage > 1 ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=1\" target=\"_self\">首页</a><a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + pre + "\" target=\"_self\">上一页</a>" : "";
        //                //中间页处理，这个增加时间复杂度，减小空间复杂度
        //                for (int i = startcount; i <= endcount; i++)
        //                {
        //                    pagestr += _CurrentPage == i ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + i + "\" target=\"_self\">" + i + "</a>";
        //                }
        //                pagestr += _CurrentPage != allpage ? "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + next + "\" target=\"_self\">下一页</a><a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?" + conditionstring + "page=" + allpage + "\" target=\"_self\">末页</a>" : "";
        //            }
        //            return pagestr;
        //        }
        //*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prostr">快递所到省份 例如：北京市、天津市、上海市、江苏省、浙江省、海南省</param>
        /// <param name="totalcount">商品总数量 加件价格另算</param>
        /// <returns></returns>
        public static int GetPostPrice(string prostr, int totalcount)
        {
            int kuaidi = 500;//快递费默认 500元

            prostr = prostr.Trim();

            if (prostr == "上海市" || prostr == "江苏省" || prostr == "浙江省")
            {
                kuaidi = 5;//普通快件 数量1件
                if (totalcount > 1)
                {
                    kuaidi += totalcount * 3;//江浙沪加件3元
                }
            }
            else if (prostr == "北京市" || prostr == "天津市" || prostr == "安徽省")
            {
                kuaidi = 8;//普通快件 数量1件
                if (totalcount > 1)
                {
                    kuaidi += totalcount * 6;//加件6元
                }
            }
            else if (prostr == "河南省" || prostr == "河北省" || prostr == "山西省" || prostr == "山东省" || prostr == "湖南省" || prostr == "湖北省" || prostr == "重庆市" || prostr == "福建省" || prostr == "江西省")
            {
                kuaidi = 12;//普通快件 数量1件
                if (totalcount > 1)
                {
                    kuaidi += totalcount * 8;//加件8元
                }
            }
            else if (prostr == "广东省" || prostr == "广西壮族自治区" || prostr == "海南省" || prostr == "陕西省" || prostr == "甘肃省" || prostr == "宁夏回族自治区" || prostr == "广西壮族自治区" || prostr == "吉林省" || prostr == "辽宁省" || prostr == "黑龙江省" || prostr == "四川省" || prostr == "云南省" || prostr == "贵州省")
            {
                kuaidi = 16;//普通快件 数量1件
                if (totalcount > 1)
                {
                    kuaidi += totalcount * 13;//加件13元
                }
            }
            else if (prostr == "新疆维吾尔自治区" || prostr == "西藏自治区" || prostr == "青海省" || prostr == "内蒙古自治区")
            {
                kuaidi = 20;//普通快件 数量1件
                if (totalcount > 1)
                {
                    kuaidi += totalcount * 18;//加件18元
                }
            }
            else if (prostr == "香港特别行政区" || prostr == "澳门特别行政区" || prostr == "台湾省")
            {
                kuaidi = 150;//普通快件 数量1件
                if (totalcount > 1)
                {
                    kuaidi += totalcount * 130;//加件130元
                }
            }
            return kuaidi;
        }


        /// <summary>
        ///测试用 本地填充登陆用户信息 
        /// </summary>
        public static void GetTestUser()
        {
            //SaveCurrentUserToCookie_Shopping(new DataAccess.DA_gw_Users().GetLoginedUserEntity("17u"));
        }


        /// <summary>
        /// 根据sql获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataBySql(string sql)
        {
            NewsBLL _newBll = new NewsBLL();
            return _newBll.GetDataBySql(sql);
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public static DataTable GetBaseListByCache(int top, string where, string cacheName)
        {
            DataTable dt = new DataTable();
            NewsBLL _newBll = new NewsBLL();

            //
            if (HttpContext.Current.Cache[cacheName] != null)
            {
                dt = HttpContext.Current.Cache[cacheName] as DataTable;
            }
            else
            {
                dt = _newBll.GetBaseList(top, where);
                HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddHours(2), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            return dt;
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public static DataTable GetDataByCache(string sql, string cacheName)
        {
            //
            DataTable dt = new DataTable();
            if (HttpContext.Current.Cache[cacheName] != null)
            {
                dt = HttpContext.Current.Cache[cacheName] as DataTable;
            }
            else
            {
                dt = GetDataBySql(sql);
                HttpContext.Current.Cache.Add(cacheName, dt, null, DateTime.Now.AddHours(2), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            return dt;
        }
    }
}
