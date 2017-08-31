using Car.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sub_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            //ManageUserBLL manageuserbll = new ManageUserBLL();
            //ManageUser manageuser = manageuserbll.GetSingleByManageUserName(name);

            if (name != "admin")
            {
               this.ClientScript.RegisterClientScriptBlock(GetType(),"a","alert('帐号不存在!');",true);
                return;
            }
            //if (password != "")
            //{
            //    this.ClientScript.RegisterClientScriptBlock(GetType(), "a", "alert('密码错误!');", true);
            //    return;
            //}

            Session["sys_username"] = name;
            Response.Redirect("Default.aspx");
            Response.End();
        }
    }
}