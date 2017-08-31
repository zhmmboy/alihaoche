using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car.MvcWeb.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "这是我的第一个动作，加载首页啦";
        }

        /// <summary>
        /// 欢迎来到我的MVC程序世界!
        /// </summary>
        /// <returns></returns>
        public string Welcome(string name,string id)
        {
            return "小伙子(姑娘) "+name+" 您好啊，您今年 "+ id + " 岁了，<br/>欢迎来到我的MVC程序世界!"
                + "用户名：<input type='text' value=''/><br/>密码：<input type='text' value=''/>";
        }
    }
}