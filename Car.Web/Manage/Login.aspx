<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Car.Web.Manage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录页</title>
    <link href="res/css/login.css" rel="stylesheet" />
    <link rel="stylesheet" href="res/css/loginstyle.css" />
    <link href="res/css/loginstyle.css" rel="stylesheet" />
    <script src="res/js/jquery-1.11.1.min.js"></script>
    <script src="res/js/login.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="margin-top:80px;">
    <h1>后台管理</h1>
    <div id="loginBox">
        <div class="inputUserName"><asp:TextBox ID="txtName" runat="server"></asp:TextBox><div class="alertUserName">用户名</div></div>
        <div class="inputPassWord"><asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"></asp:TextBox><div class="alertPassWord">密&nbsp;&nbsp;&nbsp;&nbsp;码</div></div>
        <asp:Button ID="Sub" runat="server" Text="" OnClick="Sub_Click" CssClass="loginButton" />
    </div>
    </form>
</body>
</html>
