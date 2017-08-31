<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.Blog.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>明星博客_明星微博_企业家博客_企业家微博_名人博客_名人微博_阿里好车</title>
    <meta name="keywords" content="博客,微博,明星博客,企业家博客,社会名人博客,网络红人博客,草根达人博客">
    <meta name="description" content="收集并分享明星微博博客,企业家微博博客,社会名人微博博客,网络红人微博博客,草根达人微博博客资料。">
    <link rel="stylesheet" id="_common-css" href="http://juyoo.w222.mc-test.com/res/css/common.css" type="text/css" media="all">
    <link rel="shortcut icon" href="http://juyoo.w222.mc-test.com/favicon.ico">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="http://juyoo.w222.mc-test.com/res/image/icon-144x144.png">
    <!--[if lt IE 9]><script src="http://juyoo.w222.mc-test.com/res/js/html5.js"></script><![endif]-->
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
                            <a target="_blank" class="thumbnail" href="http://juyoo.w222.mc-test.com/blog/<%#Eval("cEnName") %>/<%#Eval("pId") %>.html">
                                <img data-src="http://juyoo.w222.mc-test.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://juyoo.w222.mc-test.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" style="display: inline;"></a><h2><a target="_blank" href="http://juyoo.w222.mc-test.com/blog/<%#Eval("cEnName") %>/<%#Eval("pid") %>.html"><%#Eval("pCnName") %></a></h2>
                            <p class="note"><%#Eval("pTips") %></p>
                            <footer><time>分类：<a href="http://juyoo.w222.mc-test.com/<%#Eval("cEnName") %>">[<%#Eval("cName") %>]</a></time> <time class="new"><%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd HH:mm") %></time>/<a href="javascript:;" class="post-like" data-pid="14408" evt="like"><i class="glyphicon glyphicon-thumbs-up"></i>点赞 (<span>0</span>)</a><span class="post-views">阅读(9)</span></footer>
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
                    <li><a target="_blank" href="http://juyoo.w222.mc-test.com/week.html">7天热门排行</a></li>
                    <li><a target="_blank" href="http://juyoo.w222.mc-test.com/month.html">30天热门排行</a></li>
                    <li><a target="_blank" href="http://juyoo.w222.mc-test.com/zan.html">点赞热门</a></li>
                </ul>
                <div class="speedbar-weixin">
                    <h5>微信关注“阿里好车”<br>
                        找名人就上阿里好车！</h5>
                    <img src="http://juyoo.w222.mc-test.com/static/img/weixin-qrcode.jpg" alt="微信关注“阿里好车”,找名人就上阿里好车！">
                </div>
            </div>
        </aside>
        <aside class="sidebar">
            <div class="widget widget_ui_viewposts affix-top">
                <h3 class="title"><strong>7天热门</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptHot" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://juyoo.w222.mc-test.com/blog/<%#Eval("cEnName") %>/<%#Eval("pId") %>.html">
                                <img data-src="http://juyoo.w222.mc-test.com/<%#Eval("pPhoto") %>" class="thumb" src="http://juyoo.w222.mc-test.com/<%#Eval("pPhoto") %>" style="display: block;"><h2><%#Eval("pCnName") %></h2>
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
                            <a href="http://juyoo.w222.mc-test.com/Tag_<%#Server.UrlEncode(Eval("tName").ToString()) %>.html"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %> </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://juyoo.w222.mc-test.com/Info_<%#Eval("nId") %>.html">
                                <img data-src="http://juyoo.w222.mc-test.com/<%#Eval("nTitlePic") %>" class="thumb" src="http://juyoo.w222.mc-test.com/<%#Eval("nTitlePic") %>" style="display: block;"><h2><%#Eval("nTitle") %></h2>
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
