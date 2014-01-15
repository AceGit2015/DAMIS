/*
* Filename:FileEnterEdit.js
* Description:档案管理录入数据信息，界面操作赋值操作
* Created: 2013.11.15
* Author : liangjw
* Company:Copyright (C) 2013 Create Family Wealth Power By Peter
*/
////////////////////////////////////////////////////////////////////////////////////////////////////
$(document).ready(function () {

    $("#btnSave").click(function () {
        //执法档案案卷号
        if ($.trim($("#FilesNum").val()).length == 0) {
            alert("请输入执法档案案卷号");
            $("#FilesNum").focus();
            return false;
        }
        //执法档案目录号
        if ($.trim($("#FileDirectoryID").val()) == "") {
            alert("请选择执法档案目录号");
            $("#FileDirectoryID").focus();
            return false;
        }
        //执法档案保管期限
        if ($.trim($("#SaveDeadlineID").val()) == "") {
            alert("请选择执法档案保管期限");
            $("#SaveDeadlineID").focus();
            return false;
        }
        //执法档案承办单位
        if ($.trim($("#drop_EnforcementName").val()) == "") {
            alert("请选择执法档案承办单位");
            $("#drop_EnforcementName").focus();
            return false;
        }
        //执法档案录入人
        if ($.trim($("#txtEnterPeople").val()) == "") {
            alert("请输入执法档案录入人姓名");
            $("#txtEnterPeople").focus();
            return false;
        }
    });
});