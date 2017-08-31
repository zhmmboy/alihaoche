<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.Works.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>明星电影_明星电视剧_企业家成就_社会名人代表作品_网络红人代表作品_阿里好车</title>
    <meta name="keywords" content="明星,企业家,社会名人,网络红人,草根达人">
    <meta name="description" content="收集并分享明星,企业家,社会名人,网络红人,草根达人资料。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png" />
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="home blog" data-navto="home">
    <!--Include Header-->
    <!--#include virtual="../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content excerpts">
                <h3 class="title"><small class="pull-right">共收录：7 位公务员信息 &nbsp; &nbsp; 最近30天更新：53位</small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt">
                            <a target="_blank" class="thumbnail" href="http://www.alihaoche.com/<%#Eval("cEnName") %>/<%#Eval("wId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" style="display: inline;" alt="<%#Eval("cEnName") %>"></a><h2><a target="_blank" href="http://www.alihaoche.com/<%#Eval("cEnName") %>/<%#Eval("pid") %>.html"><%#Eval("pCnName") %>：爸爸去哪里了？第二季</a></h2>
                            <p class="note"><%#Eval("pTips") %>爸爸去哪里了?讲诉了爸爸出海打渔，遇到暴风雨未归的故事。。。感人至深爸爸去哪里了?讲诉了爸爸爸去哪里了?讲诉了爸爸出海打渔，遇到暴风雨未归的故事。。。感人至深爸爸去哪里了?讲诉了爸爸出海打渔，遇到暴风雨未归的故事。。。感人至深爸出海打渔，遇到暴风雨未归的故事。。。感人至深</p>
                            <footer><time>分类：<a href="http://www.alihaoche.com/works/<%#Eval("cEnName") %>">[<%#Eval("cName") %>]</a></time> <time class="new"><%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd HH:mm") %></time>/<a href="javascript:;" class="post-like" data-pid="14408" evt="like"><i class="glyphicon glyphicon-thumbs-up"></i>点赞 (<span>0</span>)</a><span class="post-views">阅读(9)</span></footer>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="pagination">
                    <ul>
                        <%=pageStr %>
                    </ul>
                </div>
            </div>
        </div>
        <aside class="speedbar-wrap">
            <div class="speedbar">
                <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/works/mingxing">明星·作品</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/works/qiyejia">企业家·作品</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/works/shehuimingren">社会名人·作品</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/works/wangluohongren">网络红人·作品</a></li>
                </ul>
                <div class="speedbar-weixin">
                    <h5>微信关注“阿里好车”<br>
                        找名人资料就上阿里好车</h5>
                    <img src="http://www.alihaoche.com/res/image/weixin-qrcode.jpg" alt="微信关注“阿里好车”,找名人资料就上阿里好车！">
                </div>
            </div>
        </aside>
        <aside class="sidebar">
            <div class="widget widget_ui_viewposts affix-top">
                <h3 class="title"><strong>7天热门</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptHot" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/Info_<%#Eval("pId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto") %>"><h2><%#Eval("pCnName") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd") %></time><span class="post-views">阅读(1.29K)</span></p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="widget widget_ui_tags">
                <h3 class="title"><strong>热门话题</strong></h3>
                <div class="items">
                    <asp:Repeater ID="rptTag" runat="server">
                        <ItemTemplate>
                            <a href="http://www.alihaoche.com/works/tag/<%#Server.UrlEncode(Eval("tName").ToString()) %>_1.html" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %> </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("cEnName") %>/<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" title="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </aside>
    </section>
    <!--Footer-->
    <!--#include virtual="../Include/Footer.html"-->
    <!--Footer-->
</body>
</html>
