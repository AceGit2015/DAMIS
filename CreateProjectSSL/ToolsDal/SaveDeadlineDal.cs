/******************************************************************************
 * 
 * Filename:  SaveDeadlineDal.cs
 * Description:   数据库访问底层、针对返回一行记录DataRow、一个数据集DataSet、DataTable,
* 以及增加、修改、删除返回受影响的行数,和查询方法
 * Author :  liangjw
 * Created Mark:   2013-11-01 20:33:25
 * E-mail： wanyoujun8@163.com
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
    public class SaveDeadlineDal
    {
        #region 搜索列表分页获取数据列表
        /// <summary>
        /// 分页获取数据列表（保管期限表）
        /// </summary>
        public PeterPages GetSearch(SaveDeadline SaveDeadline, int PageIndex, int PageSize)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            if (!string.IsNullOrEmpty(SaveDeadline.YearName))
            {
                sqlwhere = sqlwhere + " and YearName like '%" + SaveDeadline.YearName + "%' ";
            }
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[SaveDeadline]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            entity.Orderfield = " id desc";  //排序字段
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
            return TSQLServer.ExecDt("select * from [SaveDeadline] where 1=1 " + strwhere);
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
            return TSQLServer.ExecDr("select * from [SaveDeadline] where id =" + values[0]);
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
            return TSQLServer.ExecuteNonQuery("delete [SaveDeadline] where id =" + values[0]);
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
            return TSQLServer.ExecuteNonQuery("delete [SaveDeadline] where id in(" + values + ")");
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
            strSql.Append("insert into SaveDeadline(");
            strSql.Append("YearName,UserID,Username,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@YearName,@UserID,@Username,@OperateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@YearName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,6),
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];

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
            strSql.Append("update SaveDeadline set ");
            strSql.Append("YearName=@YearName,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Username=@Username,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@YearName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,6),
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];
            parameters[4].Value = values[4];

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            
        }
        #endregion

    }
}
