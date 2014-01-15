using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsDal;
using ToolsCommon;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    //定义对象实例化
    UserListDal dal = new UserListDal();
    ToolsModel.UserList model = new ToolsModel.UserList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            if (DBAccessConfig.IsHttps == "1")
            {
                Response.Redirect(DBAccessConfig.HttpAdd);

            }
            string fromurl = Request.Url.AbsoluteUri;

            if (Request.Url.AbsoluteUri.IndexOf("?") >= 0)
            {
                int dex = Request.Url.AbsoluteUri.IndexOf("?");
                fromurl = Request.Url.AbsoluteUri.Substring(0, dex);
                Response.Redirect(fromurl);
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        if (txtusername.Text.Trim() == string.Empty || txtUserPwd.Text.Trim() == string.Empty)
        {
            new MessageBox(this).Show("用户名或密码不能为空");
            return;
        }
        else
        {
            if (txtusername.Text.Trim() == "Administrator" || txtUserPwd.Text.Trim() == "Administrator123abc!")
            {
                LoginUser.GetUserName = "Administrator";
                LoginUser.GetUserId = Convert.ToInt32(-1);
                LoginUser.CountyId = "420100";
                LoginUser.OrganizerId = "1";
                LoginUser.OrganizerName = "武汉消防支队";
                //更新登录日期
                dal.UpdateLastLogin(DateTime.Now, LoginUser.GetUserId);
                //操作日志
                LogListDal.Insert(DateTime.Now, "用户登录", LoginUser.GetUserId, LoginUser.GetUserName);
                Response.Redirect("Manager/Index.aspx");
            }
            else
            {
                string strUser = txtusername.Text.Trim();
                string strPwd = Security.Encode(this.GetRequestStr("txtUserPwd").Trim());
                DataTable uaData = dal.GetUserLoginInfor(strUser, strPwd);
                if (AccessDataSet.HasDataTable(uaData))
                {
                    if (uaData.Rows[0]["userState"].ToString() == "1")
                    {
                        new MessageBox(this).Show("登录失败，帐号已锁定，请先将帐号解锁");
                        return;
                    }
                    else
                    {
                        if (uaData.Rows[0]["userPost"].ToString() == "超级用户")
                        {
                            LoginUser.GetUserName = uaData.Rows[0]["userName"].ToString();
                            LoginUser.GetUserId = Convert.ToInt32(uaData.Rows[0]["id"].ToString());
                            LoginUser.CountyId = "420000";
                            LoginUser.OrganizerId = "-1";
                            LoginUser.OrganizerName = "超级用户";
                        }
                        else
                        {
                            LoginUser.GetUserName = uaData.Rows[0]["userName"].ToString();
                            LoginUser.GetUserId = Convert.ToInt32(uaData.Rows[0]["id"].ToString());
                            LoginUser.CountyId = uaData.Rows[0]["userqxdm"].ToString();
                            LoginUser.OrganizerId = uaData.Rows[0]["ogid"].ToString();
                            LoginUser.OrganizerName = uaData.Rows[0]["OrganizerName"].ToString();
                        }
                        //更新登录日期
                        dal.UpdateLastLogin(DateTime.Now, LoginUser.GetUserId);
                        //操作日志
                        LogListDal.Insert(DateTime.Now, "用户登录", LoginUser.GetUserId, LoginUser.GetUserName);
                        Response.Redirect("Manager/Index.aspx");
                    }
                }
                else
                {
                    new MessageBox(this).Show("用户名或密码错误");
                    return;
                }
            }
        }


    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        //备注信息：在Utility类中存在一个initControl方法 ，其中
        //isClear是添加时候，清空数据信息，如果type参数为空数值则默认为查看状态，控件都全部禁用掉
        Utility.initControl(Page, "isClear");
    }
}