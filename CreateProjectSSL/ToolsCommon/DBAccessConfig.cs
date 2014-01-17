/****************************************************************
 * ������DBAccessConfig(���ݿ����������)
 * ���ڣ�2008.05.20
 ****************************************************************/

using System;
using System.Configuration;

namespace ToolsCommon
{
    public class DBAccessConfig
    {

        /// <summary>
        /// �����ַ���KEY
        /// </summary>
        public static readonly string CodeKey = System.Configuration.ConfigurationManager.AppSettings["CodeKey"].ToString();
        /// <summary>
        /// Ӧ��ϵͳ����
        /// </summary>
        public static readonly string AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"].ToString();
        /// <summary>
        /// ���ݿ����Ӵ���
        /// </summary>
        public static readonly string ConnectionStringLocalTransaction = "DBConnectionString";
        /// <summary>
        /// �б��ҳ��С
        /// </summary>
        public static readonly string DefaultPageSize = System.Configuration.ConfigurationManager.AppSettings["DefaultPageSize"].ToString();


        /// <summary>
        /// �Ƿ�https
        /// </summary>
        public static readonly string IsHttps = System.Configuration.ConfigurationManager.AppSettings["IsHttps"].ToString();


        /// <summary>
        /// https��ַ
        /// </summary>
        public static readonly string HttpsAdd = System.Configuration.ConfigurationManager.AppSettings["HttpsAdd"].ToString();

        /// <summary>
        /// http��ַ
        /// </summary>
        public static readonly string HttpAdd = System.Configuration.ConfigurationManager.AppSettings["HttpAdd"].ToString();



    }
}
