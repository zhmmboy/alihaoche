<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.Manage.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>阿里好车-管理界面</title>
    <link href="res/css/style.css" rel="stylesheet" />
    <script src="res/js/jquery-1.11.1.min.js"></script>
    <script src="res/js/menuData.js"></script>
    <script src="res/js/home.js"></script>
</head>
<body style="overflow-y: hidden">
    <div id="Backstage">
        <!-- 顶部 -->
        <div class="topBack">
            <div class="topBackLeft">
                <img src="res/images/logo.jpg" />
            </div>
            <div class="topBackCenter"></div>
            <a href="/Manage/Logout.aspx">
                <div class="topBackExit">退出</div>
            </a>
        </div>
        <div class="menu" style="width: 100%;">
            <div class="menuLeft">
                <div class="admin">
                    <div class="adminBox">
                        <div class="head">
                            <img src="res/images/head.jpg" width="60" height="60" />
                        </div>
                        <div class="adminRemind">
                            <span class="adminName">管理员</span>
                            <span>欢迎登陆！</span>
                        </div>
                    </div>
                </div>
                <div class="one_menu">
                    <ul>
                    </ul>
                </div>
            </div>

            <div class="menuRight">
                <div class="Catalog" style="font-size: 12px;">
                    <span class="routeImg" style="float: left; padding: 6px 0 0 12px;">
                        <img src="res/images/home.jpg" style="float: left;" />
                    </span>
                    <span class="Route" style="padding-left: 10px;">您当前的位置：首页</span>
                    <span class="time" style="float: right; padding-right: 30px;">2014年12月1日   16:18:10    星期一</span>

                </div>
                <div class="two_menu">
                    <ul>
                    </ul>
                </div>
                <div class="main_ifr">
                    <iframe width="100%" height="100%" style="border: 0;" src="http://fanyi.baidu.com/translate#zh/en/"></iframe>
                </div>

            </div>

        </div>
        <div style="height: 30px; background: #5e5e5e; text-align: center; line-height: 30px; color: #fff; font-size: 12px;">Copyright©  2014  www.alihaoche.com 版权所有</div>
    </div>

</body>
</html>
