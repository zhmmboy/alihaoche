using Car.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.Tag
{
    public partial class TagAdd : System.Web.UI.Page
    {
        TagsBLL _TagsBLL = new TagsBLL();
        PersonBLL _PersonBLL = new PersonBLL();
        string Id = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            //DataTable dtClass = _PersonBLL.GetBaseList(0, "");
            //this.selPerson.DataSource = dtClass;
            //this.selPerson.DataValueField = "pId";
            //this.selPerson.DataTextField = "pCnName";
            //this.selPerson.DataBind();

            //
            //Id = this.Request.QueryString["Id"];
            //if (!string.IsNullOrEmpty(Id))
            //{
            //    DataTable dtData = _TagsBLL.GetTagById(new Guid(Id));

            //    this.hidimgurl.Value = dtData.Rows[0]["aPhoto"].ToString();
            //    this.txtName.Value = dtData.Rows[0]["aName"].ToString();
            //    this.txtNTags.Value = dtData.Rows[0]["aTags"].ToString();
            //    this.txtIntro.Value = dtData.Rows[0]["aIntro"].ToString();
            //    this.selPerson.Value = dtData.Rows[0]["personId"].ToString();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExists_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //AlbumBLL _AlbumBLL = new AlbumBLL();
            //P_Album _P_Album = new P_Album();

            //_P_Album.aName = this.txtNTitle.Value;
            //_P_Album.aTags = this.txtNTags.Value;
            //_P_Album.aIntro = this.txtIntro.Value;
            //_P_Album.personId = this.selPerson.Value;

            ////文件目录
            //string Folder = Common.SystemVar.UpLoadImgForAlbum;

            ////判断是否有图片上传
            //if (this.fUpImgTitle.FileContent.Length > 0)
            //{
            //    //存储图片的文件夹 页面加载的时候判断该目录 以月份为单位生产图片文件夹
            //    Folder = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff").Substring(0, 17) + System.IO.Path.GetExtension(this.fUpImgTitle.FileName);
            //    //上传图片
            //    this.fUpImgTitle.SaveAs(Server.MapPath(Folder));
            //    _P_Album.aPhoto = Folder;
            //}
            //else
            //{
            //    //图片路径
            //    _P_Album.aPhoto = this.fUpImgTitle.FileName != "" ? Folder.Replace("../../UpFile/Album/", "") : this.hidimgurl.Value;
            //}

            //_P_Album.aClicks = 0;
            //_P_Album.aAddTime = System.DateTime.Now;

            ////
            //if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
            //{
            //    string Id = this.Request.QueryString["Id"].ToString();
            //    _P_Album.aId = new Guid(Id);
            //    _AlbumBLL.Edit(_P_Album);
            //}
            //else
            //{
            //    _P_Album.aId = Guid.NewGuid();
            //    _AlbumBLL.Add(_P_Album);
            //}

            //this.ClientScript.RegisterStartupScript(this.GetType(), "a", "alert('提交成功！')", true);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AlbumManage.aspx");
        }
    }
}