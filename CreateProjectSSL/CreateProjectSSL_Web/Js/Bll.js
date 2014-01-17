/*==============================================================================
*
* Filename: Bll.js
* Description: 页面相关操作,包含页面加载，对Table表格移动鼠标行变色操作， pageLoad()
*通用列表页面批量删除判断是否有选中项 ，复制操作只能选择一个选项的，以及对datatable的处理，
*进行锁定行和列的指定方法，例如锁定FixRowNumber 行 、 FixColumnNumber列、width 宽度 、height 
*高度 以及bgcolor背景颜色，需要锁定调用方法： $('#tabs').fixTable(1, 0, 800, 420);
* Created: 2013.10.25
* Author : liangjw
* Company:Copyright (C) 2013 Create Family Wealth Power By Peter
* Remark :
* Update : 2013.11.19
* Remark :更新查看页面运用js实现只读属性。
* Update : 2013.11.20
* Remark :更新加入绑定事件，进行行的选择，全选或反选，如果是check复选框 ，绑定click事件在pageLoad中进行修改加入
*
==============================================================================*/
$(document).ready(function () {
    pageLoad();  //页面加载调用table样式表处理方法

});
//////////////////////////////////////////////////////////////////////
//页面加载时，对Table表格移动鼠标行变色操作
//////////////////////////////////////////////////////////////////////
function pageLoad() {

    $("table[class=tb_data]").each(function () {
        var _this = $(this);
        //设置偶数行和奇数行颜色
        _this.find("tr:even").css("background-color", "#f8f8f8");
        _this.find("tr:odd").css("background-color", "#f0f0f0");

        //鼠标移动隔行变色
        _this.find("tr:not(:first)").hover(function () {
            $(this).attr("bColor", $(this).css("background-color")).css("background-color", "#E0E0E0").css("cursor", "pointer");
        }, function () {
            $(this).css("background-color", $(this).attr("bColor"));
        }).bind("click", function (event) {  //绑定事件，进行行的选择，全选或反选
            if (event.target.nodeName != "A" && event.target.nodeName != "IMG" && $(event.target).find("a,img").length == 0) {
                var _cbx = $(":checkbox", this);
                _cbx.prop("checked", !_cbx.prop("checked"));
            }
        }).find("td:eq(0) :checkbox").bind("click", function () { //如果是check复选框 ，绑定click事件
            $(this).prop("checked", !$(this).prop("checked"));
        });
        $(this).find("tr:first :checkbox").bind("click", function () {
            _this.find("tr:not(:first) :checkbox").prop("checked", $(this).prop("checked"));
        });
    });
    GetinitControl(); //遍历属性设置
}
//////////////////////////////////////////////////////////////////////
//遍历界面上所有控件进行属性设置方法封装  2013-11-19
//////////////////////////////////////////////////////////////////////
function GetinitControl() {

    var flag = getURLParam("flag", window.location.href);  //获取编辑id数值参数.flag=1为查看
    if (flag == 1) {
        $("input,select,#tt").attr("disabled", "disabled");
        if ($(this).attr("id") && $(this).attr("id") != "" && $(this).attr("id") != "link")
            $(this).attr("disabled", "disabled");
    }
}
//////////////////////////////////////////////////////////////////////
//通用列表页面批量删除判断是否有选中项  2013-11-03
//////////////////////////////////////////////////////////////////////
function delChecked() {

    var cbxBool = 0;

    if (cbxArray[0] == "") {
        alert("没有选中项");
        return false;
    }

    for (var i = 0; i < cbxArray.length; i++) {
        var obj = $("#" + cbxArray[i]).prop("checked");
        //如果有选中的则cbxBool=1。退出循环，否则不进入
        if (obj == true) {
            cbxBool = 1;
            break;
        }
    }

    //有选中项
    if (cbxBool == 1) {
        var result = confirm("删除后数据将不能恢复，确定当前操作吗？");
        if (result)
            return true;
        else
            return false;
    }
    else {
        alert("没有选中项");
        return false;
    }
    return true;
}
//////////////////////////////////////////////////////////////////////
//通用列表页面批量删除判断是否有选中项  2013-11-03
//////////////////////////////////////////////////////////////////////
function CheckedALL() {

    var cbxBool = 0;

    if (cbxArray[0] == "") {
        alert("没有选中项");
        return false;
    }

    for (var i = 0; i < cbxArray.length; i++) {
        var obj = $("#" + cbxArray[i]).prop("checked");
        //如果有选中的则cbxBool=1。退出循环，否则不进入
        if (obj == true) {
            cbxBool = 1;
            break;
        }
    }
    return true;
}
//////////////////////////////////////////////////////////////////////
//复制操作只能选择一个选项的  2013-11-05 
//////////////////////////////////////////////////////////////////////
function check(obj, type, inValue, isSingle) {

    if (isSingle == 1) {
        //只能选择一个 2013-12-30 add
        $('.c14 input').each(function () {
            if (this != obj)
                $(this).attr("checked", false);
            else {
                if ($(this).prop("checked"))
                    $(this).attr("checked", true);
                else
                    $(this).attr("checked", false);
            }
        });
    }
    else {
        //全部隐藏数据信息
        if (inValue == -1) {
            for (var i = 1; i < 12; i++) {
                $(".cx" + i + "").hide();
            }
        }

        GetinitControl();
        if (inValue == 0) {  //后台注册调用进行逻辑处理判断操作
            $(".cx" + type).show();
        }
        else {
            $('.' + type + ' input').each(function (i) {

                var tt = $("span:eq(" + (i + 1) + ")").attr("mtype");

                if (this != obj) {
                    $(this).attr("checked", false);
                }
                else {
                    if ($(this).prop("checked")) {
                        $(this).attr("checked", true);
                        if (inValue == -1) {
                            $(".cx" + tt).show();
                        }
                    }
                    else {
                        $(this).attr("checked", false);
                        if (inValue == -1) {
                            $(".cx" + tt).hide();
                        }
                    }
                }
            });
        }
    }
}
//////////////////////////////////////////////////////////////////////
//得到Url地址指定参数的数值信息方法封装
//strParamName 参数名称  url=window.location.href
//////////////////////////////////////////////////////////////////////
function getURLParam(strParamName, url) {
    var strReturn = "";
    var strHref = url.toLowerCase();
    if (strHref.indexOf("?") > -1) {
        var strQueryString = strHref.substr(strHref.indexOf("?") + 1).toLowerCase();
        var aQueryString = strQueryString.split("&");
        for (var iParam = 0; iParam < aQueryString.length; iParam++) {
            if (aQueryString[iParam].indexOf(strParamName.toLowerCase() + "=") > -1) {
                var aParam = aQueryString[iParam].split("=");
                strReturn = aParam[1];
                break;
            }
        }
    }
    return strReturn;
}
////////////////////////////////////////////////////////////////////////////
//对datatable的处理，进行锁定行和列的指定方法，例如锁定
//FixRowNumber 行 、 FixColumnNumber列、width 宽度 、height 高度 以及bgcolor背景颜色
//$('#tabs').fixTable(1, 0, 800, 420);
////////////////////////////////////////////////////////////////////////////
$.fn.extend({
    fixTable: function (FixRowNumber, FixColumnNumber, width, height, bgcolor) {
        var TableID = $(this).attr("id");
        if ($("#" + TableID + "_tableLayout").length != 0) {
            $("#" + TableID + "_tableLayout").before($("#" + TableID));
            $("#" + TableID + "_tableLayout").remove();
        }

        $("#" + TableID).after("<div id='" + TableID + "_tableLayout' style='overflow:hidden;height:" + height + "px; width:" + width + "px;'></div>");
        $('<div id="' + TableID + '_tableFix"></div>'
        + '<div id="' + TableID + '_tableHead"></div>'
        + '<div id="' + TableID + '_tableColumn"></div>'
        + '<div id="' + TableID + '_tableData"></div>').appendTo("#" + TableID + "_tableLayout");
        var oldtable = $("#" + TableID);
        var tableFixClone = oldtable.clone(true);
        tableFixClone.attr("id", TableID + "_tableFixClone");
        $("#" + TableID + "_tableFix").append(tableFixClone);
        var tableHeadClone = oldtable.clone(true);
        tableHeadClone.attr("id", TableID + "_tableHeadClone");
        $("#" + TableID + "_tableHead").append(tableHeadClone);
        var tableColumnClone = oldtable.clone(true);
        tableColumnClone.attr("id", TableID + "_tableColumnClone");
        $("#" + TableID + "_tableColumn").append(tableColumnClone);
        $("#" + TableID + "_tableData").append(oldtable);
        $("#" + TableID + "_tableLayout table").each(function () {
            $(this).css("margin", "0");
        });
        var HeadHeight = 0;
        for (var i = 0; i < FixRowNumber; i++) {
            HeadHeight += $("#" + TableID + "_tableHead tr").eq(i).height();
        }
        HeadHeight += 2;
        $("#" + TableID + "_tableHead").css("height", HeadHeight);
        $("#" + TableID + "_tableFix").css("height", HeadHeight);
        var ColumnsWidth = 0;
        var ColumnsNumber = 0;
        $("#" + TableID + "_tableColumn tr:last td:lt(" + FixColumnNumber + ")").each(function () {
            ColumnsWidth += $(this).outerWidth(true);
            ColumnsNumber++;
        });
        ColumnsWidth += 2;
        if (/msie 7/.test(navigator.userAgent.toLowerCase())) {
            if (ColumnsNumber >= 3) ColumnsWidth--;
        }
        if (/msie 8/.test(navigator.userAgent.toLowerCase())) {
            if (ColumnsNumber >= 2) ColumnsWidth--;
        }
        $("#" + TableID + "_tableColumn").css("width", ColumnsWidth);
        $("#" + TableID + "_tableFix").css("width", ColumnsWidth);
        $("#" + TableID + "_tableData").scroll(function () {
            $("#" + TableID + "_tableHead").scrollLeft($("#" + TableID + "_tableData").scrollLeft());
            $("#" + TableID + "_tableColumn").scrollTop($("#" + TableID + "_tableData").scrollTop());
        });
        $("#" + TableID + "_tableFix").css({ "overflow": "hidden", "position": "relative", "z-index": "50", "background-color": bgcolor ? bgcolor : "#fff" });
        $("#" + TableID + "_tableHead").css({ "overflow": "hidden", "width": width - 17, "position": "relative", "z-index": "45", "background-color": bgcolor ? bgcolor : "#fff" });
        $("#" + TableID + "_tableColumn").css({ "overflow": "hidden", "height": height - 17, "position": "relative", "z-index": "40", "background-color": bgcolor ? bgcolor : "#fff" });
        $("#" + TableID + "_tableData").css({ "overflow": "scroll", "width": width, "height": height, "position": "relative", "z-index": "35" });
        $("#" + TableID + "_tableFix").offset($("#" + TableID + "_tableLayout").offset());
        $("#" + TableID + "_tableHead").offset($("#" + TableID + "_tableLayout").offset());
        $("#" + TableID + "_tableHead").offset($("#" + TableID + "_tableLayout").offset());
        $("#" + TableID + "_tableColumn").offset($("#" + TableID + "_tableLayout").offset());
        $("#" + TableID + "_tableData").offset($("#" + TableID + "_tableLayout").offset());
    }
});

