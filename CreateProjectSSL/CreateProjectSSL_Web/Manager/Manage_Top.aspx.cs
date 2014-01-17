using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ToolsCommon;

public partial class Manager_Manage_Top : BasePage
{
    public string UserName = "";
    public string EnforcementName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["GetUserName"] == null)
                Response.Write("<script>window.parent.location.href='../Login.aspx';</script>");
            else
            {
                UserName = LoginUser.GetUserName;
                EnforcementName = LoginUser.OrganizerName;
            }

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Response.Write("<script>window.parent.location.href='../Login.aspx';</script>");
    }
}