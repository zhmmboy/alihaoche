<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.News.QiYeJia.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>企业家新闻_企业家刊物_企业家杂志_企业家资讯_阿里好车</title>
    <meta name="keywords" content="企业家新闻、企业家刊物、企业家杂志、企业家资讯">
    <meta name="description" content="收集并分享全球知名企业家新闻、企业家刊物、企业家杂志、企业家资讯。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png" />
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="home blog" data-navto="news">
    <!--Include Header-->
    <!--#include virtual="../../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content excerpts">
                <h3 class="title"><small class="pull-right">共收录：<%=totalCount %> 篇 企业家热点·资讯。</small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt">
                            <a target="_blank" class="thumbnail" href="http://www.alihaoche.com/news/<%#Eval("cEnName") %>/<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" style="display: inline;" alt="<%#Eval("nTitle") %>"></a><h2><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("cEnName") %>/<%#Eval("nId") %>.html"><%#Eval("nTitle") %></a></h2>
                            <p class="note"><%#Eval("nTips") %></p>
                            <footer><time>分类：<a href="http://www.alihaoche.com/news/<%#Eval("cEnName") %>">[<%#Eval("cName") %>]</a></time>/&nbsp;&nbsp;<time><%#Convert.ToDateTime(Eval("nTime")).ToString("MM-dd HH:mm") %></time>/<a href="javascript:;" class="post-like" data-pid="<%#Eval("nid") %>" evt="like" evttype="news"><i class="glyphicon glyphicon-thumbs-up"></i>点赞 (<span><%#Eval("nGood") %></span>)</a><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></footer>
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
                    <li><a target="_blank" href="http://www.alihaoche.com/news/mingxing">明星·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/qiyejia">企业家·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/shehuimingren">社会名人·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/wangluohongren">网络红人·资讯</a></li>
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
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("cEnName") %>/<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic") %>" style="display: block;" alt="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/news/tag/<%#Server.UrlEncode(Eval("tName").ToString()) %>_1.html" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %> </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/person/<%#Eval("cEnName") %>/<%#Eval("pId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" style="display: block;" alt="<%#Eval("pCnName") %>:<%#Eval("pJob") %>"><h2><%#Eval("pCnName") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("pClicks") %>)</span></p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </aside>
    </section>
    <!--Footer-->
    <!--#include virtual="../../Include/Footer.html"-->
    <!--Footer-->
</body>
</html>
