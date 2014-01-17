/****************************************************************
 * 类名：AccessDataSet(访问DataSet工具类)
 * 功能：对DataSet访问的基本方法的封装
 * 日期：2008.05.11
 ****************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ToolsCommon
{
    public static class AccessDataSet
    {
        /// <summary>
        /// 判断DataTable是否有数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool HasDataTable(DataTable dt)
        {
            bool result = false;
            if ((dt != null)
                && (dt.Rows.Count > 0)
                && (dt.Rows[0] != null))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 判断DataSet是否有数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool HasData(DataSet ds)
        {
            bool result = false;
            if ((ds != null)
                && (ds.Tables.Count > 0)
                && (ds.Tables[0] != null)
                && (ds.Tables[0].Rows.Count > 0)
                && (ds.Tables[0].Rows[0] != null))
            {
                result = true;
            }
            return result;
        }

        #region 表集合与表对象访问相关
        /// <summary>
        /// 得到dataset中的所有表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataTableCollection GetTables(DataSet ds)
        {
            return ds.Tables;
        }
        /// <summary>
        /// 得到dataset中的表个数
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int GetTableCount(DataSet ds)
        {
            return ds.Tables.Count;
        }
        /// <summary>
        /// 得到dataset中的第一张表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataTable GetTable(DataSet ds)
        {
            return ds.Tables[0];
        }
        /// <summary>
        /// 根据表名，得到dataset中的某张表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static DataTable GetTable(DataSet ds, string tablename)
        {
            return ds.Tables[tablename];
        }
        /// <summary>
        /// 根据表索引，得到dataset中的某张表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="index">表索引</param>
        /// <returns></returns>
        public static DataTable GetTable(DataSet ds, int index)
        {
            return ds.Tables[index];
        }
        #endregion

        #region 行集合与行对象访问相关
        /// <summary>
        /// 得到dataset中第一张表的所有行
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataRowCollection GetRows(DataSet ds)
        {
            return ds.Tables[0].Rows;
        }
        /// <summary>
        /// 根据表名，得到dataset中某张表的所有行
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static DataRowCollection GetRows(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Rows;
        }
        /// <summary>
        /// 根据表索引，得到dataset中某张表的所有行
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <returns></returns>
        public static DataRowCollection GetRows(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Rows;
        }

        /// <summary>
        /// 得到dataset中第一张表的行数
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int GetRowCount(DataSet ds)
        {
            return ds.Tables[0].Rows.Count;
        }
        /// <summary>
        /// 根据表名，得到dataset中某张表的行数
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static int GetRowCount(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Rows.Count;
        }
        /// <summary>
        /// 根据表索引，得到dataset中某张表的行数
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <returns></returns>
        public static int GetRowCount(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Rows.Count;
        }

        /// <summary>
        /// 根据行索引，得到dataset中第一张表的某行
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">行索引</param>
        /// <returns></returns>
        public static DataRow GetRow(DataSet ds, int rowindex)
        {
            return ds.Tables[0].Rows[rowindex];
        }
        /// <summary>
        /// 根据表名、行索引，得到dataset中某张表的某行
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="rowindex">行索引</param>
        /// <returns></returns>
        public static DataRow GetRow(DataSet ds, string tablename, int rowindex)
        {
            return ds.Tables[tablename].Rows[rowindex];
        }
        /// <summary>
        /// 根据表索引、行索引，得到dataset中某张表的某行
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="rowindex">行索引</param>
        /// <returns></returns>
        public static DataRow GetRow(DataSet ds, int tableindex, int rowindex)
        {
            return ds.Tables[tableindex].Rows[rowindex];
        }
        #endregion

        #region 列集合与列对象访问相关
        /// <summary>
        /// 得到dataset中第一张表的所有列
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataColumnCollection GetColumns(DataSet ds)
        {
            return ds.Tables[0].Columns;
        }
        /// <summary>
        /// 根据表名，得到dataset中某张表的所有列
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static DataColumnCollection GetColumns(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Columns;
        }
        /// <summary>
        /// 根据表索引，得到dataset中某张表的所有列
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <returns></returns>
        public static DataColumnCollection GetColumns(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Columns;
        }

        /// <summary>
        /// 得到dataset中第一张表的列数
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int GetColumnCount(DataSet ds)
        {
            return ds.Tables[0].Columns.Count;
        }
        /// <summary>
        /// 根据表名，得到dataset中某张表的列数
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static int GetColumnCount(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Columns.Count;
        }
        /// <summary>
        /// 根据表索引，得到dataset中某张表的列数
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <returns></returns>
        public static int GetColumnCount(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Columns.Count;
        }

        /// <summary>
        /// 根据列索引，得到dataset中第一张表的某列
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static DataColumn GetColumn(DataSet ds, int columnindex)
        {
            return ds.Tables[0].Columns[columnindex];
        }
        /// <summary>
        /// 根据表名、列索引，得到dataset中第某张表的某列
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static DataColumn GetColumn(DataSet ds, string tablename, int columnindex)
        {
            return ds.Tables[tablename].Columns[columnindex];
        }
        /// <summary>
        /// 根据表索引、列索引，得到dataset中第某张表的某列
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static DataColumn GetColumn(DataSet ds, int tableindex, int columnindex)
        {
            return ds.Tables[tableindex].Columns[columnindex];
        }
        /// <summary>
        /// 根据表名、行索引、列名，得到dataset中指定的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="rowindex">行索引</param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, string tablename, int rowindex, string columnname)
        {
            return ds.Tables[tablename].Rows[rowindex][columnname];
        }
        /// <summary>
        /// 根据表索引、行索引、列名，得到dataset中指定的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="rowindex">行索引</param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, int tableindex, int rowindex, string columnname)
        {
            return ds.Tables[tableindex].Rows[rowindex][columnname];
        }
        /// <summary>
        /// 根据表名、行索引、列索引，得到dataset中指定的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="rowindex">行索引</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, string tablename, int rowindex, int columnindex)
        {
            return ds.Tables[tablename].Rows[rowindex][columnindex];
        }
        /// <summary>
        /// 根据表索引、行索引、列索引，得到dataset中指定的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="rowindex">行索引</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, int tableindex, int rowindex, int columnindex)
        {
            return ds.Tables[tableindex].Rows[rowindex][columnindex];
        }
        /// <summary>
        /// 根据表名、行索引,得到dataset中指定表指定行的首列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="rowindex">行索引</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, string tablename, int rowindex)
        {
            return ds.Tables[tablename].Rows[rowindex][0];
        }
        /// <summary>
        /// 根据表索引、行索引,得到dataset中指定表指定行的首列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="rowindex">行索引</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, int tableindex, int rowindex)
        {
            return ds.Tables[tableindex].Rows[rowindex][0];
        }

        /// <summary>
        /// 根据列名，得到dataset中指定第一张表第一行的指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static object GetTable0Row0Column(DataSet ds, string columnname)
        {
            return ds.Tables[0].Rows[0][columnname];
        }
        /// <summary>
        /// 根据列索引，得到dataset中指定第一张表第一行的指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static object GetTable0Row0Column(DataSet ds, int columnindex)
        {
            return ds.Tables[0].Rows[0][columnindex];
        }
        /// <summary>
        /// 得到dataset中指定第一张表首行首列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static object GetTable0Row0Column(DataSet ds)
        {
            return ds.Tables[0].Rows[0][0];
        }

        /// <summary>
        /// 根据行索引、列名,得到dataset中第一张表指定行指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">行索引</param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static object GetTable0RowColumn(DataSet ds, int rowindex, string columnname)
        {
            return ds.Tables[0].Rows[rowindex][columnname];
        }
        /// <summary>
        /// 根据行索引、列索引,得到dataset中第一张表指定行指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">行索引</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static object GetTable0RowColumn(DataSet ds, int rowindex, int columnindex)
        {
            return ds.Tables[0].Rows[rowindex][columnindex];
        }
        /// <summary>
        /// 根据行索引,得到dataset中第一张表指定行首列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">行索引</param>
        /// <returns></returns>
        public static object GetTable0RowColumn(DataSet ds, int rowindex)
        {
            return ds.Tables[0].Rows[rowindex][0];
        }

        /// <summary>
        /// 根据表名、列名,得到dataset中指定表首行指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, string tablename, string columnname)
        {
            return ds.Tables[tablename].Rows[0][columnname];
        }
        /// <summary>
        /// 根据表名、列索引,得到dataset中指定表首行指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, string tablename, int columnindex)
        {
            return ds.Tables[tablename].Rows[0][columnindex];
        }
        /// <summary>
        /// 根据表索引、列名,得到dataset中指定表首行指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, int tableindex, string columnname)
        {
            return ds.Tables[tableindex].Rows[0][columnname];
        }
        /// <summary>
        /// 根据表索引、列索引,得到dataset中指定表首行指定列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <param name="columnindex">列索引</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, int tableindex, int columnindex)
        {
            return ds.Tables[tableindex].Rows[0][columnindex];
        }
        /// <summary>
        /// 根据表名,得到dataset中指定表首行首列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Rows[0][0];
        }
        /// <summary>
        /// 根据表索引,得到dataset中指定表首行首列的值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">表索引</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Rows[0][0];
        }
        #endregion

        
        public static DataSet DelRow(DataSet ds, string colName,string delVal)
        {
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                if (ds.Tables[0].Rows[k][colName].ToString() == delVal)
                {
                    ds.Tables[0].Rows.RemoveAt(k);
                    break;
                }
            }
            return ds;
        }
    }
}
