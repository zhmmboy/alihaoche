using Car.BLL;
using Car.Common;
using Car.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.Album
{
    public partial class AlbumInfoAdd : BasePage
    {
        PersonBLL _PersonBLL = new PersonBLL();
        AlbumBLL _AlbumBLL = new AlbumBLL();
        string ablumId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ablumId = this.Request.QueryString["Id"];

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(ablumId))
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            //相册信息
            DataTable dt = _AlbumBLL.GetAlbumById(new Guid(ablumId));

            if (dt != null && dt.Rows.Count > 0)
            {
                this.imgPersonUrl.Src = dt.Rows[0]["pPhoto"].ToString();
                this.imgAlbumUrl.Src = dt.Rows[0]["aPhoto"].ToString();
                this.spPersonName.InnerText = dt.Rows[0]["pCnName"].ToString();
                this.spAlbumName.InnerText = dt.Rows[0]["aName"].ToString();

                //相片信息
                DataTable dtAlbumInfo = _AlbumBLL.GetAlbumInfoById(new Guid(ablumId));

                string id = string.Empty;
                string text = string.Empty;
                string url = string.Empty;
                //
                for (int i = 0; i < dtAlbumInfo.Rows.Count; i++)
                {
                    id += dtAlbumInfo.Rows[i]["aiId"].ToString() + "|";
                    text += dtAlbumInfo.Rows[i]["aiDesc"].ToString() + "|";
                    url += dtAlbumInfo.Rows[i]["aiUrl"].ToString() + "|";
                }

                this.hidId.Value = id;
                this.hidtext.Value = text;
                this.hidUrl.Value = url;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<C_AlbumInfo> lstAlbumInfo = new List<C_AlbumInfo>();
            C_AlbumInfo _P_AlbumInfo;

            string[] hidIdStr = this.hidId.Value.Split('|');
            string[] hidtextStr = this.hidtext.Value.Split('|');
            string[] hidActionStr = this.hidAction.Value.Split('|');
            string[] hidUrlStr = this.hidAction.Value.Split('|');

            for (int i = 0; i < hidIdStr.Length - 1; i++)
            {
                _P_AlbumInfo = new C_AlbumInfo();
                _P_AlbumInfo.aiId = hidIdStr[i].Trim() != "" ? new Guid(hidIdStr[i]) : Guid.NewGuid();

                string Folder = SystemVar.UpLoadImgForAlbum;
                if (this.Request.Files[i] != null)
                {
                    Folder = SystemVar.GetNewName(true, Folder, System.IO.Path.GetExtension(this.Request.Files[i].FileName));
                    //上传图片
                    this.Request.Files[i].SaveAs(Server.MapPath(Folder));
                    _P_AlbumInfo.aiUrl = Folder;
                }
                else
                {
                    _P_AlbumInfo.aiUrl = hidUrlStr[i];
                }

                _P_AlbumInfo.albumId = new Guid(ablumId);
                _P_AlbumInfo.aiDesc = hidtextStr[i];
                _P_AlbumInfo.aiAddTime = System.DateTime.Now;
                _P_AlbumInfo.aiAction = hidActionStr[i];

                lstAlbumInfo.Add(_P_AlbumInfo);
            }

            _AlbumBLL.EditAblumInfo(lstAlbumInfo);

            this.ClientScript.RegisterStartupScript(this.GetType(), "a", "alert('提交成功！');window.location.href='AlbumInfoManage.aspx'", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("/manage/album/albummanage.aspx");
        }
    }
}