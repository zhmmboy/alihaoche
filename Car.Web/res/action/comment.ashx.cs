using Car.BLL;
using Car.Common;
using Car.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Web.res.action
{
    /// <summary>
    /// comment 的摘要说明
    /// </summary>
    public class comment : IHttpHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            HttpContext.Current.Response.ContentType = "text/plain";

            //获取留言类型 1：评论  2：留言 3：回答问题
            string type = HttpContext.Current.Request["comment_type"];

            if (!string.IsNullOrEmpty(type))
            {
                //提交
                Commit(type);
            }

            context.Response.End();
        }

        /// <summary>
        /// 提交用户留言
        /// </summary>
        private void Commit(string type)
        {
            string author = HttpContext.Current.Request["author"];
            string email = HttpContext.Current.Request["email"];
            string url = HttpContext.Current.Request["url"];
            string comment = HttpContext.Current.Request["comment"];

            if (type == "1" || type == "2")
            {
                C_Comment _P_Comment = new C_Comment();

                _P_Comment.cId = Guid.NewGuid();
                _P_Comment.cParentid = SystemVar.SystemGuid;
                _P_Comment.cAuthor = author;
                _P_Comment.cUrl = url;
                _P_Comment.cEmail = email;
                _P_Comment.cContent = comment;
                _P_Comment.cStatus = 0;
                _P_Comment.cType = Convert.ToInt32(type);                                           //类型 1:评论  2：留言
                _P_Comment.cAddTime = DateTime.Now;

                CommentBLL _CommentBLL = new CommentBLL();
                _CommentBLL.Add(_P_Comment);
            }
            else
            {

                AnswerBLL _AnswerBLL = new AnswerBLL();
                C_Answer _P_Answer = new C_Answer();

                _P_Answer.aContent = comment;
                _P_Answer.aNickName = author;
                _P_Answer.aEmail = email;

                _AnswerBLL.Add(_P_Answer);
            }

            HttpContext.Current.Response.Write("<span class=\"comt-f\">#1</span><div class=\"comt-avatar\">");
            HttpContext.Current.Response.Write(" <img alt=\"\" data-src=\"http://www.alihaoche.com/res/image/avatar-default.png\" class=\"avatar avatar-50 photo\" height=\"50\" width=\"50\" src=\"http://www.alihaoche.com/res/image/avatar-default.png\" style=\"display: block;\"></div>");
            HttpContext.Current.Response.Write(" <div class=\"comt-main\" id=\"div-comment-11193\">" + comment + "<div class=\"comt-meta\"><span class=\"comt-author\"><a href=\"http://" + url.Replace("http://", "") + "/\" rel=\"external nofollow\" class=\"url\" target=\"_blank\">" + author + "</a></span><time>" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "</time><a class=\"comment-reply-link\" href=\"javascript:;\" onclick=\"return addComment.moveForm(&quot;div-comment-11193&quot;, &quot;11193&quot;, &quot;respond&quot;, &quot;14297&quot;)\">回复</a></div>");
            HttpContext.Current.Response.Write("</div>");
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
    }
}