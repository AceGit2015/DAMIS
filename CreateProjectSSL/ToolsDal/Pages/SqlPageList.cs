/******************************************************************************
 * 
 * Filename: SqlPageList.cs
 * Description: 存储过程分页操作数据信息。
 * Author :  liangjw
 * Created Mark:   2013-11-28  
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2011-2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:   无
 * Update Description: 无
 * Update Mark : 无
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ToolsHelper;
using ToolsCommon;

namespace ToolsDal.Pages
{
    public class SqlPageList
    {
        //@tbname varchar(255),        --表名
        //@Fields varchar(1000)='*',      --返回字段
        //@OrderField varchar(255),   --排序的字段名
        //@PageSize int=15,                 --页尺寸
        //@PageCurrent int=1,                --页码
        //@OrderType bit=0,                --排序类型,1是升序,0是降序
        //@Where varchar(1500)= '',    --查询条件
        //@TotalPage int output            --返回总记录数

        public static PeterPages GetPageLists(PageInfoNew pageinfo)
        {
            SqlParameter[] Parameter = new SqlParameter[8];
            Parameter[0] = new SqlParameter();
            Parameter[0].DbType = DbType.String;
            Parameter[0].ParameterName = "@tbname";
            Parameter[0].Value = pageinfo.Tablename;
            Parameter[0].Direction = ParameterDirection.Input;

            Parameter[1] = new SqlParameter();
            Parameter[1].DbType = DbType.String;
            Parameter[1].Size = 1000;
            Parameter[1].ParameterName = "@FieldShow";
            Parameter[1].Value = pageinfo.Fields;
            Parameter[1].Direction = ParameterDirection.Input;

            Parameter[2] = new SqlParameter();
            Parameter[2].DbType = DbType.String;
            Parameter[2].Size = 1500;
            Parameter[2].ParameterName = "@Where";
            Parameter[2].Value = pageinfo.Sqlwhere;
            Parameter[2].Direction = ParameterDirection.Input;

            Parameter[3] = new SqlParameter();
            Parameter[3].DbType = DbType.Int16;
            Parameter[3].ParameterName = "@PageSize";
            Parameter[3].Value = pageinfo.PageSize;
            Parameter[3].Direction = ParameterDirection.Input;

            Parameter[4] = new SqlParameter();
            Parameter[4].DbType = DbType.Int16;
            Parameter[4].ParameterName = "@PageCurrent";
            Parameter[4].Value = pageinfo.PageIndex;
            Parameter[4].Direction = ParameterDirection.Input;

            Parameter[5] = new SqlParameter();
            Parameter[5].DbType = DbType.String;
            Parameter[5].ParameterName = "@FieldKey";
            Parameter[5].Value = pageinfo.Fieldkey;
            Parameter[5].Direction = ParameterDirection.Input;


            Parameter[6] = new SqlParameter();
            Parameter[6].DbType = DbType.String;
            Parameter[6].Size = 50;
            Parameter[6].ParameterName = "@FieldOrder";

            Parameter[6].Value = pageinfo.Orderfield;
            Parameter[6].Direction = ParameterDirection.Input;
            Parameter[7] = new SqlParameter();
            Parameter[7].DbType = DbType.Int32;
            Parameter[7].Size = 200;
            Parameter[7].ParameterName = "@RecordCount";
            Parameter[7].Direction = ParameterDirection.Output;
            Parameter[7].Value = 0;

            //存储过程sp_PageView进行分页
            DataSet ds = TSQLServer.RunProcedure("sp_PageView", Parameter, "pages");


            Int32 recordcount = (Int32)Parameter[7].Value;
            PeterPages pages = new PeterPages(pageinfo.PageSize, pageinfo.PageIndex, recordcount, ds);
            return pages;
        }

    }
}
