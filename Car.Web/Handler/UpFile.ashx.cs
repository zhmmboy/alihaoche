using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Car.Web.Handler
{
    /// <summary>
    /// UpFile 的摘要说明
    /// </summary>
    public class UpFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //保存上传的文件
            SaveFile();

            context.Response.End();
        }

        private void SaveFile()
        {
            if (HttpContext.Current.Request.Files != null &&
                HttpContext.Current.Request.Files.Count > 0)
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[0] as HttpPostedFile;
                string dic = System.DateTime.Now.ToString("yyyyMMdd");
                dic = "../UpFile/News/" + dic;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dic)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dic));
                }
                file.SaveAs(HttpContext.Current.Server.MapPath(dic + "/" + file.FileName));

                HttpContext.Current.Response.Write("success");
            }
            else {
                HttpContext.Current.Response.Write("fail");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}