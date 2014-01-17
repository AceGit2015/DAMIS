/******************************************************************************
 * 
 * Filename:  UserList.cs
 * Description:   用户信息表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-10-28 7:39:12
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ：Create Family Wealth © Copyright 2011 - 2013.All Rights Reserved.
 * Remark: 无
 * Update Author:   无
 * Update Description: 无
 * Update Mark : 无
 * 
*******************************************************************************/
using System;
namespace ToolsModel
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Serializable]
    public partial class UserList
    {
        public UserList()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _password;
        private string _userrealname;
        private string _usertel;
        private int? _userstate;
        private string _usermail;
        private DateTime? _userlastlogin;
        private string _userpost;
        private DateTime? _addtime = DateTime.Now;
        private string _UserID;
        private string _UserName2;
        private string _OperateTime;
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string passWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string userRealName
        {
            set { _userrealname = value; }
            get { return _userrealname; }
        }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string userTel
        {
            set { _usertel = value; }
            get { return _usertel; }
        }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int? userState
        {
            set { _userstate = value; }
            get { return _userstate; }
        }
        /// <summary>
        /// 用户Email
        /// </summary>
        public string userMail
        {
            set { _usermail = value; }
            get { return _usermail; }
        }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime? userLastLogin
        {
            set { _userlastlogin = value; }
            get { return _userlastlogin; }
        }
        /// <summary>
        /// 用户权限
        /// </summary>
        public string userPost
        {
            set { _userpost = value; }
            get { return _userpost; }
        }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string UserName2
        {
            set { _UserName2 = value; }
            get { return _UserName2; }
        }
        /// <summary>
        /// 操作日期
        /// </summary>
        public string OperateTime
        {
            set { _OperateTime = value; }
            get { return _OperateTime; }
        }
        #endregion Model

    }
}

