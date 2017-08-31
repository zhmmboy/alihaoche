using Car.BLL;
using Car.Common;
using Car.Entity;
using System;
using System.Data;

namespace Car.Web.Manage.Album
{
    public partial class AlbumAdd :BasePage
    {
        AlbumBLL _AlbumBLL = new AlbumBLL();
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
            DataTable dtClass = new ClassBLL().GetList(0, "cLevel=1 ORDER BY cOrder");
            this.selClass.DataSource = dtClass;
            this.selClass.DataValueField = "cId";
            this.selClass.DataTextField = "cName";
            this.selClass.DataBind();

            DataTable dtPerson = _PersonBLL.GetBaseList(0, "");
            this.selPerson.DataSource = dtPerson;
            this.selPerson.DataValueField = "pId";
            this.selPerson.DataTextField = "pCnName";
            this.selPerson.DataBind();

            //
            Id = this.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                DataTable dtData = _AlbumBLL.GetAlbumById(new Guid(Id));

                this.hidimgurl.Value = dtData.Rows[0]["aPhoto"].ToString();
                this.txtNTitle.Value = dtData.Rows[0]["aName"].ToString();
                this.txtNTags.Value = dtData.Rows[0]["aTags"].ToString();
                this.txtIntro.Value = dtData.Rows[0]["aIntro"].ToString();
                this.selPerson.Value = dtData.Rows[0]["personId"].ToString();
            }
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
            AlbumBLL _AlbumBLL = new AlbumBLL();
            C_Album _P_Album = new C_Album();

            _P_Album.aName = this.txtNTitle.Value;
            _P_Album.aTags = this.txtNTags.Value;
            _P_Album.aIntro = this.txtIntro.Value;
            _P_Album.personId = this.selPerson.Value;
            _P_Album.classId =new Guid(this.selClass.Value);


            //文件目录
            string Folder = Common.SystemVar.UpLoadImgForAlbum;

            //判断是否有图片上传
            if (this.fUpImgTitle.FileContent.Length > 0)
            {
                //存储图片的文件夹 页面加载的时候判断该目录 以月份为单位生产图片文件夹
                Folder = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + System.IO.Path.GetExtension(this.fUpImgTitle.FileName);
                //上传图片
                this.fUpImgTitle.SaveAs(Server.MapPath(Folder));
                _P_Album.aPhoto = Folder;
            }
            else
            {
                //图片路径
                _P_Album.aPhoto = this.fUpImgTitle.FileName != "" ? Folder.Replace("/UpFile/Album/", "") : this.hidimgurl.Value;
            }

            _P_Album.aClicks = 0;
            _P_Album.aAddTime = System.DateTime.Now;

            //
            if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
            {
                string Id = this.Request.QueryString["Id"].ToString();
                _P_Album.aId = new Guid(Id);
                _AlbumBLL.Edit(_P_Album);
            }
            else
            {
                _P_Album.aId = Guid.NewGuid();
                _AlbumBLL.Add(_P_Album);
            }

            //把该信息的tag保存到p_Tag表
            if (!string.IsNullOrEmpty(this.txtNTags.Value))
            {
                //new TagsBLL().Add(this.txtNTags.Value, _P_Album.aId,_P_Album.classId,Convert.ToInt32(SystemVar.EnumTagType.Album));
            }

            this.ClientScript.RegisterStartupScript(this.GetType(), "a", "alert('提交成功！');window.location.href='AlbumManage.aspx'", true);

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