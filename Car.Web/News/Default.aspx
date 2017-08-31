<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.News.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>汽车新闻_买车_用车_阿里好车</title>
    <meta name="keywords" content="汽车新闻、买车注意事项、用车经验、阿里好车">
    <meta name="description" content="阿里好车每天发布最新汽车行业新闻，分享买车注意事项、用车经验。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png" />
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="home blog" data-navto="news">
    <!--Include Header-->
    <!--#include virtual="../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content excerpts">
                <h3 class="title"><small class="pull-right">共收录：<%=totalCount %> 篇 热点·资讯。</small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt">
                            <a target="_blank" class="thumbnail" href="http://www.alihaoche.com/news/<%#Eval("nid") %>">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" alt="<%#Eval("nTitle") %>" style="display: inline;"></a><h2><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("nid") %>"><%#Eval("nTitle") %></a></h2>
                            <p class="note"><%#Eval("nTips") %></p>
                            <footer>分类:<span class="post-views">[<%#Eval("cbName") %>]</span>/<span class="post-views"><%#Convert.ToDateTime(Eval("nAddTime")).ToString("MM-dd HH:mm") %></span>/<a href="javascript:;" class="post-like" data-pid="<%#Eval("nid") %>" evt="like" evttype="news"><i class="glyphicon glyphicon-thumbs-up"></i>点赞 (<span><%#Eval("nGood") %></span>)</a><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></footer>
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
               <%-- <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/news/mingxing">明星·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/qiyejia">企业家·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/shehuimingren">社会名人·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/wangluohongren">网络红人·资讯</a></li>
                </ul>--%>
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
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("nId") %>">
                                <img data-src="http://www.alihaoche.com/<%#Eval("ntitlePic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("ntitlePic") %>" alt="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nAddTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("nclicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/tag/<%#Eval("tName") %>" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("nId") %>">
                                <img data-src="http://www.alihaoche.com/<%#Eval("ntitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("ntitlePic").ToString().Replace("../","") %>" alt="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nAddTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("nclicks") %>)</span></p>
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
