/******************************************************************************
 * 
 * Filename:  BasePage.cs
 * Description: 弹出提示信息封装
 * Author :  liangjw
 * Created Mark:  2013-10-29
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:   liangjw
 * Update Description: 增加了 只加密,不解密，密码安全性操作
 * Update Mark : getSHA1()一般在用户注册安全性要求不能进行破解，只加密操作。
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace ToolsCommon
{
    public class BasePage : BaseBasePage
    {

        #region 加载事件函数
        /// <summary>
        /// 加载事件函数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetActorInfos();
                base.OnLoad(e);
            }
        }
        #endregion

        protected void GetActorInfos()
        {
            if (LoginUser.GetUserId == 0)
            {
                ToErrDefault();
                return;
            }
            //DataTable dt = TOracleServer.ExecDt("select  a.yyxtjsbh,a.ssyyxtbh,a.ztxxbh,b.ztyhlx from YHZHYYGLB a left join XTZTJCXXMLB b on a.ztxxbh = b.ztxxbh where a.yhzhbm ='" + LoginUser.GetUaId + "' and ssyyxtbh =1");
            //if (!AccessDataSet.HasDataTable(dt))
            //{

            //}
            //else
            //{
            //    DataRow row = dt.Rows[0];

            //    ViewState["_userTypeKey"] = int.Parse(row["ztyhlx"].ToString());
            //    ViewState["_actorId"] = int.Parse(row["ztxxbh"].ToString());
            //    ViewState["_appRoleId"] = int.Parse(row["yyxtjsbh"].ToString());
            //}

        }

        #region Alert
        /// <summary>
        /// 返回js提示
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        public void Alert(string msg)
        {
            string js = "<script type=\"text/javascript\">alert(\"{0}\");</script>";
            Content(string.Format(js, msg));
        }

        private void Content(string p)
        {
            Response.Write(p);
            return;
        }
        #endregion

        #region Alert Back
        /// <summary>
        /// 返回js提示 可返回上一页
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="back">是否返回上一页</param>
        /// <returns></returns>

        public void Alert(string msg, bool back)
        {
            if (!back)
            {
                Alert(msg);
            }
            string js = "<script type=\"text/javascript\">alert(\"{0}\"); history.back();</script>";
            Content(string.Format(js, msg));

        }
        #endregion

        #region Alert Go
        /// <summary>
        /// 返回js提示 并转到URL
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url">转到的URL</param>
        /// <returns></returns>

        public void Alert(string msg, string url)
        {
            if (string.IsNullOrEmpty(url)) { Alert(msg); return; }

            string js = "<script type=\"text/javascript\">alert(\"{0}\"); location.href='{1}';</script>";
            Content(string.Format(js, msg, url));
            return;
        }
        #endregion


    }
}
