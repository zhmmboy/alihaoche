using Car.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.Album
{
    public partial class AlbumManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDrop();
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDrop()
        {
            DataTable dtClass = new ClassBLL().GetList(0, "cLevel=1 ORDER BY cOrder");
            this.ddlClass.DataSource = dtClass;
            this.ddlClass.DataValueField = "cId";
            this.ddlClass.DataTextField = "cName";
            this.ddlClass.DataBind();
            this.ddlClass.Items.Insert(0, new ListItem("请选择", ""));
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            AlbumBLL _AlbumBLL = new AlbumBLL();
            string pClass = this.ddlClass.SelectedItem.Value;
            string pName = this.txtName.Text;
            string sDate = this.txtRegStartDate.Text;
            string eDate = this.txtRegEndDate.Text;

            string where = "1=1";
            if (pClass != "")
            {
                where += " AND cId='" + pClass + "'";
            } if (pName != "")
            {
                where += " AND (aName like '%" + pName + "%')";
            }
            if (!string.IsNullOrEmpty(sDate))
            {
                where += " AND aAddTime>='"+sDate+"'";
            } if (!string.IsNullOrEmpty(eDate))
            {
                where += " AND aAddTime<='" + eDate + "'";
            }

            int totalCount = 0;
            DataTable dt = _AlbumBLL.GetPaging(where, "aAddTime", "",pager.PageSize, pager.CurrentPageIndex, out totalCount);

            this.pager.RecordCount = totalCount;
            this.gvList.DataSource = dt;
            this.gvList.DataBind();
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}