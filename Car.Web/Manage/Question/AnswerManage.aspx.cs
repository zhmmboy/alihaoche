using Car.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.Question
{
    public partial class AnswerManage : BasePage
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
            string qId = this.Request.QueryString["Id"];
            AnswerBLL _AnswerBLL = new AnswerBLL();

            //判断是否有删除操作
            if (!string.IsNullOrEmpty(Request.QueryString["action"]) && Request.QueryString["action"].Equals("del"))
            {
                _AnswerBLL.Delete(new Guid(qId));
            }
           
            string pClass = this.ddlClass.SelectedItem.Value;
            string pName = this.txtName.Text;
            string sDate = this.txtRegStartDate.Text;
            string eDate = this.txtRegEndDate.Text;

            string where = "1=1";
            if (qId != "")
            {
                where += " AND qId='"+qId+"'";
            } if (pName != "")
            {
                where += " AND (qTitle like '%" + pName + "%')";
            }
            if (!string.IsNullOrEmpty(sDate))
            {
                where += " AND aAddTime>='" + sDate + "'";
            } if (!string.IsNullOrEmpty(eDate)) 
            {
                where += " AND aAddTime<='" + eDate + "'";
            }

            int totalCount = 0;
            DataTable dt = _AnswerBLL.GetPaging(where,"aAddTime", "", pager.CurrentPageIndex,pager.PageSize, out totalCount);

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