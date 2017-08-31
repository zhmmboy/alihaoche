<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumInfoAdd.aspx.cs" Inherits="Car.Web.Manage.Album.AlbumInfoAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增相片</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="../res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
    <script>
        var removeIndex = 0;
        function removeMain(index) {
            $(".str" + index).remove();
        }

        $(function () {
            addFile();
        });

        function loadFile()
        {
            
        }

        function addFile() {
            var hidText = $("#hidtext").val();
            var hidId = $("#hidId").val();
            var hidUrl = $("#hidUrl").val();
            var albumName = $("#spAlbumName").text();

            var str = "";
            if ($.trim(hidId) != "" && removeIndex==0) {

                for (var i = 0; i < hidId.split('|').length - 1; i++) {
                    str += "<div class=str" + removeIndex + "><input type='text' id='hidGuId' value='" + hidId.split('|')[i] + "' /><input type='text' id='hidDoAction' value='edit' /><div>" + upload("jpg" + removeIndex) + "<a class=\"delete\" href='javascript:removeMain(" + removeIndex + ")'>删除</a></div><div><textarea id='txtcontent' class=\"literacyAddText\">" + hidText.split('|')[i] + "</textarea></div></div>";
                    removeIndex += 1;
                }
            } else {
                removeIndex += 1;
                str = "<div class=str" + removeIndex + "><input type='text' id='hidGuId' /><input type='text' id='hidDoAction' value='add' /><div>" + upload("jpg" + removeIndex) + "<a class=\"delete\" href='javascript:removeMain(" + removeIndex + ")'>删除</a></div><div><textarea id='txtcontent' class=\"literacyAddText\">" + albumName + "</textarea></div></div>";
            }

            document.getElementById('MyFile').insertAdjacentHTML("beforeEnd", str);

            changeE();
        }
        function addHid() {
            /*验证*/
            for (var j = 0; j < $("#MyFile > div").length; j++) {
                if ($("#MyFile > div").find(".upfile").val() == "" && $("#MyFile > div").find("#hidUrl").val() == "") {
                    alert("请上传第 " + (j + 1) + " 张图片!");
                    return false;
                }
                if ($("#MyFile > div").find("textarea").val() == "" && $("#MyFile > div").find("#hidtext").val() == "") {
                    alert("请填写第 " + (j + 1) + " 段内容!");
                    return false;
                }

                //替换英文
                $("#MyFile textarea").eq(j).val($("#MyFile textarea").eq(j).val().replace(/;/g, "；").replace(/,/g, "，").replace(/\"/g, "”").replace(/\'/g, "’").replace(/:/g, "："));
            }

            var idStr = "";
            var textStr = "";
            var actionStr = "";

            $("input[id='hidGuId']").each(function () {

                idStr += $(this).val() + "|";
            });
            $("textarea[id='txtcontent']").each(function () {
                textStr += $(this).val() + "|";
            });
            $("input[id='hidDoAction']").each(function () {
                actionStr += $(this).val() + "|";
            });

            $("#hidId").val(idStr);
            $("#hidtext").val(textStr);
            $("#hidAction").val(actionStr);
            return true;
        }

        function changeE() {
            //改变英文
            $("input[type='text']").unbind("change");
            $("input[type='text']").bind("change", function () {
                var val = $(this).val().replace(/;/g, "；").replace(/,/g, "，").replace(/\"/g, "”").replace(/\'/g, "’").replace(/:/g, "：");
                $(this).val(val);
            });
        }

        //上传样式
        function upload(id) {
            return "<input id=" + id + " type=\"file\" name=\"File\" class=\"upfile\" accept=\".jpg,.png\" onchange=\"document.getElementById('" + id + "txt').innerHTML=this.value\" />" + "<input class=\"upFileBtn\" type=\"button\" value=\"上传图片\" onclick=\"document.getElementById('" + id + "').click()\" />" + "&nbsp;<span id=" + id + "txt>未选中图片</span>";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div id="myTable">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="txt">名人头像：
                    </td>
                    <td>
                        <img src="/res/image/avatar-default.png" id="imgPersonUrl" runat="server" width="150"/>
                    </td>
                </tr>
                <tr>
                    <td class="txt">所属名人：
                    </td>
                    <td>
                        <span id="spPersonName" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td class="txt">相册封面：
                    </td>
                    <td>
                        <img src="/res/image/avatar-default.png" id="imgAlbumUrl" runat="server" width="150" />
                    </td>
                </tr>
                <tr class="hui">
                    <td class="txt">相册名称：
                    </td>
                    <td>
                        <span id="spAlbumName" runat="server"></span>
                    </td>
                </tr>
            </table>
        </div>

        <div id="myContent">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>相片描述:</td>
                    <td>
                        <div id="MyFile">
                        </div>
                        <input type="button" value="+添加" onclick="addFile()" class="upFileBtn" />
                    </td>
                </tr>
            </table>
            <div class="but">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn_big upFileBtn" Text=" 保 存 " OnClientClick="return addHid();" />
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn_big upFileBtn" Text=" 返 回 " />
                <input type="hidden" name="hidtext" id="hidtext" runat="server" />
                <input type="hidden" name="hidId" id="hidId" runat="server" />
                <input type="hidden" name="hidUrl" id="hidUrl" runat="server" />
                <input type="hidden" name="hidAction" id="hidAction" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
