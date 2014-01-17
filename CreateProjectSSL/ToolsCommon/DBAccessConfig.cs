/****************************************************************
 * 类名：DBAccessConfig(数据库访问配置类)
 * 日期：2008.05.20
 ****************************************************************/

using System;
using System.Configuration;

namespace ToolsCommon
{
    public class DBAccessConfig
    {

        /// <summary>
        /// 加密字符串KEY
        /// </summary>
        public static readonly string CodeKey = System.Configuration.ConfigurationManager.AppSettings["CodeKey"].ToString();
        /// <summary>
        /// 应用系统名称
        /// </summary>
        public static readonly string AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"].ToString();
        /// <summary>
        /// 数据库连接串名
        /// </summary>
        public static readonly string ConnectionStringLocalTransaction = "DBConnectionString";
        /// <summary>
        /// 列表分页大小
        /// </summary>
        public static readonly string DefaultPageSize = System.Configuration.ConfigurationManager.AppSettings["DefaultPageSize"].ToString();


        /// <summary>
        /// 是否https
        /// </summary>
        public static readonly string IsHttps = System.Configuration.ConfigurationManager.AppSettings["IsHttps"].ToString();


        /// <summary>
        /// https地址
        /// </summary>
        public static readonly string HttpsAdd = System.Configuration.ConfigurationManager.AppSettings["HttpsAdd"].ToString();

        /// <summary>
        /// http地址
        /// </summary>
        public static readonly string HttpAdd = System.Configuration.ConfigurationManager.AppSettings["HttpAdd"].ToString();



    }
}
