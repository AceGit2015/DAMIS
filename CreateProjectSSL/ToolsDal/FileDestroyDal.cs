/******************************************************************************
 * 
 * Filename: FileDestroyDal.cs
 * Description:   数据库访问底层、针对返回一行记录DataRow、一个数据集DataSet、DataTable,
* 以及增加、修改、删除返回受影响的行数,和查询方法
 * Author :  liangjw
 * Created Mark:   2013-11-28 05:29:19
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
    public class FileDestroyDal
    {
        #region 搜索列表分页获取数据列表
        /// <summary>
        /// 分页获取数据列表（案卷借阅表）
        /// </summary>
        public PeterPages GetSearch(FileDestroy FileDestroy, int PageIndex, int PageSize, string strCountyId)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            if (FileDestroy.FileClassID > 0)
            {
                sqlwhere = sqlwhere + " and FileClassID like '%" + FileDestroy.FileClassID + "%' ";
            }
            if (!string.IsNullOrEmpty(FileDestroy.FileEnterName))
            {
                sqlwhere = sqlwhere + " and FileEnterName like '%" + FileDestroy.FileEnterName + "%' ";
            }
            if (strCountyId != "")
            {
                sqlwhere = sqlwhere + " and SZQXDM ='" + strCountyId + "' ";
            }

            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[FileDestroy]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            entity.Orderfield = " DestroyDate desc";  //排序字段
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
            return TSQLServer.ExecDt("select * from [FileDestroy] where 1=1 " + strwhere);
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
            return TSQLServer.ExecDr("select * from [FileDestroy] where id =" + values[0] + "");
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
            return TSQLServer.ExecuteNonQuery("delete [FileDestroy] where id =" + values[0] + "");
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
            return TSQLServer.ExecuteNonQuery("delete [FileDestroy] where id in(" + values + ")");
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
            strSql.Append("insert into FileDestroy(");
            strSql.Append("FileEnterID,FileClassID,FileClassName,FileEnterName,ApproverPeople,ApproverUnit,SupervisePeople,SuperviseUnit,DestroyPeople,DestroyDate,DestroyAds,OperateTime,Remark,UserID,Username,SZQXDM)");
            strSql.Append(" values (");
            strSql.Append("@FileEnterID,@FileClassID,@FileClassName,@FileEnterName,@ApproverPeople,@ApproverUnit,@SupervisePeople,@SuperviseUnit,@DestroyPeople,@DestroyDate,@DestroyAds,@OperateTime,@Remark,@UserID,@Username,@SZQXDM)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileEnterID", SqlDbType.Int,4),
					new SqlParameter("@FileClassID", SqlDbType.Int,4),
					new SqlParameter("@FileClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileEnterName", SqlDbType.NVarChar,100),
					new SqlParameter("@ApproverPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@ApproverUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisePeople", SqlDbType.NVarChar,50),
					new SqlParameter("@SuperviseUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@DestroyPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@DestroyDate", SqlDbType.NVarChar,50),
					new SqlParameter("@DestroyAds", SqlDbType.NVarChar,100),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@UserID", SqlDbType.VarChar,6),
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@SZQXDM", SqlDbType.VarChar,6)};
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
            strSql.Append("update FileDestroy set ");
            strSql.Append("FileEnterID=@FileEnterID,");
            strSql.Append("FileClassID=@FileClassID,");
            strSql.Append("FileClassName=@FileClassName,");
            strSql.Append("FileEnterName=@FileEnterName,");
            strSql.Append("ApproverPeople=@ApproverPeople,");
            strSql.Append("ApproverUnit=@ApproverUnit,");
            strSql.Append("SupervisePeople=@SupervisePeople,");
            strSql.Append("SuperviseUnit=@SuperviseUnit,");
            strSql.Append("DestroyPeople=@DestroyPeople,");
            strSql.Append("DestroyDate=@DestroyDate,");
            strSql.Append("DestroyAds=@DestroyAds,");
            strSql.Append("OperateTime=@OperateTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Username=@Username,");
            strSql.Append("SZQXDM=@SZQXDM");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@FileEnterID", SqlDbType.Int,4),
					new SqlParameter("@FileClassID", SqlDbType.Int,4),
					new SqlParameter("@FileClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileEnterName", SqlDbType.NVarChar,100),
					new SqlParameter("@ApproverPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@ApproverUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisePeople", SqlDbType.NVarChar,50),
					new SqlParameter("@SuperviseUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@DestroyPeople", SqlDbType.NVarChar,50),
					new SqlParameter("@DestroyDate", SqlDbType.NVarChar,50),
					new SqlParameter("@DestroyAds", SqlDbType.NVarChar,100),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@UserID", SqlDbType.VarChar,6),
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@SZQXDM", SqlDbType.VarChar,6),
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

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion
    }
}
