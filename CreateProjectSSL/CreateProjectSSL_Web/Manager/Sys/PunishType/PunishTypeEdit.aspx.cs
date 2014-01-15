using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;

public partial class Manager_Sys_PunishType_PunishTypeEdit : BasePage
{
    //定义对象实例化
    PunishTypeDal dal = new PunishTypeDal();
    FileClassDal fcdal = new FileClassDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drop_FileClassName.DataSource = fcdal.GetDataTable(" and sjlx=1 ");
            this.drop_FileClassName.DataTextField = "FileName";
            this.drop_FileClassName.DataValueField = "id";
            this.drop_FileClassName.DataBind();

            this.drop_FileClassName.Items.Insert(0, "请选择");
            this.drop_FileClassName.Items[0].Value = "";

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
            this.txtPunishTypeName.Text = dr["PunishTypeName"].ToStr();
            this.drop_FileClassName.SelectedValue = dr["FileClassID"].ToStr();
            if (this.GetRequestInt("flag") == 1)  //如果是查看则禁用掉所有文本框
            {
                Utility.initControl(Page, "");
                this.btnSave.Enabled = false;
                this.Reset.Enabled = false;
            }
            this.txtPunishTypeName.Enabled = false;
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
        //string txtPunishTypeName = this.GetRequestStr("txtPunishTypeName");
        string txtPunishTypeName = this.txtPunishTypeName.Text.Trim();
        if (txtPunishTypeName == "")
        {
            new MessageBox(this).Show("请输入处罚类型名称！");
            return;
        }
        string drop_FileClassName = this.drop_FileClassName.SelectedValue;

        if (drop_FileClassName=="")
        {
            new MessageBox(this).Show("请选择档案类别！");
            return;
        }

        
        int line = 0;  //定义增加受影响的行数


        if (this.GetRequestInt("id") > 0)
        {
            line = dal.Update(
                        txtPunishTypeName, this.drop_FileClassName.SelectedItem.Text, drop_FileClassName, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString(), id);
            if (line > 0)
            {
                //Alert("编辑成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("编辑成功!", "PunishTypeList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "处罚类型编辑成功", LoginUser.GetUserId,LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("编辑失败！");
            //Alert("编辑失败", true);
        }
        else
        {
            //判断是否存在数据信息
            if (dal.GetDataTable(" and PunishTypeName='" + txtPunishTypeName + "'").Rows.Count > 0)
            {
                new MessageBox(this).Show("处罚类型名称已存在！");
                return;
            }

            line = dal.Insert(
                        txtPunishTypeName, this.drop_FileClassName.SelectedItem.Text, drop_FileClassName, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString());
            if (line > 0)
            {
                //Alert("增加成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("增加成功!", "PunishTypeList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "处罚类型增加成功", LoginUser.GetUserId,LoginUser.GetUserName);
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