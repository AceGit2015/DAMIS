using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ToolsCommon
{
    /// <summary>
    /// BaseBasePage 的摘要说明
    /// </summary>
    public class BaseBasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 获取网站根目录
        /// </summary>
        public string RootUrl
        {
            get
            {
                return HttpContext.Current.Request.ApplicationPath;
            }
        }

        /// <summary>
        /// 跳转到报错页面
        /// </summary>
        public void ToErrDefault()
        {
            Response.Redirect("~/Login.aspx");
            //Response.Redirect("<script>parent.location.href='Login.aspx');</script>");
            //Response.Write("<script language=javascript>javascript:location.href='../../Login.aspx'</script>");
        }
    }

}
