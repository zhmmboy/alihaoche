function changeE() {
    //改变英文
    $("input[type='text']").unbind("change");
    $("input[type='text']").bind("change", function () {
        var val = $(this).val().replace(/;/g, "；").replace(/,/g, "，").replace(/\"/g, "”").replace(/\'/g, "’").replace(/:/g, "：");
        $(this).val(val);
    });
}