using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;

public partial class Manager_Sys_UserList_UserUpdatePwd : BasePage
{
    //定义对象实例化
    UserListDal dal = new UserListDal();
    ToolsModel.UserList model = new ToolsModel.UserList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
        }
    }

    /// <summary>
    /// 保存操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string ysmm = Security.Encode(this.GetRequestStr("txtysmm"));   //原密码
        string xmm = Security.Encode(this.GetRequestStr("txtxmm"));     //新密码
        string zsyc = Security.Encode(this.GetRequestStr("txtzsyc"));   //确认密码
        if (xmm!=zsyc)
        {
            new MessageBox(this).Show("两次密码输入不一致！");
            return;
        }
        //更新密码
        int line= dal.UpdateUserPwd(xmm, LoginUser.GetUserId);
        if (line > 0)
        {
            //Alert("编辑成功", "UserListList.aspx");
            new MessageBox(Page).ShowAndJump("密码修改成功!", "../../Manage_Center.aspx");
            //操作日志
            LogListDal.Insert(DateTime.Now, "用户密码修改成功", LoginUser.GetUserId, LoginUser.GetUserName);
        }
        else
            new MessageBox(this.Page).Show("修改密码失败！");
    }

    /// <summary>
    /// 重置操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Reset_Click(object sender, EventArgs e)
    {
        //备注信息：在Utility类中存在一个initControl方法 ，其中
        //isClear是添加时候，清空数据信息，如果type参数为空数值则默认为查看状态，控件都全部禁用掉
        Utility.initControl(Page, "isClear");
    }
}