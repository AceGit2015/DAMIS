/******************************************************************************
 * 
 * Filename:  Utility.cs
 * Description:  通用类的方法封装，包含字符串处理，获取form表单的数值[包含获取string ,int,double]
 * 以及包含数据库sql语句中特殊字符串的处理，全角和半角的转换方法,遍历界面上所有控件进行属性设置
 * 常用数据验证的封装，数字字符的验证,去除字符串中的空格,Json 字符串 和 DataTable数据集合之间的
 * Author :  liangjw
 * Created Mark:  2012-08-21
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2012 Create Family Wealth Power By Peter All Rights Reserved
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
using System.Web;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Script.Serialization;
using ToolsHelper;
using System.Data.OleDb;
using System.Net;
using System.IO;
using System.Web.Services;
using System.Net.Sockets;
using System.Runtime.InteropServices;
namespace ToolsCommon
{

    public static class Utility
    {
        #region 字符串处理
        #endregion

        #region 获取页面表单的字符串数值
        /// <summary>
        /// 字符串处理
        /// </summary>
        /// <param name="leval"></param>
        /// <returns></returns>
        public static string GetStr(string leval)
        {
            string result = "";
            for (int i = 0; i < leval.ToInt32() * 4; i++)
            {
                result += "-";
            }
            return result;
        }
        /// <summary>
        /// 获取页面表单的字符串数值
        /// </summary>
        /// <param name="c"></param>
        /// <param name="key"></param>
        /// <param name="filterSQL"></param>
        /// <returns></returns>
        public static string GetRequestStr(this object c, string key, bool filterSQL = true)
        {
            string textValue = HttpContext.Current.Request[key].ToStr("");
            if (filterSQL && textValue.Trim() != "")
            {
                textValue = textValue.filterSQL(); //进行字符串的验证，判断是否包含特使字符或关键字，如果包含则进行特殊字符处理
            }
            return textValue;
        }
        #endregion

        #region 获取案卷类别树结构
        /// <summary>
        /// 获取案卷类别树结构
        /// </summary>
        /// <returns>返回一个DataTable数据集</returns>
        public static DataTable GetFileClassStruct()
        {
            return TSQLServer.ExecDt(@"
                    with T as
                    (SELECT *, lv=0, struct = CAST(id as nvarchar) from FileClass  where parentFileID  = 0
                        union all select a.*,lv=(b.lv + 1), struct =CAST(CAST(b.struct as nvarchar) + ',' + CAST(a.id as nvarchar) as nvarchar)
                        from FileClass a join T b on a.parentFileID = b.id
                    )
                    select * from T
                    OPTION(MAXRECURSION 0)
");
        }

        public static DataTable GetFileClassTree()
        {
            DataTable dt = GetFileClassStruct();
            DataTable tmp = dt.Clone();
            GetFileClassFromDataTable(dt, 0, ref tmp);
            return tmp;
        }

        static void GetFileClassFromDataTable(DataTable dt, int id, ref DataTable tmp)
        {
            DataTable dt1 = dt.Where("parentFileID=" + id);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                tmp.Rows.Add(dt1.Rows[i].ItemArray);
                GetFileClassFromDataTable(dt, dt1.Rows[i]["id"].ToInt32(), ref tmp);
            }
        }
        #endregion

        #region 获取页面表单的整数数值
        /// <summary>
        /// 获取页面表单的整数数值
        /// </summary>
        /// <param name="c"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetRequestInt(this object c, string key)
        {
            int intValue = HttpContext.Current.Request[key].ToStr("").Split(new char[] { ',' })[0].ToInt32(0);
            return intValue;
        }
        #endregion

        #region 获取form表单的Double数值
        /// <summary>
        /// 获取form表单的Double数值
        /// </summary>
        /// <param name="c"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static double GetRequestDouble(this object c, string key)
        {
            double doubleValue = HttpContext.Current.Request[key].ToStr("").Split(new char[] { ',' })[0].ToDouble(-1, 0.0);
            return doubleValue;
        }
        #endregion

        #region sql语句中,字符串中的关键字处理
        /// <summary>
        /// 
        /// sql语句中的关键字处理
        /// </summary>
        /// <param name="sql">参数sql语句</param>
        /// <returns></returns>
        public static string filterSQL(this string sqlStr)
        {
            //特殊关键字字符
            string strChar = "(and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join|cmd|union|javascript|'|\"|<|>)";
            Regex regex = new Regex(strChar, RegexOptions.IgnoreCase); //实例化正则字符，不区分大小写
            sqlStr = regex.Replace(sqlStr, (Match m) => m.Value.ToSBC()); //半角转全角
            return sqlStr;
        }
        #endregion

        #region 全角转换半角以及半角转换为全角
        /// 转全角的函数(SBC case)
        ///
        ///任意字符串
        ///全角字符串
        ///
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///
        public static string ToSBC(this string input)
        {
            // 半角转全角：
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 32)
                {
                    array[i] = (char)12288;
                    continue;
                }
                if (array[i] < 127)
                {
                    array[i] = (char)(array[i] + 65248);
                }
            }
            return new string(array);
        }

        /**/
        // /
        // / 转半角的函数(DBC case)
        // /
        // /任意字符串
        // /半角字符串
        // /
        // /全角空格为12288，半角空格为32
        // /其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        // /
        public static string ToDBC(this string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 12288)
                {
                    array[i] = (char)32;
                    continue;
                }
                if (array[i] > 65280 && array[i] < 65375)
                {
                    array[i] = (char)(array[i] - 65248);
                }
            }
            return new string(array);
        }


        #endregion

        #region  获取表单数据转换为[Int 类型，string 类型 以及Double类型]的方法封装
        /// <summary>
        /// 转换为int32整型类型
        /// </summary>
        /// <param name="s">获取需要转换的值</param>
        /// <param name="defaultValue">默认参数值为0</param>
        /// <returns>转换失败为0，成功为result</returns>
        public static int ToInt32(this object s, int defaultValue = 0)
        {
            int result = defaultValue;
            try
            {
                result = Convert.ToInt32(s.ToStrTrim());  //转换为Int类型，去除空格
            }
            catch
            {
            }
            return result;
        }
        /// <summary>
        ///  转换为string字符串类型
        /// </summary>
        /// <param name="s">获取需要转换的值</param>
        /// <param name="format">需要格式化的位数</param>
        /// <returns>返回一个新的字符串</returns>
        public static string ToStr(this object s, string format = "")
        {
            string result = "";
            try
            {
                if (format == "")
                {
                    result = s.ToString();
                }
                else
                {
                    result = string.Format("{0:" + format + "}", s);
                }
            }
            catch
            {
            }
            return result;
        }
        /// <summary>
        /// 转换为Double类型
        /// </summary>
        /// <param name="s">获取需要转换的值</param>
        /// <param name="x"></param>
        /// <param name="defaultValue">默认参数值为0.0<</param>
        /// <returns>返回一个新的double数据</returns>
        public static double ToDouble(this object s, int x = -1, double defaultValue = 0.0)
        {
            double result = defaultValue;
            try
            {
                if (x == -1)
                {
                    result = Convert.ToDouble(s.ToStrTrim());
                }
                else
                {
                    result = Convert.ToDouble(string.Format("{0:F" + x.ToString() + "}", Convert.ToDouble(s.ToStrTrim())));
                }
            }
            catch
            {
            }
            return result;
        }

        public static decimal ToDecimal(this object s, int x = -1, decimal defaultValue = 0m)
        {
            decimal result = defaultValue;
            try
            {
                if (x == -1)
                {
                    result = Convert.ToDecimal(s.ToStrTrim());
                }
                else
                {
                    result = Convert.ToDecimal(string.Format("{0:F" + x.ToString() + "}", Convert.ToDecimal(s.ToStrTrim())));
                }
            }
            catch
            {
            }
            return result;
        }

        #endregion

        #region 去除字符串中的空格
        /// <summary>
        /// 去除字符串中的空格
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToStrTrim(this object s)
        {
            string result = "";
            try
            {
                result = s.ToString().Trim();
            }
            catch
            {
            }
            return result;
        }
        public static string ToStrTrim(this object s, params char[] x)
        {
            string result = "";
            try
            {
                result = s.ToString().Trim(x);
            }
            catch
            {
            }
            return result;
        }
        #endregion

        #region 常用数据验证的封装，数字字符的验证
        /// <summary>
        /// 常用数据验证的封装，数字字符的验证
        /// </summary>
        /// <param name="inputVal">需要验证的数值【字符串，或者数字】</param>
        /// <param name="type">类型为哪一个验证</param>
        /// <returns>如果验证成功则返回True,否则返回false</returns>
        public static bool IsMatch(string inputVal, int type)
        {
            switch (type)
            {
                case 0:
                    return Regex.IsMatch(inputVal, @"^[1-9]d*$");  //匹配正整数
               
                default:
                    return true;
            }
        }
        #endregion

        #region 遍历界面上所有控件进行属性设置
        /// <summary>
        /// 遍历界面上所有控件进行属性设置
        /// </summary>
        /// <param name="page"></param>
        /// <param name="type">
        ///isClear是添加时候，清空数据信息，如果该控件为只读属性则不需要清除文本数据信息，
        ///如果type参数为空数值则默认为查看状态，控件都全部禁用掉
        /// </param>
        public static void initControl(Control page, string type)
        {
            int nPageControls = page.Controls.Count;  //获取页面的控件
            for (int i = 0; i < nPageControls; i++)
            {
                foreach (Control control in page.Controls[i].Controls)
                {
                    {
                        //文本框控件
                        if (control is TextBox)
                        {
                            TextBox txtBox = (TextBox)control;
                            //如果是点击重置，需要判断是否为只读属性，如果是则不进行清除数据
                            if (type == "isClear" && txtBox.Enabled != false)
                                txtBox.Text = "";
                            else
                                txtBox.Enabled = false;
                        }
                        //下拉框控件 
                        if (control is DropDownList)
                        {
                            DropDownList ddlList = (DropDownList)control;
                            if (type == "isClear" && ddlList.Enabled != false)
                                ddlList.SelectedIndex = -1;
                            else
                                ddlList.Enabled = false;
                        }
                        //复选框控件
                        if (control is CheckBox)
                        {
                            CheckBox chkBox = (CheckBox)control;
                            if (type == "isClear" && chkBox.Enabled != false)
                                chkBox.Checked = false;
                            else
                                chkBox.Enabled = false;
                        }

                        //点击按钮
                        if (control is Button)
                        {
                            Button btn = (Button)control;
                            if (type == "isClear" && btn.Enabled != false)
                                btn.Enabled = true;
                            else
                                btn.Enabled = false;
                        }
                        if (control is RadioButtonList)
                        {
                            RadioButtonList radioList = (RadioButtonList)control;
                            if (type == "isClear" && radioList.Enabled != false)
                                radioList.SelectedIndex = -1;
                            else
                                radioList.Enabled = false;
                        }
                    }
                }
            }

        }
        #endregion

        #region DataTable 转换为Json 字符串
        /// <summary>
        /// DataTable 对象 转换为Json 字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToJson(this DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToStr(""));
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }

            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
        }
        #endregion

        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
        #endregion

        #region 判断指定字符串是否包含指定字符
        /// <summary>
        /// 判断指定字符串是否包含指定字符
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <param name="strwhere">是否包含的字符串</param>
        /// <returns></returns>
        public static Boolean IndexOfstr(string str, string strwhere)
        {
            Boolean result = false;
            if (str.IndexOf(strwhere) != -1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region  得到Excel数据集合存入DataSet中
        /// <summary>
        /// 得到Excel数据集合存入DataSet中
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="sheetname"></param>
        /// <returns></returns>
        public static DataSet GetExcel(this string filepath, string sheetname)
        {
            File.GetAttributes(filepath);//获取文件属性
            File.SetAttributes(filepath, System.IO.FileAttributes.Normal);//将文件设置为正常文件

            string text = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;IMEX=1;'";
            OleDbConnection oleDbConnection = new OleDbConnection(text);
            oleDbConnection.Open();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("select * from [" + sheetname + "$]", text);
            DataSet dataSet = new DataSet();
            oleDbDataAdapter.Fill(dataSet);
            oleDbConnection.Close();
            oleDbConnection.Dispose();
            return dataSet;
        }
        #endregion

        #region 报表导出数据功能信息
        /// <summary>
        /// 报表导出数据功能信息
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="type">报表类型自定义报表名称</param>
        /// <returns>返回一个新的InteractiveExcel实例</returns>
        public static InteractiveExcel ToexcelTempte(DataTable execDt, string FileName)
        {
            InteractiveExcel ite = new InteractiveExcel();
            ite.OpenOrCreateNew();

            var sheet = ite.sheet;
            //循环插入数据信息
            for (int i = 0; i < execDt.Columns.Count; i++)
            {
                ite.InsertText(0, i, execDt.Columns[i].ColumnName);  //插入数据列名
                sheet.SetColumnWidth(i, 20 * 256);  //设置列的宽度

                #region 循环行数据信息
                for (int j = 0; j < execDt.Rows.Count; j++)
                {
                    var cellStyle = ite.workbook.CreateCellStyle();

                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
                    ////////设置单元格边框
                    cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                    cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                    cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                    cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;

                    cellStyle.FillPattern = NPOI.SS.UserModel.FillPatternType.SOLID_FOREGROUND;
                    //插入数据信息
                    ite.InsertText(j + 1, i, execDt.Rows[j][i].ToStr(), cellStyle);
                }
                #endregion

            }
            //保存文件下载
            ite.SaveDownload("" + FileName + ".xls");

            return ite;
        }
        #endregion

        #region 获取用户登录IP

        //获取页面全部字符串数据信息
        public static string getOutMessage()
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.Default;
            string response = client.UploadString("http://iframe.ip138.com/ipcity.asp", "");
            Match mc = Regex.Match(response, @"location.href=""(.*)""");

            response = client.UploadString(mc.Groups[1].Value, "");

            return response;   //截取字符串操作数据信息
        }

        //获得外网ip 
        public static string getDnsIP()
        {
            string dnsIP = "";
            try
            {
                dnsIP = getOutMessage(); //获取网页数据html数据信息
                int startStr = dnsIP.IndexOf("[");
                int endStr = dnsIP.LastIndexOf("]");

                dnsIP = dnsIP.Substring(startStr + 1, endStr - (startStr + 1)); //从返回的html里面获得 外网ip地址
            }
            catch
            {
                dnsIP = gethomeIP();
            }
            return dnsIP;
        }

        //获得内网ip
        public static string gethomeIP()
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;

            return addressList[0].ToStr(); ;
        }

        /// <summary>
        /// 获取用户登录IP判断是够网络连接，如果连接则进行外网，否则本地网路
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string ip = "";
            if (IsConnected())  // true: On Line  false: Off Line
                ip = getDnsIP();
            else
                ip = gethomeIP();

            return ip;

        }

        /// <summary>
        /// true: On Line  false: Off Line
        /// </summary>
        /// <param name="connectionDescription"></param>
        /// <param name="reservedValue"></param>
        /// <returns></returns>
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref   int dwFlag, int dwReserved);
        private static bool IsConnected()
        {
            System.Int32 dwFlag = new int();
            bool state = InternetGetConnectedState(ref   dwFlag, 0);
            return state;
        }
        #endregion

        #region 获取用户登录IP
        /// <summary>
        /// 获取客户端的IP地址
        /// </summary>
        public class IPNetworking
        {
            /// <summary>
            /// 取得客户端主机 IPv4 位址(通过DNS反查)
            /// </summary>
            /// <returns></returns>
            public static string GetClientIPv4Address()
            {
                string ipv4 = String.Empty;

                foreach (IPAddress ip in Dns.GetHostAddresses(GetClientIP()))
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        ipv4 = ip.ToString();
                        break;
                    }
                }

                if (ipv4 != String.Empty)
                {
                    return ipv4;
                }

                // 原作使用 Dns.GetHostName 方法取回的是 Server 端信息，非 Client 端。
                // 改写为利用 Dns.GetHostEntry 方法，由获取的 IPv6 位址反查 DNS 纪录，
                // 再逐一判断何者为 IPv4 协议，即可转为 IPv4 位址。
                foreach (IPAddress ip in Dns.GetHostEntry(GetClientIP()).AddressList)
                //foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        ipv4 = ip.ToString();
                        break;
                    }
                }

                return ipv4;
            }

            /// <summary>
            /// 取得客户端主机位址
            /// </summary>
            public static string GetClientIP()
            {
                if (null == HttpContext.Current.Request.ServerVariables["HTTP_VIA"])
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
            }
        }
        #endregion
    }
}
