using Car.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();

            string fckname = Request.QueryString["CKEditorFuncNum"];//"CKEditorFuncNum"图片源文件
            HttpPostedFile postedFile = Request.Files["upload"];
            string extension = Path.GetExtension(postedFile.FileName);//获取后续名
            //Stream fs = postedFile.InputStream;//将图片转为字节流
            //long len = fs.Length;
            //Byte[] bytes = new Byte[len];
            //fs.Read(bytes, 0, bytes.Length);
            string md5 = DateTime.Now.ToString("yyyyMMddhhmmssfffff").Substring(0, 17);// EncryptHelper.Md5(bytes);

            string filePath = SystemVar.UpLoadImgForNews;//保存路径
            string savename = string.Format("{0}/{1}{2}", filePath, md5, extension);//路径、文件名、后续名
            string serverFilePath = Server.MapPath(filePath);//获取物理路径
            string filePathname = string.Format("{0}/{1}{2}", serverFilePath, md5, extension);//物理路径、文件名、后续名
            FileHelper.CreateDirForFile(serverFilePath);//判断文件夹是否存在，不存在就创建
            postedFile.SaveAs(filePathname);//将选择的图片保存到物理路径中

            string ret = string.Format("<script type=\"text/javascript\">window.parent.CKEDITOR.tools.callFunction({0},'{1}','');</script>", fckname, savename);
            Response.Write(ret);
            Response.End();
        }
    }
}