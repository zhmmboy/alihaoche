<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Car.Web.Question.List" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>阿里好车--分享奇闻趣事</title>
    <link rel="stylesheet" id="_common-css" href="../res/css/common.css" type="text/css" media="all">
    <meta name="keywords" content="奇趣事,奇闻趣事,有趣的事,趣味美食,阿里好车,有趣的网站">
    <meta name="description" content="阿里好车是一个分享奇闻趣事的媒体，每天更新最新奇闻趣事、奇趣科技、自然奇迹和趣味美食的文章，是一个值得收藏的网站。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
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
                <h3 class="title"><small class="pull-right">24小时发布奇闻趣事：7篇 &nbsp; &nbsp; 7天更新：53篇</small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt">
                            <a target="_blank" class="thumbnail" href="http://###/14408.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" style="display: inline;"></a><h2><a target="_blank" href="http://www.alihaoche.com/<%#Eval("nid") %>.html"><%#Eval("nTitle") %></a></h2>
                            <p class="note"><%#Eval("nTip") %></p>
                            <footer><time class="new">27分钟前</time>/<a href="javascript:;" class="post-like" data-pid="14408" evt="like"><i class="glyphicon glyphicon-thumbs-up"></i>点赞 (<span>0</span>)</a><span class="post-views">阅读(9)</span></footer>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
                <article class="excerpt">
                    <a target="_blank" class="thumbnail" href="http://###/14412.html">
                        <img data-src="http://###/wp-content/uploads/2014/12/13601539d3d15df-240x180.jpg" class="thumb" src="./阿里好车--分享奇闻趣事_files/13601539d3d15df-240x180.jpg" style="display: inline;"></a><h2><a target="_blank" href="http://###/14412.html">挪威的大西洋海滨公路—世界最险、最美的公路</a></h2>
                    <p class="note">开车时若是一旁有美丽自然景观，是件相当惬意的事，但若是路途超惊险，相信会吓坏不少驾驶员！挪威默勒鲁姆斯达尔郡境内的大西洋海滨公路就结合这两个极端的现象，让不少驾驶员时而身处在惊险中，其他时间又在海洋围...</p>
                    <footer><time class="new">中午 12:00</time>/<a href="javascript:;" class="post-like" data-pid="14412" evt="like"><i class="glyphicon glyphicon-thumbs-up"></i>点赞 (<span>0</span>)</a><span class="post-views">阅读(19)</span></footer>
                </article>
                <div class="pagination" style="display: none;">
                    <ul>
                        <li class="prev-page"></li>
                        <li class="next-page"><a href="http://###/page/2">下一页</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <aside class="speedbar-wrap">
            <div class="speedbar">
                <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/week">7天热门排行</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/month">30天热门排行</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/zan">点赞热门</a></li>
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
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/Info_<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("ntitlePic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("ntitlePic") %>" style="display: block;"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("nclicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/tags/<%#Server.UrlEncode(Eval("tName").ToString()) %>.html" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><span class="hot">H</span></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/Info_<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("ntitlePic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("ntitlePic") %>" style="display: block;"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nDate")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("nclicks") %>)</span></p>
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
