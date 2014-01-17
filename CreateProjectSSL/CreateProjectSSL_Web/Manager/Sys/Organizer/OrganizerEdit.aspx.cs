using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;

public partial class Manager_Sys_Organizer_OrganizerEdit : BasePage
{
    //定义对象实例化
    OrganizerDal dal = new OrganizerDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //大于0为编辑否则为增加
            if (this.GetRequestInt("id") > 0)
                this.GetValue();

        }
    }

    //取值
    public void GetValue()
    {
        DataRow dr = dal.GetRow(this.GetRequestInt("id")); //获取传递的参数，编辑时ID主键
        if (dr != null)
        {
            this.txtOrganizerName.Text = dr["OrganizerName"].ToStr();

            if (this.GetRequestInt("flag") == 1)  //如果是查看则禁用掉所有文本框
            {
                Utility.initControl(Page, "");
                this.btnSave.Enabled = false;
                this.Reset.Enabled = false;
            }
            this.txtOrganizerName.Enabled = false;
        }

    }

    /// <summary>
    /// 保存操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //获取界面数值赋值给model对象
        int id = this.GetRequestInt("id");
        string txtOrganizerName = this.txtOrganizerName.Text.Trim();// this.GetRequestStr("txtOrganizerName");
        if (txtOrganizerName == "")
        {
            new MessageBox(this).Show("请输入承办单位名称！");
            return;
        }
        int line = 0;  //定义增加受影响的行数


        if (this.GetRequestInt("id") > 0)
        {
            line = dal.Update(
                        txtOrganizerName, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString(), id);
            if (line > 0)
            {
                //Alert("编辑成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("编辑成功!", "OrganizerList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "承办单位编辑成功", LoginUser.GetUserId,LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("编辑失败！");
            //Alert("编辑失败", true);
        }
        else
        {
            //判断是否存在数据信息
            if (dal.GetDataTable(" and OrganizerName='" + txtOrganizerName + "'").Rows.Count > 0)
            {
                new MessageBox(this).Show("承办单位名称已存在！");
                return;
            }
            line = dal.Insert(
                        txtOrganizerName, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString());
            if (line > 0)
            {
                //Alert("增加成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("增加成功!", "OrganizerList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "承办单位增加成功", LoginUser.GetUserId,LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("增加失败！");
            //Alert("增加失败", true);
        }
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