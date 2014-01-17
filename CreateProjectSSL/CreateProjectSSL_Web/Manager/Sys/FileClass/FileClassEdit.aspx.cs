using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;


public partial class Manager_Sys_FileClass_FileClassEdit : BasePage
{
    //定义对象实例化
    FileClassDal dal = new FileClassDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDaSource();
        }
    }

    //绑定案卷名称
    private void BindDaSource()
    {
        this.drop_parentFileName.DataSource = dal.GetDataTable(" and parentFileID=0 ");
        this.drop_parentFileName.DataTextField = "FileName";
        this.drop_parentFileName.DataValueField = "id";
        this.drop_parentFileName.DataBind();
        this.drop_parentFileName.Items.Insert(0, new ListItem("顶节点", ""));
        //大于0为编辑否则为增加
        if (this.GetRequestInt("id") > 0)
            this.GetValue();
    }
    //取值
    public void GetValue()
    {
        DataRow dr = dal.GetRow(this.GetRequestInt("id")); //获取传递的参数，编辑时ID主键
        if (dr != null)
        {
            this.txtFileName.Text = dr["FileName"].ToStr();  //案卷类别名称
            this.txtFileCode.Text = dr["FileCode"].ToStr();  //案卷类别代码
            this.drop_parentFileName.SelectedValue = dr["parentFileID"].ToStr();

            if (this.GetRequestInt("flag") == 1)  //如果是查看则禁用掉所有文本框
                Utility.initControl(Page, "");
            this.txtFileName.Enabled = false;
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
        string txtFileName = this.txtFileName.Text.Trim(); //卷宗类别名称
        if (txtFileName=="")
        {
            new MessageBox(this).Show("请输入卷宗类别名称!");
            return;
        }
        string txtFileCode = this.GetRequestStr("txtFileCode").Trim();  //卷宗类别代号
        if (txtFileCode == "")
        {
            new MessageBox(this).Show("请输入卷宗类别代号!");
            return;
        }
        string txtparentFileName = this.drop_parentFileName.SelectedValue; 
        if (txtparentFileName!="")
        {
            if (Utility.IndexOfstr(this.txtFileCode.Text.Trim(),this.HiddenField1.Value)!=true)
            {
                new MessageBox(this).Show("该卷宗类别代号必须以"+this.HiddenField1.Value+"开头!");
                return;
            }
        }
        else
        {
            txtparentFileName = "0";
        }
        int line = 0;  //定义增加受影响的行数


        if (this.GetRequestInt("id") > 0)   //如果案卷类别编号存在则Update
        {
            line = dal.Update(
                        txtFileName,
                        txtFileCode,
                        txtparentFileName, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString(), id);
            if (line > 0)
            {
                //Alert("编辑成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("编辑成功!", "FileClassList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "卷宗类别编辑成功", LoginUser.GetUserId,LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("编辑失败！");
                //Alert("编辑失败", true);
        }
        else   //如果案卷类别编号不存在则Insert
        {
            //判断是否存在数据信息
            if (dal.GetDataTable(" and FileCode='" + this.txtFileCode.Text.Trim() + "'").Rows.Count > 0)
            {
                new MessageBox(this).Show("卷宗类别代号已存在！");
                return;
            }
            if (dal.GetDataTable(" and FileName='" + txtFileName + "'").Rows.Count > 0)
            {
                new MessageBox(this).Show("卷宗类别已存在！");
                return;
            }
            line = dal.Insert(
                        txtFileName,
                        txtFileCode,
                        txtparentFileName, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString());
            if (line > 0)
            {
                //Alert("增加成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("增加成功!", "FileClassList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "卷宗类别增加成功", LoginUser.GetUserId,LoginUser.GetUserName);
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

    protected void drop_parentFileName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drop_parentFileName.SelectedValue!="")
        {
            DataTable dt = dal.GetDataTable(" and FileName='" + this.drop_parentFileName.SelectedItem.Text + "'");
            if (dt.Rows.Count > 0)
            {
                this.txtFileCode.Text = dt.Rows[0]["FileCode"].ToString() + ".";
                this.HiddenField1.Value = dt.Rows[0]["FileCode"].ToString() + ".";
            }
        }
    }
}