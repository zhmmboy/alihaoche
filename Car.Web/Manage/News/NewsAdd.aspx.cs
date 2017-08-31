using System;
using System.Data;
using System.IO;
using System.Net;
using Car.Entity;
using Car.BLL;
using Car.Common;

namespace Car.Web.Manage.News
{
    public partial class NewsAdd : BasePage
    {
        int Id = 0;
        NewsBLL _NewsBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            _NewsBLL = new NewsBLL();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Id"]);
                    LoadData();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            DataTable dtCarBrand = new CarBrandBLL().GetList(0, "(cbParentId=0 OR cbParentId is null) ORDER BY cbOrderIndex");

            this.selClass.DataSource = dtCarBrand;
            this.selClass.DataValueField = "cbId";
            this.selClass.DataTextField = "cbName";
            this.selClass.DataBind();

            DataTable dtCar = new CarBLL().GetList(0, "");
            this.selCar.DataSource = dtCar;
            this.selCar.DataValueField = "cId";
            this.selCar.DataTextField = "cName";
            this.selCar.DataBind();

            DataTable dt = _NewsBLL.GetNewById(Id);
            if (dt != null)
            {
                this.txtNTitle.Value = dt.Rows[0]["nTitle"].ToString();
                this.txtNTitleSeo.Value = dt.Rows[0]["nTitleSeo"].ToString();
                this.txtnFrom.Value = dt.Rows[0]["nForm"].ToString();
                this.txtnFromUrl.Value = dt.Rows[0]["nFormUrl"].ToString();
                this.hidimgurl.Value = dt.Rows[0]["nTitlePic"].ToString();
                this.selClass.Value = dt.Rows[0]["nClass1"].ToString();
                this.selCar.Value = dt.Rows[0]["carId"].ToString();
                this.txtTip.Value = dt.Rows[0]["nTips"].ToString();
                this.txtNTags.Value = dt.Rows[0]["nTags"].ToString();
                this.txtContent.Text = dt.Rows[0]["nContent"].ToString();
                this.chkRecommand.Checked = Convert.ToBoolean(dt.Rows[0]["nIsRecommand"]);

            }
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            C_News _P_News = new C_News();
            _P_News.nTitle = this.txtNTitle.Value;
            _P_News.nTitleSeo = this.txtNTitleSeo.Value;
            _P_News.nAuthor = string.Empty;
            _P_News.nForm = this.txtnFrom.Value;
            _P_News.nFormurl = this.txtnFromUrl.Value;
            _P_News.nclass1 = Convert.ToInt32(this.selClass.Value);
            _P_News.nClass2 = 0;
            _P_News.carId = Convert.ToInt32(this.selCar.Value);
            _P_News.nIsRecommand = this.chkRecommand.Checked;
            _P_News.nAddTime = System.DateTime.Now;
            _P_News.nLevel = 0;

            //文件目录
            string Folder = Common.SystemVar.UpLoadImgForNews;
            //如果该目录不存在，则创建该目录
            if (!Directory.Exists(Server.MapPath(Folder)))
            {
                Directory.CreateDirectory(Server.MapPath(Folder));
            }
            //判断是否有图片上传
            if (this.fUpImgTitle.FileContent.Length > 0)
            {
                //存储图片的文件夹 页面加载的时候判断该目录 以月份为单位生产图片文件夹
                Folder = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff")+ System.IO.Path.GetExtension(this.fUpImgTitle.FileName);
                //上传图片
                this.fUpImgTitle.SaveAs(Server.MapPath(Folder));
                _P_News.nTitlepic = Folder;
            }
            else
            {
                //图片路径
                _P_News.nTitlepic = this.fUpImgTitle.FileName != "" ? Folder.Replace("../../UpFile/News/", "") : this.hidimgurl.Value;
            }
            _P_News.nTips = this.txtTip.Value;

            #region 自动保存图片
            //内容
            _P_News.nContent = SaveUrlPics(this.txtContent.Text.Replace("u148.net", "alihaoche.com"), Folder);
            #endregion
            //标签
            _P_News.nTags = this.txtNTags.Value;
            _P_News.nLinkurl = string.Empty;
            _P_News.nIsPage = false;

            if (Id>0)
            {
                _P_News.nId = Id;
                _NewsBLL.EditNews(_P_News);
            }
            else
            {
                _NewsBLL.AddNews(_P_News);
            }
            //把该信息的tag保存到c_Tag表
            if (!string.IsNullOrEmpty(this.txtNTags.Value))
            {
                new TagsBLL().Add(this.txtNTags.Value, _P_News.nId, _P_News.nclass1, Convert.ToInt32(SystemVar.EnumTagType.News));
            }

            this.ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('保存成功！');window.location.href='NewsManage.aspx'</script>", false);
        }


        //下载图片到本地
        private string SaveUrlPics(string strHTML, string path)
        {
            string[] imgurlAry =Common.FileHelper.GetImgTag(strHTML);
            try
            {
                for (int i = 0; i < imgurlAry.Length; i++)
                {
                    if (imgurlAry[i].IndexOf("www.alihaoche.com") < 0 || imgurlAry[i].IndexOf("../../UpFile/News/") < 0)
                    {

                        //WebRequest req = WebRequest.Create(imgurlAry[i]);
                        string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfffff").Substring(0, 17);
                        WebClient wc = new WebClient();
                        if (imgurlAry[i] != "")
                        {
                            wc.DownloadFile(imgurlAry[i], Server.MapPath(path) + "/" + fileName + imgurlAry[i].Substring(imgurlAry[i].LastIndexOf(".")));
                            //替换原图片地址
                            string imgPath = path + "/" + fileName;
                            //ddl.Items.Add(imgPath + "/" + fileName + imgurlAry[i].Substring(imgurlAry[i].LastIndexOf(".")));
                            strHTML = strHTML.Replace(imgurlAry[i], imgPath + imgurlAry[i].Substring(imgurlAry[i].LastIndexOf(".")));
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch
            {
                //return ex.Message;
            }
            return strHTML;
        }        

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExists_Click(object sender, EventArgs e)
        {
            BLL.NewsBLL _newBLL = new NewsBLL();
            DataTable _dt = _newBLL.GetBaseList(1, "ntitle like '%" + this.txtNTitleSeo.Value + "%'");
            if (_dt != null && _dt.Rows.Count > 0)
            {
                this.spTip.InnerHtml = "该资讯已经存在!";
            }
            else
            {
                this.spTip.InnerHtml = "可以添加!";
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExistsSeo_Click(object sender, EventArgs e)
        {
            BLL.NewsBLL _newBLL = new NewsBLL();
            DataTable _dt = _newBLL.GetBaseList(1, "ntitleSeo like '%" + this.txtNTitle.Value + "%'");
            if (_dt != null && _dt.Rows.Count > 0)
            {
                this.spTipSeo.InnerHtml = "该资讯已经存在!";
            }
            else
            {
                this.spTipSeo.InnerHtml = "可以添加!";
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("/Manage/News/NewsManage.aspx");
        }
    }
}