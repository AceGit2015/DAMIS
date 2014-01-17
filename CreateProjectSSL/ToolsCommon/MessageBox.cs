/******************************************************************************
 * 
 * 文件名:  MessageBox.cs
 * 文件功能描述:  弹出提示框
 * 作    者:  wanyoujun
 * 创建标示:  2013-06-02
 * 邮    箱： wanyoujun8@163.com
 * 版权所有： Copyright (C) 【2013 wanyoujun】
 * 版本号:    V1.0
 * 备    注: 无
 * 修改者:   无
 * 修改描述: 无
 * 修改标示: 无
 * 
*******************************************************************************/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// MessageBox 的摘要说明
/// </summary>
public class MessageBox
{
    private Control _fromctrl;
    private Page _fromPage;

    public MessageBox(Page frompage)
    {
        _fromPage = frompage;
    }

    public MessageBox(UserControl fromctrl)
    {
        _fromctrl = fromctrl;
    }

    public void Show(string messagetext)
    {


        string LableId;
        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = String.Format("<script language=javascript>window.alert('{0}');</script>", messagetext);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }


    public void Jump(string newurl)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = String.Format("<script language=javascript>window.location.href='{0}';</script>", newurl);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
        //_fromctrl.Page.Controls.Add(lable1);
    }

    public void ShowAndJump(string messagetext, string newrul)
    {
        Show(messagetext);
        Jump(newrul);
    }

    public void JumpParent(string newurl)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = String.Format("<script language=javascript>window.parent.location.href='{0}';</script>", newurl);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }

    public void ShowAndJumpParent(string messagetext, string newrul)
    {
        Show(messagetext);
        JumpParent(newrul);
    }

    public void ShowAndClose(string messagetext)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        //lable1.Text = String.Format("<script language=javascript>window.alert('{0}');self.location='QuarterArea.aspx?sbid=264510';</script>", messagetext);
        lable1.Text = String.Format("<script language=javascript>window.alert('{0}');history.go(-2);</script>", messagetext);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }

    public void ShowAndBackTo_Url(string messagetext, string url)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = String.Format("<script language=javascript>window.alert('{0}');self.location='" + url + "';</script>", messagetext);
        //lable1.Text = String.Format("<script language=javascript>window.alert('{0}');history.go(-2);</script>", messagetext);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }

    public void RefreshPageInFrame(string pagename, string navigateurl)
    {

        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = string.Format("<script language=javascript>self.parent.{0}.location='{1}';</script>", pagename, navigateurl);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }

    public void JumpToTop(string newurl)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = string.Format("<script language=javascript>if (self.location!= top.location)  top.location='{0}';</script>", newurl);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }

    /// <summary>
    /// 打开临时对话窗口，背景页面不能操作
    /// </summary>
    /// <param name="newurl"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void OpenChooseWindow(string newurl, int width, int height)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "win" + LableId;
        lable1.Text = string.Format("<script type='text/javascript'>window.showModalDialog('{0}',window,'dialogwidth:{1}px;dialogheight:{2}px;help:0;center:yes;resizable:0;status:0;scroll:yes');</script>", newurl, width, height);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }

        //_fromPage.Response.Write(string.Format("<script type='text/javascript'>window.showModalDialog('{0}',window,'dialogwidth:450px;dialogheight:480px;help:0;center:yes;resizable:0;status:0;scroll:yes');</script>", newurl));


    }

    #region 模式对话框处理
    /// <summary>
    /// 打开模式对话窗口，背景页面不能操作
    /// </summary>
    /// <param name="newurl"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void OpenModalDialog(string newurl, int width, int height, string windowId)
    {
        string LableId;
        string JsScript;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "win" + LableId;
        JsScript = string.Format("<script type='text/javascript'>var returnstr = window.showModalDialog('{0}',window,'dialogwidth:{1}px;dialogheight:{2}px;help:0;center:yes;resizable:0;status:0;scroll:yes');</script>", newurl, width, height);
        JsScript += string.Format("<script type='text/javascript'>document.getElementById('{0}').value=returnstr;__doPostBack('{0}','{1}');</script>", "hidden_ModalDialogReturnValue", windowId);

        lable1.Text = JsScript;

        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }

        //_fromPage.Response.Write(string.Format("<script type='text/javascript'>window.showModalDialog('{0}',window,'dialogwidth:450px;dialogheight:480px;help:0;center:yes;resizable:0;status:0;scroll:yes');</script>", newurl));
    }

    /// <summary>
    /// 无返回值关闭模式对话窗口，背景页面不能操作
    /// </summary>
    public void CloseModalDialog()
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "win" + LableId;
        lable1.Text = "<script type='text/javascript'>window.close();</script>";
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }

        //_fromPage.Response.Write(string.Format("<script type='text/javascript'>window.showModalDialog('{0}',window,'dialogwidth:450px;dialogheight:480px;help:0;center:yes;resizable:0;status:0;scroll:yes');</script>", newurl));


    }

    /// <summary>
    /// 有返回值关闭模式对话窗口，背景页面不能操作
    /// </summary>
    public void CloseModalDialog(string returnValue)
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "win" + LableId;

        lable1.Text = string.Format("<script type='text/javascript'>window.returnValue = '{0}';window.close();</script>", returnValue);
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }
    #endregion

    public void AddScript(string Scripttext)
    {

        string LableId;
        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = "<script language=javascript>" + Scripttext + "</script>";
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }

    public void ShowAndJumpTop(string messagetext)
    {
        Show(messagetext);
        JumpToTopKeepSourceUrl();
    }
    public void JumpToTopKeepSourceUrl()
    {
        string LableId;

        LableId = Guid.NewGuid().ToString("N");

        Label lable1 = new Label();
        lable1.ID = "msg" + LableId;
        lable1.Text = string.Format("<script language=javascript> top.location = top.location;</script>");
        lable1.Visible = true;
        if (_fromctrl == null)
        {
            _fromPage.Controls.Add(lable1);
        }
        else
        {
            _fromctrl.Page.Controls.Add(lable1);
        }
    }
}
