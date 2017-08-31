<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.Album.SheHuiMingRen.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>世界名人图片_中国名人图片_网络名人图片_名人图片相册_阿里好车</title>
    <meta name="keywords" content="世界名人图片、中国名人图片、网络名人图片、名人图片相册">
    <meta name="description" content="收集并分享世界名人图片、中国名人图片、网络名人图片、名人图片相册。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png">
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="home blog" data-navto="album">
    <!--Include Header-->
    <!--#include virtual="../../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <header class="title">
            <div class="share bdsharebuttonbox bdshare-button-style0-24" data-bd-bind="1419398409371">
                分享到：<a class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a class="bds_weixin bdsm" data-cmd="weixin" title="分享到微信"></a><a class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a class="bds_sqq bdsm" data-cmd="sqq" title="分享到QQ好友"></a><a class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a>
                <span class="bds_count" data-cmd="count" title="累计分享0次">0</span>
            </div>
        </header>
        <div class="likepage">
            <ul>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <li><a href="http://www.alihaoche.com/album/<%#Eval("cEnName") %>/<%#Eval("aId") %>.html">
                            <img data-src="http://www.alihaoche.com/<%#Eval("aPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("aPhoto").ToString().Replace("../","") %>" style="display: inline;height:300px" title="<%#Eval("aName") %>"><h2><%#Eval("aName") %></h2>
                        </a><a href="javascript:;" class="post-like" data-pid="<%#Eval("aid") %>" evt="like" evttype="album"><i class="glyphicon glyphicon-thumbs-up"></i>赞 (<span><%#Eval("aClicks") %></span>)</a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="pagination">
            <ul>
                <%=pageStr %>
            </ul>
        </div>
    </section>
    <!--Footer-->
    <!--#include virtual="../../Include/Footer.html"-->
    <!--Footer-->
</body>
</html>
