<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIndex.aspx.cs" Inherits="Car.Web.Manage.CreateIndex" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>阿里好车 - 一个专业分享汽车资讯的网站！</title>
    <meta name="keywords" content="汽车网站、汽车资讯、汽车新闻、新车、汽车报价、二手车、二手车市场、汽车点评、汽车评测、汽车图片、汽车壁纸、MPV、SUV、豪车、跑车">
    <meta name="description" content="一个专业分享汽车资讯的网站，一个分享买车心得、用车经验的网站。">
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
                <h3 class="title"><small class="pull-right">共收录：<%=totalCount %> 辆汽车资料。&nbsp;&nbsp;<a href="http://www.alihaoche.com/speak">我要提交</a> </small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt">
                            <a target="_blank" class="thumbnail" href="http://www.alihaoche.com/news/<%#Eval("nId") %>">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlepic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlepic").ToString().Replace("../","") %>" style="display: inline;"></a><h2><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("nid") %>"><%#Eval("nTitle") %></a></h2>
                            <p class="note"><%#Eval("nTitle") %></p>
                            <footer><time>分类：[<%#Eval("cbName") %>]</time>/<time>&nbsp;&nbsp;<%#Convert.ToDateTime(Eval("nAddTime")).ToString("MM-dd HH:mm") %></time>/<a href="javascript:;" class="post-like" data-pid="<%#Eval("nid") %>" evt="like" evttype="person"><i class="glyphicon glyphicon-thumbs-up"></i>我喜欢 (<span><%#Eval("nGood") %></span>)</a><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></footer>
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
                    <li><a target="_blank" href="http://www.alihaoche.com/aboutus">关于我们</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/speak">意见建议</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/tougao">给我们投稿</a></li>
                </ul>
                <div class="speedbar-weixin">
                    <h5>微信关注“阿里好车”<br>
                        看汽车资讯上阿里好车</h5>
                    <img src="http://www.alihaoche.com/res/image/weixin-qrcode.jpg" alt="微信关注“阿里好车”,看汽车资讯上阿里好车！">
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
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlepic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlepic") %>" style="display: block;" title="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p> <%#Eval("nTitle") %><br /><time><%#Convert.ToDateTime(Eval("naddtime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/tag/<%#Server.UrlEncode(Eval("tName").ToString()) %>" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %> </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic") %>" style="display: block;" title="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nAddTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("nClicks") %>)</span></p>
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
