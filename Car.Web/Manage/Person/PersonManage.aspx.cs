using Car.BLL;
using Car.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.Person
{
    public partial class PersonManage : BasePage
    {
        PersonBLL _PersonBLL = new PersonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClass();
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadClass()
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
            string pClass = this.ddlClass.SelectedItem.Value;
            string pStatus = this.ddlStatus.SelectedItem.Value;
            string pName = this.txtName.Text;
            string sDate = this.txtRegStartDate.Text;
            string eDate = this.txtRegEndDate.Text;

            string where = "1=1";
            if (pClass != "")
            {
                where += " AND classId='" + pClass + "'";
            } if (pStatus != "")
            {
                where += " AND pStatus=" + pStatus + "";
            } if (pName != "")
            {
                where += " AND (pCnName like '%" + pName + "%' OR pEnName like '%" + pName + "%')";
            }

            int totalCount = 0;
            DataTable dt = _PersonBLL.GetPaging(where, "pAddTime", "", pager.PageSize, pager.CurrentPageIndex, out totalCount);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSet_Click(object sender, EventArgs e)
        {
            C_Person _P_Person;
            string Id = this.hidId.Value;

            if (!string.IsNullOrEmpty(Id))
            {
                string[] Ids = Id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < Ids.Length; i++)
                {
                    _P_Person = new C_Person();
                    _P_Person.pStatus = Convert.ToInt32(this.selStatus.Value);
                    _P_Person.pId = new Guid(Ids[i]);
                    _PersonBLL.UpdateStatus(_P_Person);
                }
                LoadData();
                this.ClientScript.RegisterStartupScript(GetType(), "a", "alert('提交成功！')",true);
            }
        }
    }
}