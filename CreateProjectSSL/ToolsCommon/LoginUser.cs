using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ToolsCommon
{
    public class LoginUser : System.Web.UI.Page
    {

        /// <summary>
        /// 获取当前用户的登录名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName
        {
            get
            {
                try
                {
                    System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                    object value = ctx.Session["GetUserName"];
                    return value.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                ctx.Session["GetUserName"] = value;

            }
        }
        /// <summary>
        /// 获取当前用户的账号编码
        /// </summary>
        /// <returns></returns>
        public static int GetUserId
        {
           get
            {
                try
                {
                    System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                    object value = ctx.Session["GetUserId"];
                    return Convert.ToInt32(value);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                ctx.Session["GetUserId"] = value;
            }
        }
        /// <summary>
        /// 获取当前用户的账号的区县代码
        /// </summary>
        /// <returns></returns>
        public static string CountyId
        {
            get
            {
                try
                {
                    System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                    object value = ctx.Session["CountyId"];
                    return value.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                ctx.Session["CountyId"] = value;
            }
        }
        /// <summary>
        /// 获取当前用户的账号的所属承办单位ID
        /// </summary>
        /// <returns></returns>
        public static string OrganizerId
        {
            get
            {
                try
                {
                    System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                    object value = ctx.Session["OrganizerId"];
                    return value.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                ctx.Session["OrganizerId"] = value;
            }
        }
        /// <summary>
        /// 获取当前用户的账号的所属承办单位名称
        /// </summary>
        /// <returns></returns>
        public static string OrganizerName
        {
            get
            {
                try
                {
                    System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                    object value = ctx.Session["OrganizerName"];
                    return value.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                System.Web.HttpContext ctx = System.Web.HttpContext.Current;
                ctx.Session["OrganizerName"] = value;
            }
        }
    }
}