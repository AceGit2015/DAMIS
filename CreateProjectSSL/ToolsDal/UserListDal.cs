/******************************************************************************
 * 
 * Filename:  UserListDal.cs
 * Description:   数据库访问底层、针对返回一行记录DataRow、一个数据集DataSet、DataTable,
* 以及增加、修改、删除返回受影响的行数,和查询方法
 * Author :  liangjw
 * Created Mark:   2013-10-29 5:53:25
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
    public class UserListDal
    {
        #region 搜索列表分页获取数据列表
        /// <summary>
        /// 分页获取数据列表（用户信息表）
        /// </summary>
        public PeterPages GetSearch(UserList UserList, int PageIndex, int PageSize)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            if (!string.IsNullOrEmpty(UserList.userName))
            {
                sqlwhere = sqlwhere + " and userName like '%" + UserList.userName + "%' ";
            }
            if (UserList.userState != -1)
            {
                sqlwhere = sqlwhere + " and userState=" + UserList.userState + " ";
            }
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[UserList]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            entity.Orderfield = " AddTime desc";  //排序字段
            entity.PageIndex = PageIndex;
            entity.Fields = "*";

            fy = SqlPageList.GetPageLists(entity);
            return fy;
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
            return TSQLServer.ExecDr("select * from [UserList] where id =" + values[0] + "");
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
            return TSQLServer.ExecuteNonQuery("delete [UserList] where id =" + values[0]);
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
            return TSQLServer.ExecuteNonQuery("delete [UserList] where id in(" + values + ")");
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
            strSql.Append("insert into UserList(");
            strSql.Append("userName,passWord,userRealName,userTel,userState,userMail,userLastLogin,userPost,userqxdm,UserID,UserName2,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@userName,@passWord,@userRealName,@userTel,@userState,@userMail,@userLastLogin,@userPost,@userqxdm,@UserID,@UserName2,@OperateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar,50),
					new SqlParameter("@passWord", SqlDbType.NVarChar,255),
					new SqlParameter("@userRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@userTel", SqlDbType.NVarChar,50),
					new SqlParameter("@userState", SqlDbType.Int,4),
					new SqlParameter("@userMail", SqlDbType.NVarChar,50),
					new SqlParameter("@userLastLogin", SqlDbType.DateTime),
					new SqlParameter("@userPost", SqlDbType.NVarChar,50),
					new SqlParameter("@userqxdm", SqlDbType.VarChar,10),
					new SqlParameter("@UserID", SqlDbType.VarChar,6),
					new SqlParameter("@UserName2", SqlDbType.VarChar,20),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20)};
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
            strSql.Append("update UserList set ");
            strSql.Append("userName=@userName,");
            strSql.Append("passWord=@passWord,");
            strSql.Append("userRealName=@userRealName,");
            strSql.Append("userTel=@userTel,");
            strSql.Append("userState=@userState,");
            strSql.Append("userMail=@userMail,");
            strSql.Append("userLastLogin=@userLastLogin,");
            strSql.Append("userPost=@userPost,");
            strSql.Append("userqxdm=@userqxdm,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName2=@UserName2,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar,50),
					new SqlParameter("@passWord", SqlDbType.NVarChar,255),
					new SqlParameter("@userRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@userTel", SqlDbType.NVarChar,50),
					new SqlParameter("@userState", SqlDbType.Int,4),
					new SqlParameter("@userMail", SqlDbType.NVarChar,50),
					new SqlParameter("@userLastLogin", SqlDbType.DateTime),
					new SqlParameter("@userPost", SqlDbType.NVarChar,50),
					new SqlParameter("@userqxdm", SqlDbType.VarChar,10),
					new SqlParameter("@UserID", SqlDbType.VarChar,6),
					new SqlParameter("@UserName2", SqlDbType.VarChar,20),
					new SqlParameter("@OperateTime", SqlDbType.VarChar,20),
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

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 返回一个DataTable数据集合用户登录
        /// <summary>
        /// 返回一个DataTable数据集合用户登录
        /// </summary>
        /// <param name="strwhere">传递参数为用户名和密码</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetUserDataTable(string strwhere)
        {
            return TSQLServer.ExecDt(" select * from UserList us inner join QXMCB qx on us.userqxdm=qx.qxdm where 1=1 " + strwhere + "");
        }
        #endregion

        #region 返回一个DataTable数据集合用户登录
        /// <summary>
        /// 返回一个DataTable数据集合用户登录
        /// </summary>
        /// <param name="strwhere">传递参数为用户名和密码</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetUserLogin(string strusername, string struserpwd)
        {
            return TSQLServer.ExecDt("select * from [UserList] where 1=1 and userName='" + strusername + "' and passWord='" + struserpwd + "' ");
        }
        #endregion

        #region 更新登录时间
        /// <summary>
        ///  更新登录时间
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int UpdateLastLogin(params object[] values)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserList set ");
            strSql.Append("userLastLogin=@userLastLogin");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = { 
					new SqlParameter("@userLastLogin", SqlDbType.DateTime),		 
					new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = values[0];
            parameters[1].Value = values[1];

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 修改密码
        /// <summary>
        ///  修改密码
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int UpdateUserPwd(params object[] values)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserList set ");
            strSql.Append("passWord=@passWord ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = { 
					new SqlParameter("@passWord",SqlDbType.NVarChar,50),		 
					new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = values[0];
            parameters[1].Value = values[1];

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="strwhere">传递参数为用户名和密码</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetUserLoginInfor(string strusername, string struserpwd)
        {
            return TSQLServer.ExecDt("select us.id,us.userName,us.passWord,us.userqxdm,us.userPost,og.id as ogid,og.OrganizerName,us.userState from [UserList] us inner join [Organizer] og on us.userqxdm=og.OrganizerQxdm where 1=1 and us.userName='" + strusername + "' and us.passWord='" + struserpwd + "' ");
        }
        #endregion
    }
}
