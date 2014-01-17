/******************************************************************************
 * 
 * Filename:  InteractiveExcel.cs
 * Description:  通用类数据导出excel方法，包含读取DataTable数据集进行导出到Excel文档中，
 * 获取DataTable数据集合插入Excel表格中的指定行和列,并进行单元格样式的控制以及大于指定的
 * 【65535】行数则需要创建一个新的sheet，保存文件路径以及文件下载
 * Author :  liangjw
 * Created Mark:  2013-10-28
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:   无
 * Update Description: 无
 * Update Mark : 无
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using NPOI.HSSF.UserModel;  //加入NPOI.dll添加的引用
using NPOI.SS.UserModel;

public class InteractiveExcel
{

    //实力工作簿
    public HSSFWorkbook workbook;
    public ISheet sheet;
    public IDrawing patriarch;

    #region 构造实例化函数
    /// <summary>
    /// 构造实例化函数
    /// </summary>
    /// <param name="excelPath">文件路径</param>
    public InteractiveExcel(string excelPath = "")
    {
        if (excelPath == "")
        {
            workbook = new HSSFWorkbook();
            return;
        }

        try
        {
            FileStream fileStream = new FileStream(excelPath, FileMode.Open);
            workbook = new HSSFWorkbook(fileStream);
            fileStream.Close();
        }
        catch
        {
            workbook = new HSSFWorkbook();
        }
    }

    public InteractiveExcel(Stream fileContent)
    {
        if (fileContent == null)
            workbook = new HSSFWorkbook();
        else
            workbook = new HSSFWorkbook(fileContent);
    }
    #endregion

    #region 导出创建新的Excel数据
    /// <summary>
    /// 导出创建新的Excel数据
    /// </summary>
    /// <param name="sheetName"></param>
    public void OpenOrCreateNew(string sheetName = "Sheet1")
    {
        sheet = workbook.GetSheet(sheetName);
        if (sheet == null)
            sheet = workbook.CreateSheet(sheetName);
        patriarch = sheet.CreateDrawingPatriarch();
    }
    #endregion

    #region 读取获取DataTable数据信息
    /// <summary>
    /// 读取获取DataTable数据信息
    /// </summary>
    public DataTable ReadDataTable()
    {
        DataTable table = new DataTable();
        IRow headerRow = sheet.GetRow(0);
        int cellCount = headerRow.LastCellNum;
        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            table.Columns.Add(column);
        }
        int rowCount = sheet.LastRowNum;
        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            IRow row = sheet.GetRow(i);
            DataRow dataRow = table.NewRow();
            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) != null)
                    dataRow[j] = row.GetCell(j).ToString();
            }
            table.Rows.Add(dataRow);
        }

        return table;
    }
    #endregion

    #region 在Excel表格中插入文本数据信息
    /// <summary>
    /// 在Excel表格中插入文本数据信息
    /// </summary>
    /// <param name="rowIndex">行</param>
    /// <param name="cellIndex">单元格</param>
    /// <param name="textValue">文本数值</param>
    /// <param name="cellStyle">单元格样式</param>
    public void InsertText(int rowIndex, int cellIndex, string textValue, ICellStyle cellStyle = null)
    {
        IRow row = sheet.GetRow(rowIndex);
        if (row == null)
        {
            row = sheet.CreateRow(rowIndex);
            //row.HeightInPoints = 100;//设置导出excel表格的行的高度
        }
        ICell cell = row.GetCell(cellIndex);
        if (cell == null)
            cell = row.CreateCell(cellIndex);

        double tmp = 0; //定义临时变量，判断获取的数据是否可以转换为double类型，如果可以则设置单元格格式为数字类型，否则为文本类型
        if (double.TryParse(textValue, out tmp))
        {
            cell.SetCellType(CellType.NUMERIC);
        }
        cell.SetCellValue(textValue);
        if (cellStyle != null)
        {
            cell.CellStyle = cellStyle;
        }
    }
    #endregion

    #region 保存文件信息
    //保存提示打开信息
    public void SaveDownload(string fileName)
    {
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        ms.Seek(0, SeekOrigin.Begin);
        byte[] bytes = new byte[(int)ms.Length];
        ms.Read(bytes, 0, bytes.Length);
        ms.Close();
        ms.Dispose();

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
    #endregion

}