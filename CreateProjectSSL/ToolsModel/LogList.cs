/******************************************************************************
 * 
 * Filename:  LogList.cs
 * Description:   操作日志表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-10-28 7:38:09
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
    /// 操作日志表
    /// </summary>
    [Serializable]
    public partial class LogList
    {
        public LogList()
        { }
        #region Model
        private int _id;
        private DateTime? _logtime = DateTime.Now;
        private string _logdetail;
        private int? _userid;
        private string _username;
        private string _tmp_data;
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime? LogTime
        {
            set { _logtime = value; }
            get { return _logtime; }
        }
        /// <summary>
        /// 发生详情
        /// </summary>
        public string LogDetail
        {
            set { _logdetail = value; }
            get { return _logdetail; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? userID
        {
            set { _userid = value; }
            get { return _userid; }
        }
         /// <summary>
        /// 用户名称
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 临时时间
        /// </summary>
        public string tmp_Data
        {
            set { _tmp_data = value; }
            get { return _tmp_data; }
        }
        #endregion Model

    }
}

