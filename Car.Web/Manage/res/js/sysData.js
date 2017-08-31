var arrayNation = new Array(
    '汉族', '蒙古族', '彝族', '侗族', '哈萨克族',
    '畲族', '纳西族', '仫佬族', '仡佬族', '怒族', '保安族',
    '鄂伦春族', '回族', '壮族', '瑶族', '傣族', '高山族',
    '景颇族', '羌族', '锡伯族', '乌孜别克族', '裕固族', '赫哲族',
    '藏族', '布依族', '白族', '黎族', '拉祜族', '柯尔克孜族', '布朗族',
    '阿昌族', '俄罗斯族', '京族', '门巴族', '维吾尔族', '朝鲜族',
    '土家族', '傈僳族', '水族', '土族', '撒拉族', '普米族', '鄂温克族',
    '塔塔尔族', '珞巴族', '苗族', '满族', '哈尼族', '佤族', '东乡族',
    '达斡尔族', '毛南族', '塔吉克族', '德昂族', '独龙族', '基诺族');

var arrayShengXiao = new Array(
    '鼠', '牛', '虎', '兔', '蛇',
    '蛇', '马', '羊', '猴', '鸡', '狗', '猪');

var arrayDegree = new Array(
    '小学', '初中', '高中', '中专',
    '大专', '本科', '硕士', '博士');

/** *创建民族选择框 */
function createNationSelect(name, str) {

    var select = document.getElementById("selNation");
    for (var i = 0; i < arrayNation.length; i = i + 1) {
        select.name = name;
        var opt = document.createElement("option");
        opt.value = arrayNation[i];
        opt.innerText = arrayNation[i];
        if (arrayNation == str) {
            opt.selected = 'true';
        }
        select.appendChild(opt);
    }
}
/** *创建生肖选择框 */
function createShengXiaoSelect(name, str) {
    document.write("<select id='selectShengXiao'></select>");
    var select = document.getElementById("selectShengXiao");
    for (var i = 0; i < arrayShengXiao.length; i = i + 1) {
        select.name = name;
        var opt = document.createElement("option");
        opt.value = arrayShengXiao[i];
        opt.innerText = arrayShengXiao[i];
        if (arrayShengXiao == str) {
            opt.selected = 'true';
        }
        select.appendChild(opt);
    }
}
/** *创建学历选择框 */
function createDegreeSelect(name, str) {
    document.write("<select id='selectDegree'></select>");
    var select = document.getElementById("selectDegree");
    for (var i = 0; i < arrayDegree.length; i = i + 1) {
        select.name = name;
        var opt = document.createElement("option");
        opt.value = arrayDegree[i];
        opt.innerText = arrayDegree[i];
        if (arrayDegree == str) {
            opt.selected = 'true';
        }
        select.appendChild(opt);
    }
}