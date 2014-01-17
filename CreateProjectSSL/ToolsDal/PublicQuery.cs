using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ToolsHelper;

namespace ToolsDal
{
    public class PublicQuery
    {
        #region 返回一个DataTable数据集合
        /// <summary>
        /// 返回一个DataTable数据集合
        /// </summary>
        /// <param name="strwhere">传递参数为id</param>
        /// <returns>返回一个DataTable</returns>
        public static DataTable GetDataQxmcTable(string strWhere)
        {
            return TSQLServer.ExecDt(" select * from [QXMCB] where csdm=420100 " + strWhere + " order by plh ");
        }
        #endregion

        #region 判断档案是否存在
        /// <summary>
        /// 判断档案是否存在
        /// </summary>
        /// <param name="strwhere">传递参数为strwhere条件</param>
        /// <returns>返回一个DataTable</returns>
        public static DataTable GetDataDNJYTable(string FilesName, string FileClassID)
        {
            return TSQLServer.ExecDt(" select * from [FileEnter] where FileClassID='" + FileClassID + "' and FilesName='" + FilesName + "' ");
        }
        #endregion

        #region 获取56个民族信息
        /// <summary>
        /// 获取56个民族信息
        /// </summary>
        /// <param name="strwhere">传递参数为id</param>
        /// <returns>返回一个DataTable</returns>
        public static DataTable GetDataMZTable()
        {
            return TSQLServer.ExecDt(" select * from [NaTion] order by mzid ");
        }
        #endregion
    }
}
