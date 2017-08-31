<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Car.Web.Question.Info" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title><%=TitleStr %>_阿里好车</title>
    <meta name="keywords" content="<%=KeyStr %>">
    <meta name="description" content="<%=DescStr %>">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png" />
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="single single-post postid-14297 single-format-standard" data-navto="question">
    <!--Include Header-->
    <!--#include virtual="../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content">
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <header class="article-header">
                            <h1 class="article-title"><a href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html"><%#Eval("qTitle") %></a></h1>
                            <div class="article-meta">
                                <time><%#Convert.ToDateTime(Eval("qAddTime")).ToString("yyyy-MM-dd HH:mm") %></time><span class="item">小编：<%#Eval("qAsker") %></span>
                                <span class="item post-views">阅读(<%#Eval("qClicks") %>)</span>
                                <span class="item"></span>
                            </div>
                        </header>
                        <article class="article-content">
                            <%#Eval("qIntro") %>
                            <p class="article-tags"><strong>延伸阅读：</strong><%=TagsStr %></p>
                            <p class="post-copyright">此文由阿里好车编辑，未经允许不得转载：<a href="http://www.alihaoche.com/">阿里好车</a> » <a href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html"><%#Eval("qTitle") %></a></p>
                        </article>
                        <div class="article-social">
                            <a href="javascript:;" class="action action-like" data-pid="<%#Eval("qid") %>" evt="like" evttype="question"><i class="glyphicon glyphicon-thumbs-up"></i>我觉得很赞 (<span><%#TotalZan %></span>)</a>
                            <div class="action-share bdsharebuttonbox bdshare-button-style0-24" data-bd-bind="1419398361060">
                                <strong>分享到：</strong>
                                <a class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a class="bds_weixin bdsm" data-cmd="weixin" title="分享到微信"></a><a class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a class="bds_sqq bdsm" data-cmd="sqq" title="分享到QQ好友"></a><a class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a>
                                <span class="bds_count" data-cmd="count" title="累计分享0次">0</span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <nav class="article-nav">
                    <%=PrevNextNewsStr %>
                </nav>
                <h3 class="title" id="comments">
                    <strong>网友·互动 （共<b><%=Answers %></b>条记录)</strong>
                </h3>
                <div id="postcomments">
                    <asp:Repeater ID="rptAnswers" runat="server">
                        <ItemTemplate>
                            <ol class="commentlist">
                                <li class="comment even thread-even depth-1" id="comment-11193"><span class="comt-f">#<%#Container.ItemIndex+1%></span><div class="comt-avatar">
                                    <img alt="" data-src="http://www.alihaoche.com/res/image/avatar-default.png" class="avatar avatar-50 photo" height="50" width="50" src="http://" style="display: block;">
                                </div>
                                    <div class="comt-main" id="div-comment-<%#Eval("aId") %>">
                                        <%#Eval("aContent") %><div class="comt-meta"><span class="comt-author"><%#Eval("aNickName") %></span><time><%#Convert.ToDateTime(Eval("aAddTime")).ToString("yyyy-MM-dd HH:mm:ss") %></time><a class="comment-reply-link" href="javascript:;" onclick="return addComment.moveForm(&quot;div-comment-11193&quot;, &quot;11193&quot;, &quot;respond&quot;, &quot;14297&quot;)">回复</a></div>
                                    </div>
                                </li>
                                <!-- #comment-## -->
                            </ol>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="pagenav">
                    </div>
                </div>
                <div id="respond" class="no_webshot">
                    <form action="http://www.alihaoche.com/res/action/comment.ashx" method="post" id="commentform">
                        <div class="comt">
                            <div class="comt-title">
                                <img alt="" data-src="http://www.alihaoche.com/res/image/avatar-default.png" class="avatar avatar-50 photo avatar-default" height="50" width="50" src="http://www.alihaoche.com/res/image/avatar-default.png">
                                <p><a id="cancel-comment-reply-link" href="javascript:;">取消</a></p>
                            </div>
                            <div class="comt-box">
                                <textarea placeholder="注意：与本文无关的评论将被清除，你的评论可以很给力！" class="input-block-level comt-area" name="comment" id="comment" cols="100%" rows="3" tabindex="1" onkeydown="if(event.ctrlKey&amp;&amp;event.keyCode==13){document.getElementById(&#39;submit&#39;).click();return false};"></textarea>
                                <div class="comt-ctrl">
                                    <div class="comt-tips">
                                        <input type="hidden" name="comment_post_ID" value="14297" id="comment_post_ID">
                                        <input type="hidden" name="comment_parent" id="comment_parent" value="0">
                                        <p style="display: none;">
                                            <input type="hidden" id="akismet_comment_nonce" name="akismet_comment_nonce" value="50c3df19be">
                                        </p>
                                        <label for="comment_mail_notify" class="checkbox inline hide" style="padding-top: 0">
                                            <input type="checkbox" name="comment_mail_notify" id="comment_mail_notify" value="comment_mail_notify" checked="checked">有人回复时邮件通知我</label><p style="display: none;"></p>
                                        <div class="comt-tip comt-loading" style="display: none;">评论提交中...</div>
                                        <div class="comt-tip comt-error" style="display: none;">#</div>
                                    </div>
                                    <button type="submit" name="submit" id="submit" tabindex="5">评论</button>
                                    <!-- <span data-type="comment-insert-smilie" class="muted comt-smilie"><i class="icon-thumbs-up icon12"></i> 表情</span> -->
                                </div>
                            </div>

                            <div class="comt-comterinfo" id="comment-author-info">
                                <ul>
                                    <li class="form-inline">
                                        <label class="hide" for="author">昵称</label><input class="ipt" type="text" name="author" id="author" value="" tabindex="2" placeholder="昵称"><span class="text-muted">昵称 (必填)</span></li>
                                    <li class="form-inline">
                                        <label class="hide" for="email">邮箱</label><input class="ipt" type="text" name="email" id="email" value="" tabindex="3" placeholder="邮箱"><span class="text-muted">邮箱 (必填)</span></li>
                                    <li class="form-inline">
                                        <label class="hide" for="url">网址</label><input class="ipt" type="text" name="url" id="url" value="" tabindex="4" placeholder="网址"><span class="text-muted">网址</span></li>
                                </ul>
                            </div>
                        </div>

                        <input type="hidden" id="ak_js" name="ak_js" value="1419398360876">
                    </form>
                </div>
                <div class="relates">
                    <h3 class="title"><strong>相关推荐</strong></h3>
                    <ul>
                        <asp:Repeater ID="rptAround" runat="server">
                            <ItemTemplate>
                                <li><a href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html">
                                    <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/question/<%#Eval("pPhoto").ToString().Replace("../","") %>" alt="<%#Eval("qTitle") %>"><%#Eval("qTitle") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <aside class="speedbar-wrap">
            <div class="speedbar">
              <%--  <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/question/week.html">7天热门排行</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/question/month.html">30天热门排行</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/question/zan.html">点赞热门</a></li>
                </ul>--%>
                <div class="speedbar-weixin">
                    <h5>微信关注“阿里好车”<br>
                        找名人资料就上阿里好车</h5>
                    <img src="http://www.alihaoche.com/res/image/weixin-qrcode.jpg" alt="微信关注“阿里好车”,找名人资料就上阿里好车！">
                </div>
            </div>
        </aside>

        <aside class="sidebar">
            <div class="widget article-social">
                <a href="javascript:;" class="action action-like"  data-pid="<%=this.Request.QueryString["id"] %>" evt="like" evttype="question"><i class="glyphicon glyphicon-thumbs-up"></i>可以试试 (<span><%=TotalZan %></span>)</a>
                <div class="action-share bdsharebuttonbox bdshare-button-style0-24" data-bd-bind="1419398361060">
                    <strong>分享到：</strong>
                    <a class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a class="bds_weixin bdsm" data-cmd="weixin" title="分享到微信"></a><a class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a class="bds_sqq bdsm" data-cmd="sqq" title="分享到QQ好友"></a><a class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a>
                    <span class="bds_count" data-cmd="count" title="累计分享0次">0</span>
                </div>
            </div>
            <div class="widget widget_ui_viewposts affix-top">
                <h3 class="title"><strong>7天热门</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptHot" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" style="display: block;" alt="<%#Eval("qTitle") %>"><h2><%#Eval("qTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("qAddTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("qclicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/tag/<%#Server.UrlEncode(Eval("tName").ToString()) %>" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %></a>
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
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic") %>" style="display: block;" alt="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("nclicks") %>)</span></p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </aside>

        <%=NextNewsStr %>
    </section>

    <!--Footer-->
    <!--#include virtual="../Include/Footer.html"-->
    <!--Footer-->
</body>
</html>
