/****************************************************************
 * ������AccessDataSet(����DataSet������)
 * ���ܣ���DataSet���ʵĻ��������ķ�װ
 * ���ڣ�2008.05.11
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
        /// �ж�DataTable�Ƿ�������
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
        /// �ж�DataSet�Ƿ�������
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

        #region ����������������
        /// <summary>
        /// �õ�dataset�е����б�
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataTableCollection GetTables(DataSet ds)
        {
            return ds.Tables;
        }
        /// <summary>
        /// �õ�dataset�еı����
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int GetTableCount(DataSet ds)
        {
            return ds.Tables.Count;
        }
        /// <summary>
        /// �õ�dataset�еĵ�һ�ű�
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataTable GetTable(DataSet ds)
        {
            return ds.Tables[0];
        }
        /// <summary>
        /// ���ݱ������õ�dataset�е�ĳ�ű�
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public static DataTable GetTable(DataSet ds, string tablename)
        {
            return ds.Tables[tablename];
        }
        /// <summary>
        /// ���ݱ��������õ�dataset�е�ĳ�ű�
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="index">������</param>
        /// <returns></returns>
        public static DataTable GetTable(DataSet ds, int index)
        {
            return ds.Tables[index];
        }
        #endregion

        #region �м������ж���������
        /// <summary>
        /// �õ�dataset�е�һ�ű��������
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataRowCollection GetRows(DataSet ds)
        {
            return ds.Tables[0].Rows;
        }
        /// <summary>
        /// ���ݱ������õ�dataset��ĳ�ű��������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public static DataRowCollection GetRows(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Rows;
        }
        /// <summary>
        /// ���ݱ��������õ�dataset��ĳ�ű��������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <returns></returns>
        public static DataRowCollection GetRows(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Rows;
        }

        /// <summary>
        /// �õ�dataset�е�һ�ű������
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int GetRowCount(DataSet ds)
        {
            return ds.Tables[0].Rows.Count;
        }
        /// <summary>
        /// ���ݱ������õ�dataset��ĳ�ű������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public static int GetRowCount(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Rows.Count;
        }
        /// <summary>
        /// ���ݱ��������õ�dataset��ĳ�ű������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <returns></returns>
        public static int GetRowCount(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Rows.Count;
        }

        /// <summary>
        /// �������������õ�dataset�е�һ�ű��ĳ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">������</param>
        /// <returns></returns>
        public static DataRow GetRow(DataSet ds, int rowindex)
        {
            return ds.Tables[0].Rows[rowindex];
        }
        /// <summary>
        /// ���ݱ��������������õ�dataset��ĳ�ű��ĳ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="rowindex">������</param>
        /// <returns></returns>
        public static DataRow GetRow(DataSet ds, string tablename, int rowindex)
        {
            return ds.Tables[tablename].Rows[rowindex];
        }
        /// <summary>
        /// ���ݱ����������������õ�dataset��ĳ�ű��ĳ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="rowindex">������</param>
        /// <returns></returns>
        public static DataRow GetRow(DataSet ds, int tableindex, int rowindex)
        {
            return ds.Tables[tableindex].Rows[rowindex];
        }
        #endregion

        #region �м������ж���������
        /// <summary>
        /// �õ�dataset�е�һ�ű��������
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataColumnCollection GetColumns(DataSet ds)
        {
            return ds.Tables[0].Columns;
        }
        /// <summary>
        /// ���ݱ������õ�dataset��ĳ�ű��������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public static DataColumnCollection GetColumns(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Columns;
        }
        /// <summary>
        /// ���ݱ��������õ�dataset��ĳ�ű��������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <returns></returns>
        public static DataColumnCollection GetColumns(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Columns;
        }

        /// <summary>
        /// �õ�dataset�е�һ�ű������
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int GetColumnCount(DataSet ds)
        {
            return ds.Tables[0].Columns.Count;
        }
        /// <summary>
        /// ���ݱ������õ�dataset��ĳ�ű������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public static int GetColumnCount(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Columns.Count;
        }
        /// <summary>
        /// ���ݱ��������õ�dataset��ĳ�ű������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <returns></returns>
        public static int GetColumnCount(DataSet ds, int tableindex)
        {
            return ds.Tables[tableindex].Columns.Count;
        }

        /// <summary>
        /// �������������õ�dataset�е�һ�ű��ĳ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static DataColumn GetColumn(DataSet ds, int columnindex)
        {
            return ds.Tables[0].Columns[columnindex];
        }
        /// <summary>
        /// ���ݱ��������������õ�dataset�е�ĳ�ű��ĳ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static DataColumn GetColumn(DataSet ds, string tablename, int columnindex)
        {
            return ds.Tables[tablename].Columns[columnindex];
        }
        /// <summary>
        /// ���ݱ����������������õ�dataset�е�ĳ�ű��ĳ��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static DataColumn GetColumn(DataSet ds, int tableindex, int columnindex)
        {
            return ds.Tables[tableindex].Columns[columnindex];
        }
        /// <summary>
        /// ���ݱ��������������������õ�dataset��ָ����ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="rowindex">������</param>
        /// <param name="columnname">����</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, string tablename, int rowindex, string columnname)
        {
            return ds.Tables[tablename].Rows[rowindex][columnname];
        }
        /// <summary>
        /// ���ݱ����������������������õ�dataset��ָ����ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="rowindex">������</param>
        /// <param name="columnname">����</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, int tableindex, int rowindex, string columnname)
        {
            return ds.Tables[tableindex].Rows[rowindex][columnname];
        }
        /// <summary>
        /// ���ݱ����������������������õ�dataset��ָ����ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="rowindex">������</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, string tablename, int rowindex, int columnindex)
        {
            return ds.Tables[tablename].Rows[rowindex][columnindex];
        }
        /// <summary>
        /// ���ݱ������������������������õ�dataset��ָ����ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="rowindex">������</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, int tableindex, int rowindex, int columnindex)
        {
            return ds.Tables[tableindex].Rows[rowindex][columnindex];
        }
        /// <summary>
        /// ���ݱ�����������,�õ�dataset��ָ����ָ���е����е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="rowindex">������</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, string tablename, int rowindex)
        {
            return ds.Tables[tablename].Rows[rowindex][0];
        }
        /// <summary>
        /// ���ݱ�������������,�õ�dataset��ָ����ָ���е����е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="rowindex">������</param>
        /// <returns></returns>
        public static object GetTableRowColumn(DataSet ds, int tableindex, int rowindex)
        {
            return ds.Tables[tableindex].Rows[rowindex][0];
        }

        /// <summary>
        /// �����������õ�dataset��ָ����һ�ű��һ�е�ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnname">����</param>
        /// <returns></returns>
        public static object GetTable0Row0Column(DataSet ds, string columnname)
        {
            return ds.Tables[0].Rows[0][columnname];
        }
        /// <summary>
        /// �������������õ�dataset��ָ����һ�ű��һ�е�ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static object GetTable0Row0Column(DataSet ds, int columnindex)
        {
            return ds.Tables[0].Rows[0][columnindex];
        }
        /// <summary>
        /// �õ�dataset��ָ����һ�ű��������е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static object GetTable0Row0Column(DataSet ds)
        {
            return ds.Tables[0].Rows[0][0];
        }

        /// <summary>
        /// ����������������,�õ�dataset�е�һ�ű�ָ����ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">������</param>
        /// <param name="columnname">����</param>
        /// <returns></returns>
        public static object GetTable0RowColumn(DataSet ds, int rowindex, string columnname)
        {
            return ds.Tables[0].Rows[rowindex][columnname];
        }
        /// <summary>
        /// ������������������,�õ�dataset�е�һ�ű�ָ����ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">������</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static object GetTable0RowColumn(DataSet ds, int rowindex, int columnindex)
        {
            return ds.Tables[0].Rows[rowindex][columnindex];
        }
        /// <summary>
        /// ����������,�õ�dataset�е�һ�ű�ָ�������е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="rowindex">������</param>
        /// <returns></returns>
        public static object GetTable0RowColumn(DataSet ds, int rowindex)
        {
            return ds.Tables[0].Rows[rowindex][0];
        }

        /// <summary>
        /// ���ݱ���������,�õ�dataset��ָ��������ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="columnname">����</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, string tablename, string columnname)
        {
            return ds.Tables[tablename].Rows[0][columnname];
        }
        /// <summary>
        /// ���ݱ�����������,�õ�dataset��ָ��������ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, string tablename, int columnindex)
        {
            return ds.Tables[tablename].Rows[0][columnindex];
        }
        /// <summary>
        /// ���ݱ�����������,�õ�dataset��ָ��������ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="columnname">����</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, int tableindex, string columnname)
        {
            return ds.Tables[tableindex].Rows[0][columnname];
        }
        /// <summary>
        /// ���ݱ�������������,�õ�dataset��ָ��������ָ���е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
        /// <param name="columnindex">������</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, int tableindex, int columnindex)
        {
            return ds.Tables[tableindex].Rows[0][columnindex];
        }
        /// <summary>
        /// ���ݱ���,�õ�dataset��ָ�����������е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public static object GetTableRow0Column(DataSet ds, string tablename)
        {
            return ds.Tables[tablename].Rows[0][0];
        }
        /// <summary>
        /// ���ݱ�����,�õ�dataset��ָ�����������е�ֵ
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableindex">������</param>
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
