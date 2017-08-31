using Car.BLL;
using Car.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Web.res.action
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {
        ReturnInfo returnInfo;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string type = context.Request["type"];
            Guid id = new Guid(context.Request["id"].ToString());
            int count = 0;

            switch (type)
            {
                case "person": count = submitPerson(id); break;
                case "news": count = submitNews(id); break;
                case "album": count = submitAlbum(id); break;
                case "question": count = submitQuestion(id); break;
            }

            returnInfo = new ReturnInfo();
            returnInfo.response = count.ToString();

            context.Response.Write(JsonHelper.Serialize(returnInfo));
            context.Response.End();
        }

        private int submitPerson(Guid id)
        {
            PersonBLL _PersonBLL = new PersonBLL();
            return _PersonBLL.ClickGood(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private int submitQuestion(Guid id)
        {
            QuestionBLL _QuestionBLL = new QuestionBLL();
            return _QuestionBLL.ClickGood(id);
        }

        private int submitAlbum(Guid id)
        {
            AlbumBLL _AlbumBLL = new AlbumBLL();
            return _AlbumBLL.ClickGood(id);
        }

        private int submitNews(Guid id)
        {
            NewsBLL _NewsBLL = new NewsBLL();
            return _NewsBLL.ClickGood(id);
        }

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
            public string response { get; set; }
        }
    }
}