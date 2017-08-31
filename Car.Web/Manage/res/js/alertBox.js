(function () {
    var alertBox = function (html, opData, callback) {
        var that = this;
        that._width = $(window).width(); //系统宽度
        that._height = $(window).height();
        that.width = opData.width; //传的宽度
        that.height = opData.height;
        that.id = opData.id;
        that.title = opData.title;

        that.init(html, opData);

        $(window).resize(function () {
            window.location.reload();
        });
        callback();
    };

    alertBox.prototype = {
        show: function (obj, isMP) {
            var that = this;
            $("#" + that.id).show();
            if (isMP == "0") {
                for (var objs in obj) {
                    $("#" + that.id).find(".alertHtml table tr:eq(" + objs + ") td").eq(1).text(obj[objs]);
                }
                //alert("更多");

            }
            else {
                $("#" + that.id).find(".alertPassWord").val(obj[0]);
                $("#" + that.id).find(".hidId").val(obj[1]);
                $("#" + that.id).find(".hidRole").val(obj[2]);

                //for (var objs in obj) {
                //    alert(obj[0]);
                //}
                //alert("修改密码");
            }

        },

        //关闭
        exit: function () {
            var that = this;
            $("#" + that.id).hide();
        },
        init: function (html, opData) {
            var that = this;
            $("body").append(that.publicBox(html, opData));
            $("#" + that.id + " .alertExit").bind("click", function () {
                that.exit();
            });
        },
        publicBox: function (html, opData) {
            var that = this;
            var left = (that._width - that.width) / 2; //计算居左上

            var bodyHeight = document.body.scrollHeight;

            var ht = "";
            ht += "<div id=\"" + that.id + "\" style=\"position: absolute; top: 0; left: 0; width: 100%; height: 100%; display:none;\">";
            ht += "     <div class=\"alertMain\" style=\"width: " + that.width + "px; height: " + that.height + "px; border-radius: 5px; overflow: hidden; background: #eee; position: absolute; left: " + left + "px; top: 30%; z-index: 1000;\">";
            ht += "         <div class=\"alertTop\" style=\"width: 100%; height: 40px; background: #32323a;\">";
            ht += "             <div class=\"alertTitle\" style=\"width:100%; text-align:center; position:absolute; color:#fff; font-size:14px; font-weight:bold; line-height:40px; \">" + that.title + "</div>";

            ht += "             <div class=\"alertExit\" style=\" cursor:pointer; position:absolute; right:0; top:5px; \"><img src=\"../res/images/alertExit.png\" width=\"30\" height=\"30\" />&nbsp;</div>";
            ht += "         </div>";
            ht += "         <div class=\"alertHtml\">";
            ht += html;//要改变的HTML
            ht += "         </div>";
            ht += "     </div>";
            ht += "     <div class=\"bg\" style=\"background: #000; position: absolute; top: 0; left: 0; width: 100%; height: " + bodyHeight + "px; filter: alpha(opacity=30); opacity: 0.3; z-index: 1;\"></div>";
            ht += "</div>";
            return ht;
        }
    }
    window.alertBox = alertBox;
})();