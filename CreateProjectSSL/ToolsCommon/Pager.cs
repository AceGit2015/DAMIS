/******************************************************************************
 * 
 * Filename:  Pager.cs
 * Description: 分页操作类，页面展现风格显示
 * Author :  liangjw
 * Created Mark:  2013-10-28
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:
 * Update Description:
 * Update Mark : 
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ToolsCommon
{
    public class Pager : WebControl, IPostBackEventHandler
    {
        //总记录数
        public int RecordCount
        {
            get
            {
                if (ViewState["RecordCount"] != null)
                    return Convert.ToInt32(ViewState["RecordCount"]);
                return 0;
            }
            set
            {
                ViewState["RecordCount"] = value;
            }
        }
        //当前分页索引
        public int PageIndex
        {
            get
            {
                if (ViewState["PageIndex"] != null)
                    return Convert.ToInt32(ViewState["PageIndex"]);
                return 0;
            }
            set
            {
                ViewState["PageIndex"] = value;
            }
        }
        //分页大小
        public int PageSize
        {
            get
            {
                if (ViewState["PageSize"] != null)
                    return Convert.ToInt32(ViewState["PageSize"]);
                return 15;
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }
        #region 事件回传
        static object _PageIndexChanging = new object();

        public event EventHandler<NumericaArgs> PageIndexChanging
        {
            add
            {
                Events.AddHandler(_PageIndexChanging, value);
            }
            remove
            {
                Events.RemoveHandler(_PageIndexChanging, value);
            }
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            //控件自身的事件处理逻辑
            NumericaArgs args = new NumericaArgs(eventArgument);
            //触发用户注册的事件处理逻辑
            if (Events[_PageIndexChanging] != null)
            {
                (Events[_PageIndexChanging] as EventHandler<NumericaArgs>)(null, args);
            }
        }
        public class NumericaArgs : EventArgs
        {
            private int _newPageIndex;

            public int NewPageIndex
            {
                get
                {
                    return _newPageIndex;
                }
                set
                {
                    _newPageIndex = value;
                }
            }
            public NumericaArgs(string args)
            {
                _newPageIndex = Convert.ToInt32(args);
            }
        }
        #endregion

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            int pageCount = 0;
            if ((RecordCount % PageSize) > 0)
                pageCount = RecordCount / PageSize + 1;
            else
                pageCount = RecordCount / PageSize;
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "classdiv");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "spleft");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);


            //base.RenderContents(writer);
            //first
            string firstRef = Page.ClientScript.GetPostBackClientHyperlink(this, "0");//向上加一页

            //设置可用状态
            if (PageIndex <= 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            else
                writer.AddAttribute(HtmlTextWriterAttribute.Href, firstRef);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "Afont_12blue");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("【首页】");
            writer.RenderEndTag();
            //prev
            string prevRef = Page.ClientScript.GetPostBackClientHyperlink(this, (PageIndex - 1).ToString());//向上加一页
            if (PageIndex <= 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            else
                writer.AddAttribute(HtmlTextWriterAttribute.Href, prevRef);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "Afont_12blue");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("【上一页】");
            writer.RenderEndTag();
            //next
            string nextRef = Page.ClientScript.GetPostBackClientHyperlink(this, (PageIndex + 1).ToString());//向上加一页

            if (PageIndex >= pageCount - 1)
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            else
                writer.AddAttribute(HtmlTextWriterAttribute.Href, nextRef);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "Afont_12blue");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("【下一页】");
            writer.RenderEndTag();
            //last
            string lastRef = Page.ClientScript.GetPostBackClientHyperlink(this, (pageCount - 1).ToString());//向上加一页

            if (PageIndex >= pageCount - 1)
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            else
                writer.AddAttribute(HtmlTextWriterAttribute.Href, lastRef);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "Afont_12blue");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("【末页】");

            writer.RenderEndTag();


            writer.RenderEndTag();

            //添加dropdownlist
            DropDownList ddl = new DropDownList();
            ddl.AutoPostBack = true;
            ddl.ID = "ddlPage";
            for (int i = 0; i < pageCount; i++)
            {
                string page = (i + 1).ToString();
                ddl.Items.Add(new ListItem(page, i.ToString()));
            }
            //添加事件返回
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "DDfont_12blue");
            ddl.Attributes.Add("onchange", "javascript:__doPostBack(\'" + this.UniqueID + "\',this.value)");
            ddl.SelectedValue = PageIndex.ToString();
            ddl.RenderControl(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "SPfont_12blue");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.Write(string.Format(" 共{0}条，每页{1}条 ", RecordCount, PageSize));
            writer.Write(string.Format(" 当前{0}/{1}页 ", (PageIndex + 1), pageCount));
            // writer.Write(string.Format(" 共{0}页 ", pageCount));
            writer.RenderEndTag();
            writer.RenderEndTag();

            //共807条，每页15条，当前 1/54页
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }
    }
}
