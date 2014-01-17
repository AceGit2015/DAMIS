/******************************************************************************
 * 
 * Filename: FileTransferDal.cs
 * Description:   数据库访问底层、针对返回一行记录DataRow、一个数据集DataSet、DataTable,
* 以及增加、修改、删除返回受影响的行数,和查询方法
 * Author :  liangjw
 * Created Mark:   2013-11-28 05:27:32
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2011-2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:   无
 * Update Description: 无
 * Update Mark : 无
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolsCommon;
using ToolsModel;
using ToolsDal.Pages;
using ToolsHelper;
using System.Data;
using System.Data.SqlClient;


namespace ToolsDal
{
    public class FileTransferDal
    {
        #region 搜索列表分页获取数据列表
        /// <summary>
        /// 分页获取数据列表（档案移交支队）
        /// </summary>
        public PeterPages GetSearch(FileTransfer FileTransfer, int PageIndex, int PageSize, string strCountyId,string strwhere)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            //if (FileTransfer.FileClassID > 0)
            //{
            //    sqlwhere = sqlwhere + " and FileClassID like '%" + FileTransfer.FileClassID + "%' ";
            //}
            if (!string.IsNullOrEmpty(FileTransfer.FileEnterName))
            {
                sqlwhere = sqlwhere + " and FileEnterName like '%" + FileTransfer.FileEnterName + "%' ";
            }
            //获取开始日期和结束日期
            string startTime = FileTransfer.TransferDate.Split('|')[0];
            string endTime = FileTransfer.TransferDate.Split('|')[1];
            if (startTime != "" && endTime != "" && FileTransfer.Lssjlx == 0)  //移交时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,TransferDate, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            if (startTime != "" && endTime != "" && FileTransfer.Lssjlx == 1)  //接收时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,Jssj, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            if (startTime != "" && endTime != "" && FileTransfer.Lssjlx == 2)  //归档时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,Gdsj, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            if (strCountyId != "420100")
            {
                sqlwhere = sqlwhere + " and SZQXDM ='" + strCountyId + "' ";
            }
            //数据状态 0 未接收  1拒收 2已接受 3已归档
            if (FileTransfer.SJZT == 3)
            {
                sqlwhere = sqlwhere + " and sjzt  in (2,3) ";
            }
            else if (FileTransfer.SJZT == 0)
            {
            }
            else
            {
                sqlwhere = sqlwhere + " and sjzt =" + (FileTransfer.SJZT - 1) + " ";
            }
            sqlwhere = sqlwhere + strwhere ;
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[FileTransfer]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            entity.Orderfield = " sjzt asc,TransferDate desc";  //排序字段
            entity.PageIndex = PageIndex;
            entity.Fields = "*";

            fy = SqlPageList.GetPageLists(entity);
            return fy;
        }
        /// <summary>
        /// 分页获取数据列表（档案移交）归档
        /// </summary>
        public PeterPages GetSearchgd(FileTransfer FileTransfer, int PageIndex, int PageSize, string strwhere)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            if (FileTransfer.FileClassID > 0)
            {
                sqlwhere = sqlwhere + " and FileClassID like '%" + FileTransfer.FileClassID + "%' ";
            }
            if (!string.IsNullOrEmpty(FileTransfer.FileEnterName))
            {
                sqlwhere = sqlwhere + " and FileClassName like '%" + FileTransfer.FileEnterName + "%' ";
            }
            if (strwhere != "")
            {
                sqlwhere = strwhere;
            }
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[FileTransfer]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            entity.Orderfield = " TransferDate desc";  //排序字段
            entity.PageIndex = PageIndex;
            entity.Fields = "*";

            fy = SqlPageList.GetPageLists(entity);
            return fy;
        }
        #endregion

        #region 返回一个DataTable数据集合
        /// <summary>
        /// 返回一个DataTable数据集合
        /// </summary>
        /// <param name="strwhere">传递参数为id</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetDataTable(string strwhere)
        {
            return TSQLServer.ExecDt("select * from [FileTransfer] where 1=1 " + strwhere);
        }
        #endregion

        #region 返回一个DataRow数据集合
        /// <summary>
        /// 返回一个DataRow数据集合
        /// </summary>
        /// <param name="values">传递参数为id</param>
        /// <returns>返回一个DataRow</returns>
        public DataRow GetRow(params object[] values)
        {
            return TSQLServer.ExecDr("select * from [FileTransfer] where id =" + values[0] + "");
        }
        #endregion

        #region 删除一行或者多行记录
        /// <summary>
        ///删除指定一行数据信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Delete(params object[] values)
        {
            return TSQLServer.ExecuteNonQuery("delete [FileTransfer] where id =" + values[0] + "");
        }
        #endregion

        #region 删除指定多行数据信息
        /// <summary>
        /// 删除指定多行数据信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int DeleteAllIn(string values)
        {
            return TSQLServer.ExecuteNonQuery("delete [FileTransfer] where id in(" + values + ")");
        }
        #endregion

        #region 插入一行数据
        /// <summary>
        ///  插入一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int Insert(params object[] values)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FileTransfer(");
            strSql.Append("FileEnterID,FileClassID,FileClassName,FileEnterName,TransferPeople,TransferUnit,AcceptPeople,AcceptSzqxdm,AcceptUnit,ApproverPeople,ApproverUnit,TransferDate,OperateTime,Remark,UserID,Username,sjzt,Jsyy,SZQXDM,Jssj,Gdr,Gdsj,Yjlx,Xfxzxkda,Xfjdjcda,Xfaqzddwda,Zdhzyhda,Hzsgdcda,Xfxzcfda,Xfxzqzda,Xfzfjjda,Xfxsda)");
            strSql.Append(" values (");
            strSql.Append("@FileEnterID,@FileClassID,@FileClassName,@FileEnterName,@TransferPeople,@TransferUnit,@AcceptPeople,@AcceptSzqxdm,@AcceptUnit,@ApproverPeople,@ApproverUnit,@TransferDate,@OperateTime,@Remark,@UserID,@Username,@sjzt,@Jsyy,@SZQXDM,@Jssj,@Gdr,@Gdsj,@Yjlx,@Xfxzxkda,@Xfjdjcda,@Xfaqzddwda,@Zdhzyhda,@Hzsgdcda,@Xfxzcfda,@Xfxzqzda,@Xfzfjjda,@Xfxsda)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileEnterID", SqlDbType.Int,4),
					new SqlParameter("@FileClassID", SqlDbType.Int,4),
					new SqlParameter("@FileClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileEnterName", SqlDbType.NVarChar,100),
					new SqlParameter("@TransferPeople", SqlDbType.NVarChar,100),
					new SqlParameter("@TransferUnit", SqlDbType.NChar,10),
					new SqlParameter("@AcceptPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@AcceptSzqxdm", SqlDbType.NChar,10),
					new SqlParameter("@AcceptUnit", SqlDbType.NVarChar,100),
					new SqlParameter("@ApproverPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@ApproverUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TransferDate", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@Username", SqlDbType.NVarChar,50),
					new SqlParameter("@sjzt", SqlDbType.Int,4),
					new SqlParameter("@Jsyy", SqlDbType.VarChar,100),
					new SqlParameter("@SZQXDM", SqlDbType.VarChar,6),
					new SqlParameter("@Jssj", SqlDbType.VarChar,50),
					new SqlParameter("@Gdr", SqlDbType.VarChar,20),
					new SqlParameter("@Gdsj", SqlDbType.VarChar,50),
					new SqlParameter("@Yjlx", SqlDbType.Int,4),
					new SqlParameter("@Xfxzxkda", SqlDbType.Int,10),
					new SqlParameter("@Xfjdjcda", SqlDbType.Int,10),
					new SqlParameter("@Xfaqzddwda", SqlDbType.Int,10),
					new SqlParameter("@Zdhzyhda", SqlDbType.Int,10),
					new SqlParameter("@Hzsgdcda", SqlDbType.Int,10),
					new SqlParameter("@Xfxzcfda", SqlDbType.Int,10),
					new SqlParameter("@Xfxzqzda", SqlDbType.Int,10),
					new SqlParameter("@Xfzfjjda", SqlDbType.Int,10),
					new SqlParameter("@Xfxsda", SqlDbType.Int,10)};

            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];
            parameters[4].Value = values[4];
            parameters[5].Value = values[5];
            parameters[6].Value = values[6];
            parameters[7].Value = values[7];
            parameters[8].Value = values[8];
            parameters[9].Value = values[9];
            parameters[10].Value = values[10];
            parameters[11].Value = values[11];
            parameters[12].Value = values[12];
            parameters[13].Value = values[13];
            parameters[14].Value = values[14];
            parameters[15].Value = values[15];
            parameters[16].Value = values[16];
            parameters[17].Value = values[17];
            parameters[18].Value = values[18];
            parameters[19].Value = values[19];
            parameters[20].Value = values[20];
            parameters[21].Value = values[21];
            parameters[22].Value = values[22];
            parameters[23].Value = values[23];
            parameters[24].Value = values[24];
            parameters[25].Value = values[25];
            parameters[26].Value = values[26];
            parameters[27].Value = values[27];
            parameters[28].Value = values[28];
            parameters[29].Value = values[29];
            parameters[30].Value = values[30];
            parameters[31].Value = values[31];

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }



        }
        #endregion

        #region 更新一行数据
        /// <summary>
        ///  更新一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int Update(params object[] values)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileTransfer set ");
            strSql.Append("FileEnterID=@FileEnterID,");
            strSql.Append("FileClassID=@FileClassID,");
            strSql.Append("FileClassName=@FileClassName,");
            strSql.Append("FileEnterName=@FileEnterName,");
            strSql.Append("TransferPeople=@TransferPeople,");
            strSql.Append("TransferUnit=@TransferUnit,");
            strSql.Append("AcceptPeople=@AcceptPeople,");
            strSql.Append("AcceptSzqxdm=@AcceptSzqxdm,");
            strSql.Append("AcceptUnit=@AcceptUnit,");
            strSql.Append("ApproverPeople=@ApproverPeople,");
            strSql.Append("ApproverUnit=@ApproverUnit,");
            strSql.Append("TransferDate=@TransferDate,");
            strSql.Append("OperateTime=@OperateTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Username=@Username,");
            strSql.Append("Sjzt=@Sjzt,");
            strSql.Append("Jsyy=@Jsyy,");
            strSql.Append("SZQXDM=@SZQXDM,");
            strSql.Append("Jssj=@Jssj,");
            strSql.Append("Gdr=@Gdr,");
            strSql.Append("Gdsj=@Gdsj,");
            strSql.Append("Yjlx=@Yjlx");
            strSql.Append("Xfxzxkda=@Xfxzxkda,");
            strSql.Append("Xfjdjcda=@Xfjdjcda,");
            strSql.Append("Xfaqzddwda=@Xfaqzddwda,");
            strSql.Append("Zdhzyhda=@Zdhzyhda,");
            strSql.Append("Hzsgdcda=@Hzsgdcda,");
            strSql.Append("Xfxzcfda=@Xfxzcfda,");
            strSql.Append("Xfxzqzda=@Xfxzqzda,");
            strSql.Append("Xfzfjjda=@Xfzfjjda,");
            strSql.Append("Xfxsda=@Xfxsda");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@FileEnterID", SqlDbType.Int,4),
					new SqlParameter("@FileClassID", SqlDbType.Int,4),
					new SqlParameter("@FileClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileEnterName", SqlDbType.NVarChar,100),
					new SqlParameter("@TransferPeople", SqlDbType.NVarChar,100),
					new SqlParameter("@TransferUnit", SqlDbType.NChar,10),
					new SqlParameter("@AcceptPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@AcceptSzqxdm", SqlDbType.NChar,10),
					new SqlParameter("@AcceptUnit", SqlDbType.NVarChar,100),
					new SqlParameter("@ApproverPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@ApproverUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TransferDate", SqlDbType.NVarChar,20),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@Username", SqlDbType.NVarChar,50),
					new SqlParameter("@sjzt", SqlDbType.Int,4),
					new SqlParameter("@Jsyy", SqlDbType.VarChar,100),
					new SqlParameter("@SZQXDM", SqlDbType.VarChar,6),
					new SqlParameter("@Jssj", SqlDbType.VarChar,50),
					new SqlParameter("@Gdr", SqlDbType.VarChar,20),
					new SqlParameter("@Gdsj", SqlDbType.VarChar,50),
					new SqlParameter("@Yjlx", SqlDbType.Int,4),
					new SqlParameter("@Xfxzxkda", SqlDbType.Int,10),
					new SqlParameter("@Xfjdjcda", SqlDbType.Int,10),
					new SqlParameter("@Xfaqzddwda", SqlDbType.Int,10),
					new SqlParameter("@Zdhzyhda", SqlDbType.Int,10),
					new SqlParameter("@Hzsgdcda", SqlDbType.Int,10),
					new SqlParameter("@Xfxzcfda", SqlDbType.Int,10),
					new SqlParameter("@Xfxzqzda", SqlDbType.Int,10),
					new SqlParameter("@Xfzfjjda", SqlDbType.Int,10),
					new SqlParameter("@Xfxsda", SqlDbType.Int,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];
            parameters[4].Value = values[4];
            parameters[5].Value = values[5];
            parameters[6].Value = values[6];
            parameters[7].Value = values[7];
            parameters[8].Value = values[8];
            parameters[9].Value = values[9];
            parameters[10].Value = values[10];
            parameters[11].Value = values[11];
            parameters[12].Value = values[12];
            parameters[13].Value = values[13];
            parameters[14].Value = values[14];
            parameters[15].Value = values[15];
            parameters[16].Value = values[16];
            parameters[17].Value = values[17];
            parameters[18].Value = values[18];
            parameters[19].Value = values[19];
            parameters[20].Value = values[20];
            parameters[21].Value = values[21];
            parameters[22].Value = values[22];
            parameters[23].Value = values[23];
            parameters[24].Value = values[24];
            parameters[25].Value = values[25];
            parameters[26].Value = values[26];
            parameters[27].Value = values[27];
            parameters[28].Value = values[28];
            parameters[29].Value = values[29];
            parameters[30].Value = values[30];
            parameters[31].Value = values[31];
            parameters[32].Value = values[32];

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 更新一行数据接受档案
        /// <summary>
        ///  更新一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int UpdateGD(string sjzt, string ReceiptTime, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileTransfer set ");
            strSql.Append("sjzt=@sjzt ");
            strSql.Append("ReceiptTime=@ReceiptTime ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sjzt", SqlDbType.Int,4),
                    new SqlParameter("@ReceiptTime", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = sjzt;
            parameters[1].Value = ReceiptTime;
            parameters[2].Value = id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        
    }
}
