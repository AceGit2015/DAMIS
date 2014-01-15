/******************************************************************************
 * 
 * Filename:  LogListDal.cs
 * Description:  操作日志
 * Author :  liangjw
 * Created Mark:   2013-10-29 4:53:25
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
using System.Data;
using System.Linq;
using System.Web;
using ToolsHelper;
using ToolsCommon;
using ToolsModel;
using ToolsDal.Pages;
using System.Text;
using System.Data.SqlClient;
namespace ToolsDal
{
    public class LogListDal
    {

        #region 搜索列表分页获取数据列表
        /// <summary>
        /// 分页获取数据列表（用户信息表）
        /// </summary>
        public PeterPages GetSearch(LogList LogList, int PageIndex, int PageSize)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(LogList.username))
            {
                sqlwhere = sqlwhere + " and username like '%" + LogList.username + "%' ";
            }
            //获取开始日期和结束日期
            string startTime = LogList.tmp_Data.Split('|')[0];
            string endTime = LogList.tmp_Data.Split('|')[1];
            if (startTime != "" && endTime != "")
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,LogTime, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[LogList]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            entity.Orderfield = " LogTime desc";  //排序字段
            entity.PageIndex = PageIndex;
            entity.Fields = "*";

            fy = SqlPageList.GetPageLists(entity);
            return fy;
        }
        #endregion

        #region 删除一行或者多行记录
        /// <summary>
        /// 删除一行或者多行记录
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Delete(params object[] values)
        {
            return TSQLServer.ExecuteNonQuery("delete [LogList] where id =" + values[0] + "");
        }
        //删除指定多行数据信息
        public int DeleteAllIn(string values)
        {
            return TSQLServer.ExecuteNonQuery("delete [LogList] where id in(" + values + ")");
        }
        #endregion

        #region 插入操作日志
        //插入操作日志
        public static int Insert(params object[] values)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LogList(");
            strSql.Append("LogTime,LogDetail,userID,username,LogIP,LogAddress)");
            strSql.Append(" values (");
            strSql.Append("@LogTime,@LogDetail,@userID,@username,@LogIP,@LogAddress)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LogTime", SqlDbType.DateTime),
					new SqlParameter("@LogDetail", SqlDbType.NVarChar,500),
					new SqlParameter("@userID", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@LogIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LogAddress", SqlDbType.NVarChar,200)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];
            parameters[4].Value = Utility.IPNetworking.GetClientIPv4Address();

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

    }
}