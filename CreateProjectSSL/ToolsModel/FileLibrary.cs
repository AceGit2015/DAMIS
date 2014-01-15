using System;
namespace ToolsModel
{
    /// <summary>
    /// 执法档案档案库室
    /// </summary>
    [Serializable]
    public partial class FileLibrary
    {
        public FileLibrary()
		{}
		#region Model
        private int _ID;
        private string _FileLibraryName;
        private string _OrganizerID;
        private string _OrganizerName;
        private string _UserID;
        private string _Username;
        private string _OperateTime;
        private string _QXDM;
		/// <summary>
		/// 档案库编号
		/// </summary>
        public int ID
		{
            set { _ID = value; }
            get { return _ID; }
		}
        /// <summary>
        /// 档案库名称
        /// </summary>
        public string FileLibraryName
        {
            set { _FileLibraryName = value; }
            get { return _FileLibraryName; }
        }
		/// <summary>
		/// 承办单位ID
		/// </summary>
        public string OrganizerID
		{
            set { _OrganizerID = value; }
            get { return _OrganizerID; }
		}
		/// <summary>
		/// 承办单位名称
		/// </summary>
        public string OrganizerName
		{
            set { _OrganizerName = value; }
            get { return _OrganizerName; }
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
        public string Username
		{
            set { _Username = value; }
            get { return _Username; }
		}
		/// <summary>
		/// 操作日期
		/// </summary>
        public string OperateTime
		{
            set { _OperateTime = value; }
            get { return _OperateTime; }
		}
        /// <summary>
        /// 所属区县代码
        /// </summary>
        public string QXDM
        {
            set { _QXDM = value; }
            get { return _QXDM; }
        }
		#endregion Model
    }
}
