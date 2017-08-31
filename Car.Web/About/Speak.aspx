<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Speak.aspx.cs" Inherits="Car.Web.About.Speak" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>在线留言_阿里好车</title>
    <meta name="keywords" content="在线留言,阿里好车">
    <meta name="description" content="投稿前必读：优先选择原创首发文章，包括译文，如是转载文章，请注明文章出处和来源链接。只接受汽车资讯，新闻、照片等与本站内容相关的投稿。我们会认真审阅每一篇投稿，但无法保证每篇投稿都会被发布，具体将根据文章质量来决定。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel='stylesheet' id='_common-css' href='http://www.alihaoche.com/res/css/common.css?ver=11.1' type='text/css' media='all' />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png">
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="page page-id-924 page-template-default" data-navto="speak">
    <!--#include virtual="../Include/Header.html"-->
    <div class="container container-page">
        <div class="pageside">
            <ul class="pagemenu">
                <li class="navto-about"><a href="http://www.alihaoche.com/aboutus">关于我们</a></li>
                <li class="navto-speak"><a href="http://www.alihaoche.com/speak">留言板</a></li>
                <li class="navto-tougao"><a href="http://www.alihaoche.com/tougao">投稿</a></li>
                <li class="navto-ad"><a href="http://www.alihaoche.com/ad">广告投放</a></li>
                <li class="navto-team"><a href="http://www.alihaoche.com/team">团队动态</a></li>
                <li class="navto-map"><a href="http://www.alihaoche.com/map">网站地图</a></li>
            </ul>
        </div>
        <div class="content">
            <header class="article-header">
                <h1 class="article-title"><a href="http://www.alihaoche.com/speak">给 阿里好车 留言板</a></h1>
            </header>
            <article class="article-content">
                <p style="color: #444444;">这里是<a href="http://www.alihaoche.com" title="阿里好车 - 一个专业分享汽车资讯的网站，一个分享买车心得、用车经验的网站！" target="_blank">阿里好车</a>网友留言胜地，想说啥，就说啥，只要是关于网站的，提升用户体验的，赶紧提提对网站的意见吧！</p>
                <p style="color: #444444;">你还可以和阿里好车进行<a style="color: #428bca;" href="http://www.alihaoche.com/ad" target="_blank">广告合作</a>，或者<a style="color: #428bca;" href="http://www.alihaoche.com/tougao" target="_blank">投稿</a>有趣的事儿，<strong><span style="color: #ff0000;">本站已停止友链交换</span></strong>。</p>
                <p style="color: #444444;">阿里好车邮箱：alihaoche@163.com</p>
            </article>
            <p>&nbsp;</p>
            <h3 class="title" id="comments">
                <strong>评论 <b>0</b></strong>
            </h3>
            <div id="respond" class="no_webshot">
                <form action="http://www.alihaoche.com/res/actioin/comment.ashx" method="post" id="commentform">
                    <div class="comt">
                        <div class="comt-box">
                            <textarea placeholder="注意：与本文无关的评论将被清除，你的评论可以很给力！" class="input-block-level comt-area" name="comment" id="comment" cols="100%" rows="3" tabindex="1" onkeydown="if(event.ctrlKey&amp;&amp;event.keyCode==13){document.getElementById('submit').click();return false};"></textarea>
                            <div class="comt-ctrl">
                                <div class="comt-tips">
                                    <input type='hidden' name='comment_post_ID' value='2741' id='comment_post_ID' />
                                    <input type='hidden' name='comment_parent' id='comment_parent' value='0' />
                                    <input type='hidden' name='comment_type' id='comment_type' value='speak' />
                                    <p style="display: none;">
                                        <input type="hidden" id="akismet_comment_nonce" name="akismet_comment_nonce" value="eb0f40b996" />
                                    </p>
                                    <label for="comment_mail_notify" class="checkbox inline hide" style="padding-top: 0">
                                        <input type="checkbox" name="comment_mail_notify" id="comment_mail_notify" value="comment_mail_notify" checked="checked" />有人回复时邮件通知我</label><p style="display: none;">
                                            <input type="hidden" id="ak_js" name="ak_js" value="87" />
                                        </p>
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

                </form>
            </div>

        </div>
    </div>
    <!--#include virtual="../Include/Footer.html"-->
</body>
</html>
