/*
* Filename: FReport.js
* Description:文档报表表分析，通过GetseriesValue获取每个文档类别录入的数据，返回一个json字符串进行处理操作，
* 运用highcharts控件进行每一个数据的绑定操作，table列表和图表控件展现。
* Created: 2013.11.14
* Author : liangjw
* Company:Copyright (C) 2013 Create Family Wealth Power By Peter
*/
////////////////////////////////////////////////////////////////////////////////////////////////////
var dataTmp = "";
$(document).ready(function () {
    //进行table锁定操作
    $('#tabs').width(280 * $("#tabs tr:eq(0) th").length).fixTable(1, 1, $(window).outerWidth() * 0.98, 100);
    GetseriesValue();
});
//////////////////////////////////////////////////////////////////////
//获取数据源信息返回json字符串
//////////////////////////////////////////////////////////////////////
function GetseriesValue() {
    //查询条件'
    var fFileName = $("#fFileName").val();  // 案卷类别编号
    var fileSelectValue = $("#fFileName option:selected").text(); //案卷类别名称

    $.ajax({
        type: "get",
        url: "../../ashx/GetJson.ashx",
        data: { method: "filereportlist", fFileName: fFileName },
        dataType: "json",
        cache: false,
        success: function (data) {

            //拼接json数据集字符串
            for (var key in data) {
                for (var result in data[key]) {
                    if (result != "ReportClassID") {
                        dataTmp += "{name: '" + result + "', data: [" + data[key][result] + "]},";
                    }
                }
            }
            //去除最后一个字符
            dataTmp = dataTmp.substring(0, dataTmp.length - 1);
            GetData(dataTmp, fileSelectValue);
        },
        error: function () {
            alert("请求超时，请重试！");
        }
    });
};
//////////////////////////////////////////////////////////////////////
//绑定获取数据信息到图表控件中显示
//////////////////////////////////////////////////////////////////////
function GetData(dataTmp, fileSelectValue) {

    //绑定数据信息
    $('#container').highcharts({
        chart: {
            type: 'column',
            backgroundColor: {
                linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                stops: [[0, 'rgb(255, 255, 255)'], [1, 'rgb(240, 240, 255)']]
            },
            borderWidth: 2,
            plotBackgroundColor: 'rgba(255, 255, 255, .9)',
            plotShadow: true,
            plotBorderWidth: 1
        },
        title: {
            text: fileSelectValue + " - 统计分析报表",
            x: -20
        },
        subtitle: {
            x: -20
        },
        xAxis: {
            gridLineWidth: 1,
            lineColor: '#000',
            tickColor: '#000'
        },
        yAxis: {
            minorTickInterval: 'auto',
            lineColor: '#000',
            lineWidth: 1,
            tickWidth: 1,
            tickColor: '#000',
            min: 0,
            labels: {
                formatter: function () {  //设置纵坐标值的样式  
                    return this.value + ' /Qty';
                }
            },
            title: {
                text: '单位（份） '
            },
            plotLines: [{
                width: 1,
                color: '#808080'
            }],
            allowDecimals: false   //Y轴刻度不显示小数
        },
        tooltip: {
            formatter: function () {
                return '<b>' + this.series.name + '</b>' + ': ' + this.y;
            }
        },
        legend: {
            itemStyle: {
                font: '9pt Trebuchet MS, Verdana, sans-serif',
                color: 'black'
            },
            itemHoverStyle: {
                color: '#039'
            },
            itemHiddenStyle: {
                color: 'gray'
            },
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: eval("[" + dataTmp + "]")  //获取数据源操作信息
    });
}
