using System;
using System.Data;
using System.IO;
using System.Net;
using Car.Entity;
using Car.BLL;
using Car.Common;

namespace Car.Web.Manage.News
{
    public partial class NewsTempAdd : BasePage
    {
        int Id = 0;
        NewsBLL _NewsBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
            {
                Id = Convert.ToInt32(this.Request.QueryString["Id"]);
            }

            _NewsBLL = new NewsBLL();
            if (!IsPostBack)
            {
                if (Id > 0)
                {
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

            this.selCarBrand.DataSource = dtCarBrand;
            this.selCarBrand.DataValueField = "cbId";
            this.selCarBrand.DataTextField = "cbName";
            this.selCarBrand.DataBind();

            DataTable dtCar = new CarBLL().GetList(0, "");
            this.selCar.DataSource = dtCar;
            this.selCar.DataValueField = "cId";
            this.selCar.DataTextField = "cName";
            this.selCar.DataBind();

            DataTable dt = _NewsBLL.GetNewTempById(Id);
            if (dt != null)
            {
                this.txtNTitle.Value = dt.Rows[0]["nTitle"].ToString();
                this.txtNTitleSeo.Value = dt.Rows[0]["nTitleSeo"].ToString();
                this.txtnFrom.Value = dt.Rows[0]["nForm"].ToString();
                this.txtnFromUrl.Value = dt.Rows[0]["nFormUrl"].ToString();
                this.hidimgurl.Value = dt.Rows[0]["nTitlePic"].ToString();
                this.selCarBrand.Value = dt.Rows[0]["nClass1"].ToString();
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
            C_News model = new C_News();
            model.nTitle = this.txtNTitle.Value;
            model.nTitleSeo = this.txtNTitleSeo.Value;
            model.nAuthor = string.Empty;
            model.nForm = this.txtnFrom.Value;
            model.nFormurl = this.txtnFromUrl.Value;
            model.nclass1 = Convert.ToInt32(this.selCarBrand.Value);
            model.nClass2 = 0;
            model.carId = Convert.ToInt32(this.selCar.Value);
            model.nIsRecommand = this.chkRecommand.Checked;
            model.nAddTime = System.DateTime.Now;
            model.nLevel = 0;
            model.nStatus = (short)(chkChecked.Checked ? 1 : 0);

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
                Folder = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + System.IO.Path.GetExtension(this.fUpImgTitle.FileName);
                //上传图片
                this.fUpImgTitle.SaveAs(Server.MapPath(Folder));
                model.nTitlepic = Folder;
            }
            else
            {
                //图片路径
                model.nTitlepic = this.fUpImgTitle.FileName != "" ? Folder.Replace("../../UpFile/News/", "") : this.hidimgurl.Value;
            }
            model.nTips = this.txtTip.Value;

            #region 自动保存图片
            //内容
            model.nContent = SaveUrlPics(this.txtContent.Text.Replace("u148.net", "alihaoche.com"), Folder);
            #endregion
            //标签
            model.nTags = this.txtNTags.Value;
            model.nLinkurl = string.Empty;
            model.nIsPage = false;

            if (Id > 0)
            {
                //如果审核通过
                if (chkChecked.Checked)
                {
                    model.nClicks = 0;
                    model.nTalks = 0;
                    model.nGood = 0;
                    model.nBad = 0;
                    model.nIndex = 0;

                    _NewsBLL.AddNews(model);
                }

                //保存到临时表
                model.nId = Id;
                _NewsBLL.EditNewsTemp(model);
            }
            else
            {
                _NewsBLL.AddNewsTemp(model);
            }
            //把该信息的tag保存到c_Tag表
            if (!string.IsNullOrEmpty(this.txtNTags.Value))
            {
                new TagsBLL().Add(this.txtNTags.Value, model.nId, model.nclass1, Convert.ToInt32(SystemVar.EnumTagType.News));
            }

            this.ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('保存成功！');window.location.href='NewsTempManage.aspx'</script>", false);
        }


        //下载图片到本地
        private string SaveUrlPics(string strHTML, string path)
        {
            string[] imgurlAry = Common.FileHelper.GetImgTag(strHTML);
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
            DataTable _dt = _newBLL.GetBaseList(1, "ntitle like '%" + this.txtNTitle.Value + "%'");
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
            DataTable _dt = _newBLL.GetBaseList(1, "ntitleSeo like '%" + this.txtNTitleSeo.Value + "%'");
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
            this.Response.Redirect("/Manage/News/NewsTempManage.aspx");
        }
    }
}