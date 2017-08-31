<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeWord.aspx.cs" Inherits="Car.Web.Manage.ChangeWord.ChangeWord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="/Manage/res/js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">
        function checkForm() {
            var txtOldPassword = $("#<%=txtOldPassword.ClientID %>").val();
            var txtNewPassword = $("#<%=txtNewPassword.ClientID %>").val();
            var txtNewPassword2 = $("#<%=txtNewPassword2.ClientID %>").val();
            if (txtOldPassword == "") {
                alert("请填写原始密码!");
                return false;
            }
            if (txtNewPassword == "") {
                alert("请填写新的密码!");
                return false;
            }
            if (txtNewPassword2 == "") {
                alert("请填写密码确认!");
                return false;
            }
            if (txtNewPassword != txtNewPassword2) {
                alert("新密码与确认密码不一致!");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="overflow: hidden;">
            <div id="myTable">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>原始密码</td>
                        <td>
                            <asp:TextBox ID="txtOldPassword" runat="server" CssClass="addInput"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>新的密码</td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="addInput"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>密码确认</td>
                        <td>
                            <asp:TextBox ID="txtNewPassword2" runat="server" CssClass="addInput"></asp:TextBox></td>
                    </tr>
                </table>
                <div class="but2">
                    <asp:Button ID="Sub" CssClass="Sub upFileBtn" runat="server" Text="确认" OnClientClick="return checkForm()" OnClick="Sub_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
