<%@ WebHandler Language="C#" Class="GetJson" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolsCommon;
using ToolsDal;
using System.Data;
using System.Web.SessionState;

public class GetJson : IHttpHandler,IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.Charset = "utf-8";
        HttpRequest req = context.Request;
        string method = this.GetRequestStr("method", false).ToLower();

        if (method == "filereportlist")  //addtime 2013-11-14 power by peter
        {
            string json = "";
            FileEnterDal dal = new FileEnterDal();
            int fFileName = this.GetRequestInt("fFileName");
            string EnteCountyId = context.Session["CountyId"].ToStr();
            DataTable execDt = dal.GetDataTableProc("FileReport_Count", fFileName, EnteCountyId, "FileReport_Count");
            if (execDt != null && execDt.Rows.Count > 0)
            {
                json = Utility.ToJson(execDt);
            }
            context.Response.Write(json);
            return;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}