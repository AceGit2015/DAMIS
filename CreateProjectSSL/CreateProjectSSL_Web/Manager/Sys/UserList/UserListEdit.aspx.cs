using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;

public partial class Manager_Sys_UserList_UserListEdit : BasePage
{
    //定义对象实例化
    UserListDal dal = new UserListDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QXMCQQ();
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
            this.txtuserName.Text = dr["userName"].ToStr();          //用户名
            this.txtuserRealName.Text = dr["userRealName"].ToStr();  //真实姓名
            this.txtuserTel.Text = dr["userTel"].ToStr();            //电话
            this.txtpassWord.Attributes.Add("value", Security.Decode(dr["passWord"].ToStr()));  //密码
            if (dr["userState"].ToInt32() == 0)                      //状态
            {
                this.txtuserState.Items[0].Selected = true;
            }
            else
            {
                this.txtuserState.Items[1].Selected = true;
            }
            this.txtuserMail.Text = dr["userMail"].ToStr();          //邮箱
            this.txtuserPost.SelectedValue = dr["userPost"].ToStr(); //组织机构
            if (dr["userPost"].ToStr() == "支队")
            {
                QXMCQQ();
            }
            else
            {
                QXMC();
            }

            this.drop_qxdm.SelectedValue = dr["userqxdm"].ToStr();  //区县代码
            this.txtuserName.Enabled = false;
            if (this.GetRequestInt("flag") == 1)  //如果是查看则禁用掉所有文本框
                Utility.initControl(Page, "");

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
        string userName = this.txtuserName.Text.Trim(); //this.GetRequestStr("txtuserName");
        string passWord = Security.Encode(this.GetRequestStr("txtpassWord").Trim());
        string userRealName = this.GetRequestStr("txtuserRealName");
        string userTel = this.GetRequestStr("txtuserTel");
        int userState = this.GetRequestInt("txtuserState");
        string userMail = this.GetRequestStr("txtuserMail");
        string userPost = this.txtuserPost.SelectedValue;
        string userqxdm = this.drop_qxdm.SelectedValue;
        if (userqxdm=="")
        {
            new MessageBox(this).Show("请选择所属支队或大队！");
            return;
        }
        DateTime userLastLogin = DateTime.Now;
        int line = 0;  //定义增加受影响的行数


        //判断是否存在数据信息
        if (this.GetRequestInt("id") > 0)
        {
            line = dal.Update(
                        userName,
                        passWord,
                        userRealName,
                        userTel,
                        userState,
                        userMail,
                        userLastLogin,
                        userPost, userqxdm, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString(), id);
            if (line > 0)
            {
                //Alert("编辑成功", "UserListList.aspx");
                new MessageBox(Page).ShowAndJump("编辑成功!", "UserListList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "用户编辑成功", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("编辑失败！");
            //Alert("编辑失败", true);
        }
        else
        {
            line = dal.Insert(
                        userName,
                        passWord,
                        userRealName,
                        userTel,
                        userState,
                        userMail,
                        userLastLogin,
                        userPost,
                        userqxdm, LoginUser.GetUserId, LoginUser.GetUserName, DateTime.Now.ToString());
            if (line > 0)
            {
                //Alert("增加成功", "UserListList.aspx");
                new MessageBox(Page).ShowAndJump("增加成功!", "UserListList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "用户增加成功", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
                //Alert("增加失败", true);
                new MessageBox(this.Page).Show("增加失败！");
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


    private void QXMC()
    {
        this.drop_qxdm.Items.Clear();
        this.drop_qxdm.DataSource = PublicQuery.GetDataQxmcTable(" and qxmc<>'武汉支队'");
        this.drop_qxdm.DataTextField = "ZZJG";
        this.drop_qxdm.DataValueField = "QXDM";
        this.drop_qxdm.DataBind();
        this.drop_qxdm.Items.Insert(0, "请选择支队");
        this.drop_qxdm.Items[0].Value = "";
    }

    private void QXMCQQ()
    {
        this.drop_qxdm.Items.Clear();
        this.drop_qxdm.Items.Insert(0, "请选择支队");
        this.drop_qxdm.Items[0].Value = "";
        this.drop_qxdm.Items.Insert(1, "武汉消防支队");
        this.drop_qxdm.Items[1].Value = "420100";
    }

    protected void txtuserPost_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.txtuserPost.SelectedValue == "支队")
        {
            QXMCQQ();
        }
        else if (this.txtuserPost.SelectedValue == "超级用户")
        {
            QXMCQQ();
            //this.drop_qxdm.Items.Clear();
            //this.drop_qxdm.Items.Insert(1, "武汉消防支队");
            //this.drop_qxdm.Items[1].Value = "420100";
            ////this.drop_qxdm.DataSource = PublicQuery.GetDataQxmcTable("");
            ////this.drop_qxdm.DataTextField = "ZZJG";
            ////this.drop_qxdm.DataValueField = "QXDM";
            ////this.drop_qxdm.DataBind();
            //this.drop_qxdm.Items.Insert(0, "-请选择-");
            //this.drop_qxdm.Items[0].Value = "";
        }
        else
        {
            QXMC();
        }
    }
}