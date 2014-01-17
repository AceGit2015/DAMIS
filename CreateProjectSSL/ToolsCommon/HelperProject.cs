/******************************************************************************
 * 
 * Filename:  HelperProject.cs
 * Description: 对datatable数据集合进行处理方法封装
 * Author :  liangjw
 * Created Mark:  2013-10-28
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public static class HelperProject
{
    #region 对DataTable 加入条件字符条件处理返回新的DataTable
    /// <summary>
    ///  对DataTable 加入条件字符条件处理返回新的DataTable
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="filterStr"></param>
    /// <returns></returns>
    public static DataTable Where(this DataTable dt, string filterStr)
    {
        DataView defaultView = dt.DefaultView;
        defaultView.RowFilter = filterStr;
        return defaultView.ToTable();
    }
    public static DataTable Where(this DataSet ds, string filterStr)
    {
        DataTable result;
        try
        {
            result = ds.Tables[0].Where(filterStr);
        }
        catch
        {
            result = null;
        }
        return result;
    }
    #endregion
}
