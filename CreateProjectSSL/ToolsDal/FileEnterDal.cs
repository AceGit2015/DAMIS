/******************************************************************************
 * 
 * Filename:  FileEnterDal.cs
 * Description:  档案的录入操作
 * Author :  liangjw
 * Created Mark:   2013-11-05 5:53:25
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2011-2013 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:   liangjw
 * Update Description: 增加统计分析档案管理统计分析 GetDataTableProc(string procName, int FileClassID, string tableName)返回数据集
 * Update Mark : 2013-11-14
 * 
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolsCommon;
using ToolsModel;
using ToolsDal.Pages;
using ToolsHelper;
using System.Data;
using System.Data.SqlClient;
namespace ToolsDal
{
    public class FileEnterDal
    {

        #region 搜索列表分页获取数据列表
        /// <summary>
        /// 分页获取数据列表（案卷类别表）
        /// </summary>
        public PeterPages GetSearch(FileEnter FileEnter, int PageIndex, int PageSize, string strCountyId)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            if (!string.IsNullOrEmpty(FileEnter.FileFondsNo)) //执法档案全宗号
            {
                sqlwhere = sqlwhere + " and FileFondsNo like '%" + FileEnter.FileFondsNo + "%' ";
            }
            if (FileEnter.FileClassID > 0) //案卷类别编号
            {
                sqlwhere = sqlwhere + " and FileClassID = '" + FileEnter.FileClassID + "' ";
            }
            if (FileEnter.FileDirectoryID > 0) //档案目录编号
            {
                sqlwhere = sqlwhere + " and FileDirectoryID like '%" + FileEnter.FileDirectoryID + "%' ";
            }
            if (!string.IsNullOrEmpty(FileEnter.FilesNum))  //执法档案案卷号
            {
                sqlwhere = sqlwhere + " and FilesNum like '%" + FileEnter.FilesNum + "%' ";
            }
            if (!string.IsNullOrEmpty(FileEnter.FilesName)) //执法档案名称
            {
                sqlwhere = sqlwhere + " and FilesName like '%" + FileEnter.FilesName + "%' ";
            }
            if (!string.IsNullOrEmpty(FileEnter.EnterPeople)) //录入人
            {
                sqlwhere = sqlwhere + " and EnterPeople like '%" + FileEnter.EnterPeople + "%' ";
            }
            if (!string.IsNullOrEmpty(FileEnter.FileFondsNo))
            {
                sqlwhere = sqlwhere + " and FileFondsNo like '%" + FileEnter.FileFondsNo + "%' ";
            }
            if (FileEnter.FileClassID != 0)
            {
                sqlwhere = sqlwhere + " and FileClassID ='" + FileEnter.FileClassID + "' ";
            }

            //数据类型 0默认正常[1已销毁, 2已借阅, 3已移交]
            if (FileEnter.SJLX == 0)
            {
                sqlwhere = sqlwhere + " and SJLX in (0,3) ";
            }
            else if (FileEnter.SJLX == 3)
            {
                sqlwhere = sqlwhere + " and SJLX in (0,3) and  (CHARINDEX('*',FilesNum) > 0 or CHARINDEX('*',PicDocumentNo) > 0 ) ";
            }
            else if (FileEnter.SJLX == -1)
            {
                sqlwhere = sqlwhere + " and SJLX<>3 ";
            }
            else
            {
                sqlwhere = sqlwhere + " and SJLX=" + FileEnter.SJLX + "";
            }


            //获取开始日期和结束日期
            string startTime = FileEnter.tmp_Data.Split('|')[0];
            string endTime = FileEnter.tmp_Data.Split('|')[1];
            if (startTime != "" && endTime != "" && FileEnter.NumStatic == "0")  //录入时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,EnterDate, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            else if (startTime != "" && endTime != "" && FileEnter.NumStatic == "1")  //归档时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,FileLibraryData, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            else if (startTime != "" && endTime != "" && FileEnter.NumStatic == "2")  //移交时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,FileTransferDate, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            else if (startTime != "" && endTime != "" && FileEnter.NumStatic == "3")  //接收时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,ReceiptTime, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            if (strCountyId != "420100")
            {
                sqlwhere = sqlwhere + " and EnteCountyId ='" + strCountyId + "' ";
            }
            sqlwhere = sqlwhere + " and SJLX<>8 ";
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[TB_FileEnter_View]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            //entity.Orderfield = " EnterDate desc";  //排序字段
            entity.Orderfield = " id desc";  //排序字段
            entity.PageIndex = PageIndex;
            entity.Fields = "*";

            fy = SqlPageList.GetPageLists(entity);
            return fy;
        }

        /// <summary>
        /// 分页获取数据列表（案卷类别表）
        /// </summary>
        public PeterPages GetSearchDelete(FileEnter FileEnter, int PageIndex, int PageSize, string strCountyId)
        {
            PeterPages fy = null;
            string sqlwhere = " 1=1 ";

            if (!string.IsNullOrEmpty(FileEnter.FilesName)) //执法档案名称
            {
                sqlwhere = sqlwhere + " and FilesName like '%" + FileEnter.FilesName + "%' ";
            }
            if (!string.IsNullOrEmpty(FileEnter.EnterPeople)) //录入人
            {
                sqlwhere = sqlwhere + " and EnterPeople like '%" + FileEnter.EnterPeople + "%' ";
            }

            //获取开始日期和结束日期
            string startTime = FileEnter.tmp_Data.Split('|')[0];
            string endTime = FileEnter.tmp_Data.Split('|')[1];
            if (startTime != "" && endTime != "")  //录入时间
            {
                sqlwhere = sqlwhere + @" and  ( convert(varchar,EnterDate, 120 )   between '" + startTime
                                    + "' and  convert(char(10),dateadd(dd,1,'" + endTime + "'),120)) ";
            }
            sqlwhere = sqlwhere + " and SJLX=8 ";
            PageInfoNew entity = new PageInfoNew();
            entity.Sqlwhere = sqlwhere.Trim();
            entity.Tablename = "[TB_FileEnter_View]";  //用户表，注意如果是多表可以写成视图进行查询，这里就为视图名称
            entity.PageSize = PageSize;
            entity.Fieldkey = "id";  //主键
            //entity.Orderfield = " EnterDate desc";  //排序字段
            entity.Orderfield = " EnterDate desc,id desc";  //排序字段
            entity.PageIndex = PageIndex;
            entity.Fields = "*";

            fy = SqlPageList.GetPageLists(entity);
            return fy;
        }
        #endregion

        #region 判断数据是否存在
        /// <summary>
        ///  判断数据是否存在
        /// </summary>
        /// <param name="name">判断名称是否存在</param>
        /// <param name="id">参数ID</param>
        /// <returns>返回一个bool类型，True为存在，False为不存在</returns>
        public static bool Exists(string name, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FileEnter");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }
        #endregion

        #region 返回一个DataTable数据集合
        /// <summary>
        /// 返回一个DataTable数据集合
        /// </summary>
        /// <param name="strwhere">传递参数为id</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetDataTable(string strwhere)
        {
            return TSQLServer.ExecDt("select * from [FileEnter] where 1=1 " + strwhere);
        }

        /// <summary>
        /// 返回一个DataTable数据集合
        /// </summary>
        /// <param name="strwhere">传递参数为id</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetDataTableyjzd(string strwhere)
        {
            return TSQLServer.ExecDt("select * from [TB_FileEnter_View] where 1=1 " + strwhere);
        }
        #endregion

        #region 返回一个DataRow数据集合
        /// <summary>
        /// 返回一个DataRow数据集合
        /// </summary>
        /// <param name="values">传递参数为id</param>
        /// <returns>返回一个DataRow</returns>
        public DataRow GetRow(params object[] values)
        {
            return TSQLServer.ExecDr("select  * from  TB_FileEnter_View where id =" + values[0] + "");
        }
        #endregion

        #region 删除一行记录
        /// <summary>
        ///删除指定一行数据信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Delete(params object[] values)
        {
            return TSQLServer.ExecuteNonQuery("delete [FileEnter] where   id =" + values[0] + "");
        }

        /// <summary>
        ///删除指定一行数据信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int DeleteUpdate(string sjlx, params object[] values)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileEnter set ");
            strSql.Append("SJLX=@SJLX ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SJLX", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.VarChar,10)};
            parameters[0].Value = sjlx;
            parameters[1].Value = values[0];

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 删除指定多行数据信息
        /// <summary>
        /// 删除指定多行数据信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int DeleteAllIn(string values)
        {
            return TSQLServer.ExecuteNonQuery("delete [FileEnter] where id in(" + values + ")");
        }
        /// <summary>
        /// 删除指定多行数据信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int DeleteAllInUpdate(string sjlx, string values)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileEnter set ");
            strSql.Append("SJLX=@SJLX ");
            strSql.Append(" where id in (" + values + ")");
            SqlParameter[] parameters = {
					new SqlParameter("@SJLX", SqlDbType.VarChar,50)};
            parameters[0].Value = sjlx;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 删除所有信息
        /// <summary>
        /// 删除所有信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int DeleteAllInfor(string values)
        {
            return TSQLServer.ExecuteNonQuery(" delete from fileenter where EnteCountyId='" + values + "' ");
        }
        #endregion

        #region 插入一行数据
        /// <summary>
        ///  插入一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int Insert(params object[] values)
        {

            string strSql = "";
            strSql = @"insert into [FileEnter](
                                        FileFondsNo,
                                        FileClassID,
                                        FileDirectoryID,
                                        FilesNum,
                                        FilesName,
                                        EnterPeople,
                                        EnterDate,
                                        SaveDeadlineID,
                                        BuildAds,
                                        BuildCheckT,
                                        BuildFilingT,
                                        BuildArea,
                                        BuildALicense,
                                        CheckAds,
                                        CheckNature,
                                        CheckResult,
                                        ComplainAds,
                                        ComplainResult,
                                        FireNature,
                                        FireArea,
                                        FireEstateLoss,
                                        FireHPeople,
                                        FireDPeople,
                                        MassSportsAds,
                                        MassSportsResult,
                                        PunishTypeID,
                                        PunishFinePay,
                                        PunishParts,
                                        TempClose,
                                        TempDay,
                                        ForceRunAds,
                                        ForcePunish,
                                        ApplyReviewPeople,
                                        CountryPayAds,
                                        PenalDocSex,
                                        PenalDocBirthday,
                                        PenalDocNation,
                                        PenalDocAds,
                                        PenalDocCrimeAds,
                                        PenalDocResult,
                                        EnforcementID,
                                        EnforcementName,
                                        EnforcementPeople,
                                        EnforcementPeople2,
                                        EnforcementDate,
                                        EnforcementDate2,
                                        BuildUnitName,
                                        BuildItemName,
                                        CheckUnitName,
                                        CheckItemName,
                                        ComplainPeople,
                                        ComplainNPeople,
                                        CompainN,
                                        MassSportsPeople,
                                        MassSportName,
                                        FireAds,
                                        FireUnitName,
                                        FireDateTime,
                                        FireN,
                                        PunishMain,
                                        PunishWhy,
                                        TempUintName,
                                        TempN,
                                        TempDX,
                                        ForceUnitName,
                                        ForceN,
                                        ApplyFY,
                                        CountryMain,
                                        PenalName,
                                        PenalZN,
                                        ApplyNContent,
                                        PunishAds,
                                        ApplyMain,
                                        EnteUserName,
                                        EnteCountyId,
                                        FileLibraryID,
                                        FileLibraryName,
                                        YesUnit, 
                                        PicDocumentNo,
                                        PicDicL,
                                        EngDroping,
                                        buildingHeight,
                                        FileLibraryData,
                                        Ghmj,
                                        Ccss,
                                        Srs,
                                        Wrs,
                                        BuildAdsArea,
                                        CheckAdsArea,
                                        ComplainAdsArea,
                                        MassSportsAdsArea,
                                        PunishAdsArea,
                                        TempCloseArea,
                                        ForceRunAdsArea,
                                        ApplyFYArea,
                                        CountryPayAdsArea,
                                        PenalDocAdsArea,
                                        PenalDocCrimeAdsArea,
                                        CheckNaturefc,
                                        Columns,
                                        Cupboard,
                                        Frame) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,@41,@42,@43,@44,@45,@46,@47,@48,@49,@50,@51,@52,@53,@54,@55,@56,@57,@58,@59,@60,@61,@62,@63,@64,@65,@66,@67,@68,@69,@70,@71,@72,@73,@74,@75,@76,@77,@78,@79,@80,@81,@82,@83,@84,@85,@86,@87,@88,@89,@90,@91,@92,@93,@94,@95,@96,@97,@98,@99,@100,@101,@102);SELECT @@IDENTITY";
            SqlParameter[] parameters = {
				 
					new SqlParameter("@1", SqlDbType.NVarChar,50),
					new SqlParameter("@2", SqlDbType.NVarChar,50),
					new SqlParameter("@3", SqlDbType.NVarChar,50),
					new SqlParameter("@4", SqlDbType.NVarChar,200),
					new SqlParameter("@5", SqlDbType.NVarChar,50),
					new SqlParameter("@6", SqlDbType.NVarChar,50),
					new SqlParameter("@7", SqlDbType.DateTime),
					new SqlParameter("@8", SqlDbType.NVarChar,200),
					new SqlParameter("@9", SqlDbType.NVarChar,200),
					new SqlParameter("@10", SqlDbType.NVarChar,200),
					new SqlParameter("@11", SqlDbType.NVarChar,200),
					new SqlParameter("@12", SqlDbType.NVarChar,50),
					new SqlParameter("@13", SqlDbType.NVarChar,200),
					new SqlParameter("@14", SqlDbType.NVarChar,50),
					new SqlParameter("@15", SqlDbType.NVarChar,50),
					new SqlParameter("@16", SqlDbType.NVarChar,200),
					new SqlParameter("@17", SqlDbType.NVarChar,50),
					new SqlParameter("@18", SqlDbType.NVarChar,50),
					new SqlParameter("@19", SqlDbType.NVarChar,50),
					new SqlParameter("@20", SqlDbType.NVarChar,50),
					new SqlParameter("@21", SqlDbType.NVarChar,50),
					new SqlParameter("@22", SqlDbType.NVarChar,50),
					new SqlParameter("@23", SqlDbType.NVarChar,200),
					new SqlParameter("@24", SqlDbType.NVarChar,50),
					new SqlParameter("@25", SqlDbType.NVarChar,-1),
					new SqlParameter("@26", SqlDbType.NVarChar,50),
					new SqlParameter("@27", SqlDbType.NVarChar,50),
					new SqlParameter("@28", SqlDbType.NVarChar,200),
					new SqlParameter("@29", SqlDbType.NVarChar,50),
					new SqlParameter("@30", SqlDbType.NVarChar,200),
					new SqlParameter("@31", SqlDbType.NVarChar,-1),
					new SqlParameter("@32", SqlDbType.NVarChar,200),
					new SqlParameter("@33", SqlDbType.NVarChar,200),
					new SqlParameter("@34", SqlDbType.NVarChar,50),
					new SqlParameter("@35", SqlDbType.NVarChar,20),
					new SqlParameter("@36", SqlDbType.NVarChar,50),
					new SqlParameter("@37", SqlDbType.NVarChar,200),
					new SqlParameter("@38", SqlDbType.NVarChar,200),
					new SqlParameter("@39", SqlDbType.NVarChar,500),
					new SqlParameter("@40", SqlDbType.NVarChar,50),
					new SqlParameter("@41", SqlDbType.NVarChar,200),
					new SqlParameter("@42", SqlDbType.NVarChar,50),
					new SqlParameter("@43", SqlDbType.VarChar,50),
					new SqlParameter("@44", SqlDbType.NVarChar,20),
					new SqlParameter("@45", SqlDbType.NVarChar,20),
					new SqlParameter("@46", SqlDbType.NVarChar,200),
					new SqlParameter("@47", SqlDbType.NVarChar,200),
					new SqlParameter("@48", SqlDbType.NVarChar,200),
					new SqlParameter("@49", SqlDbType.NVarChar,50),
					new SqlParameter("@50", SqlDbType.NVarChar,50),
					new SqlParameter("@51", SqlDbType.NVarChar,200),
					new SqlParameter("@52", SqlDbType.NVarChar,50),
					new SqlParameter("@53", SqlDbType.NVarChar,50),
					new SqlParameter("@54", SqlDbType.NVarChar,200),
					new SqlParameter("@55", SqlDbType.NVarChar,200),
					new SqlParameter("@56", SqlDbType.NVarChar,50),
					new SqlParameter("@57", SqlDbType.NVarChar,20),
					new SqlParameter("@58", SqlDbType.NVarChar,50),
					new SqlParameter("@59", SqlDbType.NVarChar,50),
					new SqlParameter("@60", SqlDbType.NVarChar,50),
					new SqlParameter("@61", SqlDbType.NVarChar,50),
					new SqlParameter("@62", SqlDbType.NVarChar,50),
					new SqlParameter("@63", SqlDbType.NVarChar,50),
					new SqlParameter("@64", SqlDbType.NVarChar,50),
					new SqlParameter("@65", SqlDbType.NVarChar,50),
					new SqlParameter("@66", SqlDbType.NVarChar,50),
					new SqlParameter("@67", SqlDbType.NVarChar,200),
					new SqlParameter("@68", SqlDbType.NVarChar,50),
					new SqlParameter("@69", SqlDbType.NVarChar,50),
					new SqlParameter("@70", SqlDbType.NVarChar,200),
					new SqlParameter("@71", SqlDbType.NVarChar,200),
					new SqlParameter("@72", SqlDbType.NVarChar,50),
                    new SqlParameter("@73", SqlDbType.VarChar,50),
					new SqlParameter("@74", SqlDbType.NVarChar,50),
					new SqlParameter("@75", SqlDbType.NVarChar,50),
					new SqlParameter("@76", SqlDbType.VarChar,50),
                    new SqlParameter("@77", SqlDbType.VarChar,50),
					new SqlParameter("@78", SqlDbType.NVarChar,200),
					new SqlParameter("@79", SqlDbType.NVarChar,100),
					new SqlParameter("@80", SqlDbType.VarChar,100),
                    new SqlParameter("@81", SqlDbType.VarChar,100),
                    new SqlParameter("@82", SqlDbType.VarChar,100),
                    new SqlParameter("@83", SqlDbType.VarChar,20),
					new SqlParameter("@84", SqlDbType.VarChar,50),
                    new SqlParameter("@85", SqlDbType.VarChar,50),
                    new SqlParameter("@86", SqlDbType.VarChar,10),
                    new SqlParameter("@87", SqlDbType.VarChar,10),
                    new SqlParameter("@88", SqlDbType.VarChar,4),
					new SqlParameter("@89", SqlDbType.VarChar,4),
					new SqlParameter("@90", SqlDbType.VarChar,4),
					new SqlParameter("@91", SqlDbType.VarChar,4),
                    new SqlParameter("@92", SqlDbType.VarChar,4),
                    new SqlParameter("@93", SqlDbType.VarChar,4),
                    new SqlParameter("@94", SqlDbType.VarChar,4),
					new SqlParameter("@95", SqlDbType.VarChar,4),
                    new SqlParameter("@96", SqlDbType.VarChar,4),
                    new SqlParameter("@97", SqlDbType.VarChar,4),
                    new SqlParameter("@98", SqlDbType.VarChar,4),
                    new SqlParameter("@99", SqlDbType.VarChar,4),
                    new SqlParameter("@100", SqlDbType.VarChar,10),
                    new SqlParameter("@101", SqlDbType.VarChar,10),
                    new SqlParameter("@102", SqlDbType.VarChar,10)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];
            parameters[4].Value = values[4];
            parameters[5].Value = values[5];
            parameters[6].Value = values[6];
            parameters[7].Value = values[7];
            parameters[8].Value = values[8];
            parameters[9].Value = values[9];
            parameters[10].Value = values[10];
            parameters[11].Value = values[11];
            parameters[12].Value = values[12];
            parameters[13].Value = values[13];
            parameters[14].Value = values[14];
            parameters[15].Value = values[15];
            parameters[16].Value = values[16];
            parameters[17].Value = values[17];
            parameters[18].Value = values[18];
            parameters[19].Value = values[19];
            parameters[20].Value = values[20];
            parameters[21].Value = values[21];
            parameters[22].Value = values[22];
            parameters[23].Value = values[23];
            parameters[24].Value = values[24];
            parameters[25].Value = values[25];
            parameters[26].Value = values[26];
            parameters[27].Value = values[27];
            parameters[28].Value = values[28];
            parameters[29].Value = values[29];
            parameters[30].Value = values[30];
            parameters[31].Value = values[31];
            parameters[32].Value = values[32]; ;
            parameters[33].Value = values[33];
            parameters[34].Value = values[34];
            parameters[35].Value = values[35];
            parameters[36].Value = values[36];
            parameters[37].Value = values[37];
            parameters[38].Value = values[38];
            parameters[39].Value = values[39];
            parameters[40].Value = values[40];
            parameters[41].Value = values[41];
            parameters[42].Value = values[42];
            parameters[43].Value = values[43];
            parameters[44].Value = values[44];
            parameters[45].Value = values[45];
            parameters[46].Value = values[46];
            parameters[47].Value = values[47];
            parameters[48].Value = values[48];
            parameters[49].Value = values[49];
            parameters[50].Value = values[50];
            parameters[51].Value = values[51];
            parameters[52].Value = values[52];
            parameters[53].Value = values[53];
            parameters[54].Value = values[54];
            parameters[55].Value = values[55];
            parameters[56].Value = values[56];
            parameters[57].Value = values[57];
            parameters[58].Value = values[58];
            parameters[59].Value = values[59];
            parameters[60].Value = values[60];
            parameters[61].Value = values[61];
            parameters[62].Value = values[62];
            parameters[63].Value = values[63];
            parameters[64].Value = values[64];
            parameters[65].Value = values[65];
            parameters[66].Value = values[66];
            parameters[67].Value = values[67];
            parameters[68].Value = values[68];
            parameters[69].Value = values[69];
            parameters[70].Value = values[70];
            parameters[71].Value = values[71];
            parameters[72].Value = values[72];
            parameters[73].Value = values[73];
            parameters[74].Value = values[74];
            parameters[75].Value = values[75];
            parameters[76].Value = values[76];
            parameters[77].Value = values[77];
            parameters[78].Value = values[78];
            parameters[79].Value = values[79];
            parameters[80].Value = values[80];
            parameters[81].Value = values[81];
            parameters[82].Value = values[82];
            parameters[83].Value = values[83];
            parameters[84].Value = values[84];
            parameters[85].Value = values[85];
            parameters[86].Value = values[86];
            parameters[87].Value = values[87];
            parameters[88].Value = values[88];
            parameters[89].Value = values[89];
            parameters[90].Value = values[90];
            parameters[91].Value = values[91];
            parameters[92].Value = values[92];
            parameters[93].Value = values[93];
            parameters[94].Value = values[94];
            parameters[95].Value = values[95];
            parameters[96].Value = values[96];
            parameters[97].Value = values[97];
            parameters[98].Value = values[98];
            parameters[99].Value = values[99];
            parameters[100].Value = values[100];
            parameters[101].Value = values[101];

            object obj = DbHelperSQL.GetSingle(strSql, parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion

        #region 更新一行数据
        /// <summary>
        ///  更新一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int Update(params object[] values)
        {
            string strSql = @"update [FileEnter] set
                                      FileFondsNo = @1,
                                        FileClassID = @2,
                                        FileDirectoryID = @3,
                                        FilesNum = @4,
                                        FilesName = @5,
                                        EnterPeople = @6,
                                        EnterDate = @7,
                                        SaveDeadlineID = @8,
                                        BuildAds = @9,
                                        BuildCheckT = @10,
                                        BuildFilingT = @11,
                                        BuildArea = @12,
                                        BuildALicense = @13,
                                        CheckAds = @14,
                                        CheckNature = @15,
                                        CheckResult = @16,
                                        ComplainAds = @17,
                                        ComplainResult = @18,
                                        FireNature = @19,
                                        FireArea = @20,
                                        FireEstateLoss = @21,
                                        FireHPeople = @22,
                                        FireDPeople = @23,
                                        MassSportsAds = @24,
                                        MassSportsResult = @25,
                                        PunishTypeID = @26,
                                        PunishFinePay = @27,
                                        PunishParts = @28,
                                        TempClose = @29,
                                        TempDay = @30,
                                        ForceRunAds = @31,
                                        ForcePunish = @32,
                                        ApplyReviewPeople = @33,
                                        CountryPayAds = @34,
                                        PenalDocSex = @35,
                                        PenalDocBirthday = @36,
                                        PenalDocNation = @37,
                                        PenalDocAds = @38,
                                        PenalDocCrimeAds = @39,
                                        PenalDocResult = @40,
                                        EnforcementID = @41,
                                        EnforcementName = @42,
                                        EnforcementPeople = @43,
                                        EnforcementPeople2 = @44,
                                        EnforcementDate = @45,
                                        EnforcementDate2 = @46,
                                        BuildUnitName = @47,
                                        BuildItemName = @48,
                                        CheckUnitName = @49,
                                        CheckItemName = @50,
                                        ComplainPeople = @51,
                                        ComplainNPeople = @52,
                                        CompainN = @53,
                                        MassSportsPeople = @54,
                                        MassSportName = @55,
                                        FireAds = @56,
                                        FireUnitName = @57,
                                        FireDateTime = @58,
                                        FireN = @59,
                                        PunishMain = @60,
                                        PunishWhy = @61,
                                        TempUintName = @62,
                                        TempN = @63,
                                        TempDX = @64,
                                        ForceUnitName = @65,
                                        ForceN = @66,
                                        ApplyFY = @67,
                                        CountryMain = @68,
                                        PenalName = @69,
                                        PenalZN = @70,
                                        ApplyNContent = @71,
                                        PunishAds = @72,
                                        ApplyMain = @73,
                                        EnteUserName = @74,
                                        EnteCountyId = @75,
                                        FileLibraryID = @76,
                                        FileLibraryName = @77,
                                        YesUnit = @78, 
                                        PicDocumentNo = @79,
                                        PicDicL = @80,
                                        EngDroping = @81,
                                        buildingHeight=@82,
                                        FileLibraryData=@83,
                                        Ghmj =@84,
                                        Ccss=@85,
                                        Srs=@86,
                                        Wrs=@87,
                                        BuildAdsArea=@88,
                                        CheckAdsArea=@89,
                                        ComplainAdsArea=@90,
                                        MassSportsAdsArea=@91,
                                        PunishAdsArea=@92,
                                        TempCloseArea=@93,
                                        ForceRunAdsArea=@94,
                                        ApplyFYArea=@95,
                                        CountryPayAdsArea=@96,
                                        PenalDocAdsArea=@97,
                                        PenalDocCrimeAdsArea=@98,
                                        CheckNaturefc=@99,
                                        Columns=@100,
                                        Cupboard=@101,
                                        Frame=@102
                                             where id = @id";
            SqlParameter[] parameters = {
				 
					new SqlParameter("@1", SqlDbType.NVarChar,50),
					new SqlParameter("@2", SqlDbType.NVarChar,50),
					new SqlParameter("@3", SqlDbType.NVarChar,50),
					new SqlParameter("@4", SqlDbType.NVarChar,200),
					new SqlParameter("@5", SqlDbType.NVarChar,50),
					new SqlParameter("@6", SqlDbType.NVarChar,50),
					new SqlParameter("@7", SqlDbType.DateTime),
					new SqlParameter("@8", SqlDbType.NVarChar,200),
					new SqlParameter("@9", SqlDbType.NVarChar,200),
					new SqlParameter("@10", SqlDbType.NVarChar,200),
					new SqlParameter("@11", SqlDbType.NVarChar,200),
					new SqlParameter("@12", SqlDbType.NVarChar,50),
					new SqlParameter("@13", SqlDbType.NVarChar,200),
					new SqlParameter("@14", SqlDbType.NVarChar,50),
					new SqlParameter("@15", SqlDbType.NVarChar,50),
					new SqlParameter("@16", SqlDbType.NVarChar,200),
					new SqlParameter("@17", SqlDbType.NVarChar,50),
					new SqlParameter("@18", SqlDbType.NVarChar,50),
					new SqlParameter("@19", SqlDbType.NVarChar,50),
					new SqlParameter("@20", SqlDbType.NVarChar,50),
					new SqlParameter("@21", SqlDbType.NVarChar,50),
					new SqlParameter("@22", SqlDbType.NVarChar,50),
					new SqlParameter("@23", SqlDbType.NVarChar,200),
					new SqlParameter("@24", SqlDbType.NVarChar,50),
					new SqlParameter("@25", SqlDbType.NVarChar,-1),
					new SqlParameter("@26", SqlDbType.NVarChar,50),
					new SqlParameter("@27", SqlDbType.NVarChar,50),
					new SqlParameter("@28", SqlDbType.NVarChar,200),
					new SqlParameter("@29", SqlDbType.NVarChar,50),
					new SqlParameter("@30", SqlDbType.NVarChar,200),
					new SqlParameter("@31", SqlDbType.NVarChar,-1),
					new SqlParameter("@32", SqlDbType.NVarChar,200),
					new SqlParameter("@33", SqlDbType.NVarChar,200),
					new SqlParameter("@34", SqlDbType.NVarChar,50),
					new SqlParameter("@35", SqlDbType.NVarChar,20),
					new SqlParameter("@36", SqlDbType.NVarChar,50),
					new SqlParameter("@37", SqlDbType.NVarChar,200),
					new SqlParameter("@38", SqlDbType.NVarChar,200),
					new SqlParameter("@39", SqlDbType.NVarChar,500),
					new SqlParameter("@40", SqlDbType.NVarChar,50),
					new SqlParameter("@41", SqlDbType.NVarChar,200),
					new SqlParameter("@42", SqlDbType.NVarChar,50),
					new SqlParameter("@43", SqlDbType.VarChar,50),
					new SqlParameter("@44", SqlDbType.NVarChar,20),
					new SqlParameter("@45", SqlDbType.NVarChar,20),
					new SqlParameter("@46", SqlDbType.NVarChar,200),
					new SqlParameter("@47", SqlDbType.NVarChar,200),
					new SqlParameter("@48", SqlDbType.NVarChar,200),
					new SqlParameter("@49", SqlDbType.NVarChar,200),
					new SqlParameter("@50", SqlDbType.NVarChar,200),
                    new SqlParameter("@51", SqlDbType.NVarChar,200),
					new SqlParameter("@52", SqlDbType.NVarChar,50),
					new SqlParameter("@53", SqlDbType.NVarChar,50),
					new SqlParameter("@54", SqlDbType.NVarChar,200),
					new SqlParameter("@55", SqlDbType.NVarChar,200),
					new SqlParameter("@56", SqlDbType.NVarChar,50),
					new SqlParameter("@57", SqlDbType.NVarChar,20),
					new SqlParameter("@58", SqlDbType.NVarChar,50),
					new SqlParameter("@59", SqlDbType.NVarChar,50),
					new SqlParameter("@60", SqlDbType.NVarChar,50),
					new SqlParameter("@61", SqlDbType.NVarChar,50),
					new SqlParameter("@62", SqlDbType.NVarChar,50),
					new SqlParameter("@63", SqlDbType.NVarChar,50),
					new SqlParameter("@64", SqlDbType.NVarChar,50),
					new SqlParameter("@65", SqlDbType.NVarChar,50),
					new SqlParameter("@66", SqlDbType.NVarChar,50),
					new SqlParameter("@67", SqlDbType.NVarChar,200),
					new SqlParameter("@68", SqlDbType.NVarChar,50),
					new SqlParameter("@69", SqlDbType.NVarChar,50),
					new SqlParameter("@70", SqlDbType.NVarChar,200),
					new SqlParameter("@71", SqlDbType.NVarChar,200),
					new SqlParameter("@72", SqlDbType.NVarChar,50),
                    new SqlParameter("@73", SqlDbType.VarChar,50),
					new SqlParameter("@74", SqlDbType.NVarChar,50),
					new SqlParameter("@75", SqlDbType.NVarChar,50),
					new SqlParameter("@76", SqlDbType.VarChar,50),
                    new SqlParameter("@77", SqlDbType.VarChar,50),
                    new SqlParameter("@78", SqlDbType.NVarChar,200),
					new SqlParameter("@79", SqlDbType.NVarChar,100),
					new SqlParameter("@80", SqlDbType.VarChar,100),
                    new SqlParameter("@81", SqlDbType.VarChar,100),
                    new SqlParameter("@82", SqlDbType.VarChar,100),
                    new SqlParameter("@83", SqlDbType.VarChar,100),
                    new SqlParameter("@84", SqlDbType.VarChar,50),
                    new SqlParameter("@85", SqlDbType.VarChar,50),
                    new SqlParameter("@86", SqlDbType.VarChar,10),
                    new SqlParameter("@87", SqlDbType.VarChar,10),
                    new SqlParameter("@88", SqlDbType.VarChar,4),
					new SqlParameter("@89", SqlDbType.VarChar,4),
					new SqlParameter("@90", SqlDbType.VarChar,4),
					new SqlParameter("@91", SqlDbType.VarChar,4),
                    new SqlParameter("@92", SqlDbType.VarChar,4),
                    new SqlParameter("@93", SqlDbType.VarChar,4),
                    new SqlParameter("@94", SqlDbType.VarChar,4),
					new SqlParameter("@95", SqlDbType.VarChar,4),
                    new SqlParameter("@96", SqlDbType.VarChar,4),
                    new SqlParameter("@97", SqlDbType.VarChar,4),
                    new SqlParameter("@98", SqlDbType.VarChar,4),
                    new SqlParameter("@99", SqlDbType.VarChar,4),
                    new SqlParameter("@100", SqlDbType.VarChar,10),
                    new SqlParameter("@101", SqlDbType.VarChar,10),
                    new SqlParameter("@102", SqlDbType.VarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];
            parameters[3].Value = values[3];
            parameters[4].Value = values[4];
            parameters[5].Value = values[5];
            parameters[6].Value = values[6];
            parameters[7].Value = values[7];
            parameters[8].Value = values[8];
            parameters[9].Value = values[9];
            parameters[10].Value = values[10];
            parameters[11].Value = values[11];
            parameters[12].Value = values[12];
            parameters[13].Value = values[13];
            parameters[14].Value = values[14];
            parameters[15].Value = values[15];
            parameters[16].Value = values[16];
            parameters[17].Value = values[17];
            parameters[18].Value = values[18];
            parameters[19].Value = values[19];
            parameters[20].Value = values[20];
            parameters[21].Value = values[21];
            parameters[22].Value = values[22];
            parameters[23].Value = values[23];
            parameters[24].Value = values[24];
            parameters[25].Value = values[25];
            parameters[26].Value = values[26];
            parameters[27].Value = values[27];
            parameters[28].Value = values[28];
            parameters[29].Value = values[29];
            parameters[30].Value = values[30];
            parameters[31].Value = values[31];
            parameters[32].Value = values[32]; ;
            parameters[33].Value = values[33];
            parameters[34].Value = values[34];
            parameters[35].Value = values[35];
            parameters[36].Value = values[36];
            parameters[37].Value = values[37];
            parameters[38].Value = values[38];
            parameters[39].Value = values[39];
            parameters[40].Value = values[40];
            parameters[41].Value = values[41];
            parameters[42].Value = values[42];
            parameters[43].Value = values[43];
            parameters[44].Value = values[44];
            parameters[45].Value = values[45];
            parameters[46].Value = values[46];
            parameters[47].Value = values[47];
            parameters[48].Value = values[48];
            parameters[49].Value = values[49];
            parameters[50].Value = values[50];
            parameters[51].Value = values[51];
            parameters[52].Value = values[52];
            parameters[53].Value = values[53];
            parameters[54].Value = values[54];
            parameters[55].Value = values[55];
            parameters[56].Value = values[56];
            parameters[57].Value = values[57];
            parameters[58].Value = values[58];
            parameters[59].Value = values[59];
            parameters[60].Value = values[60];
            parameters[61].Value = values[61];
            parameters[62].Value = values[62];
            parameters[63].Value = values[63];
            parameters[64].Value = values[64];
            parameters[65].Value = values[65];
            parameters[66].Value = values[66];
            parameters[67].Value = values[67];
            parameters[68].Value = values[68];
            parameters[69].Value = values[69];
            parameters[70].Value = values[70];
            parameters[71].Value = values[71];
            parameters[72].Value = values[72];
            parameters[73].Value = values[73];
            parameters[74].Value = values[74];
            parameters[75].Value = values[75];
            parameters[76].Value = values[76];
            parameters[77].Value = values[77];
            parameters[78].Value = values[78];
            parameters[79].Value = values[79];
            parameters[80].Value = values[80];
            parameters[81].Value = values[81];
            parameters[82].Value = values[82];
            parameters[83].Value = values[83];
            parameters[84].Value = values[84];
            parameters[85].Value = values[85];
            parameters[86].Value = values[86];
            parameters[87].Value = values[87];
            parameters[88].Value = values[88];
            parameters[89].Value = values[89];
            parameters[90].Value = values[90];
            parameters[91].Value = values[91];
            parameters[92].Value = values[92];
            parameters[93].Value = values[93];
            parameters[94].Value = values[94];
            parameters[95].Value = values[95];
            parameters[96].Value = values[96];
            parameters[97].Value = values[97];
            parameters[98].Value = values[98];
            parameters[99].Value = values[99];
            parameters[100].Value = values[100];
            parameters[101].Value = values[101];
            parameters[102].Value = values[102];

            return DbHelperSQL.ExecuteSql(strSql, parameters);

        }
        #endregion

        #region 档案管理统计分析
        /// <summary>
        /// 档案管理统计分析
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="FileClassID"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetDataTableProc(string procName, int FileClassID, string EnteCountyId, string tableName)
        {

            SqlParameter[] parameters = { new SqlParameter("@FileClassID", SqlDbType.Int, 4),
                                          new SqlParameter("@EnteCountyId", SqlDbType.NVarChar,100) };
            parameters[0].Value = FileClassID;
            parameters[1].Value = EnteCountyId;
            return TSQLServer.RunProcedure("FileReport_Count", parameters, "FileReport_Count").Tables[0];
        }

        /// <summary>
        /// 档案管理综合统计分析
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="EnteCountyId"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetDataTableProcSUM(string EnteCountyId)
        {

            SqlParameter[] parameters = { new SqlParameter("@EnteCountyId", SqlDbType.NVarChar, 100) };
            parameters[0].Value = EnteCountyId;
            return TSQLServer.RunProcedure("FileClass_Count", parameters, "FileClass_Count").Tables[0];
        }
        #endregion

        #region 更新一行数据 更新档案数据类型
        /// <summary>
        ///  更新一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int UpdateFileEnterSLLX(string strwhere, params object[] values)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileEnter set ");
            strSql.Append("SJLX=@SJLX ");
            strSql.Append(" where FileClassID=@FileClassID  and FilesName=@FilesName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SJLX", SqlDbType.NVarChar,50),
					new SqlParameter("@FileClassID", SqlDbType.VarChar,6),
					new SqlParameter("@FilesName", SqlDbType.VarChar,50)};
            parameters[0].Value = values[0];
            parameters[1].Value = values[1];
            parameters[2].Value = values[2];

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        #endregion

        #region 更新一行数据 档案归档
        /// <summary>
        ///  更新一行数据
        /// </summary>
        /// <param name="values">参数集合</param>
        /// <returns>返回更新受影响的行数</returns>
        public int UpdateFileEnterGD(string SJLX, string EnteCountyId, string EnteUserName, string FileLibraryID, string FileLibraryName, string oldEnteCountyId, string oldEnteUserName, string FileLibraryData, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileEnter set ");
            strSql.Append("SJLX=@SJLX,");
            strSql.Append("EnteCountyId=@EnteCountyId,");
            strSql.Append("EnteUserName=@EnteUserName,");
            strSql.Append("FileLibraryID=@FileLibraryID,");
            strSql.Append("FileLibraryName=@FileLibraryName,");
            strSql.Append("oldEnteCountyId=@oldEnteCountyId,");
            strSql.Append("oldEnteUserName=@oldEnteUserName, ");
            strSql.Append("FileLibraryData=@FileLibraryData ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@SJLX", SqlDbType.NVarChar,50),
					new SqlParameter("@EnteCountyId", SqlDbType.NVarChar,50),
				    new SqlParameter("@EnteUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileLibraryID", SqlDbType.NVarChar,50),
                    new SqlParameter("@FileLibraryName", SqlDbType.NVarChar,50),
                    new SqlParameter("@oldEnteCountyId", SqlDbType.NVarChar,50),
                    new SqlParameter("@oldEnteUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@FileLibraryData", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = SJLX;
            parameters[1].Value = EnteCountyId;
            parameters[2].Value = EnteUserName;
            parameters[3].Value = FileLibraryID;
            parameters[4].Value = FileLibraryName;
            parameters[5].Value = oldEnteCountyId;
            parameters[6].Value = oldEnteUserName;
            parameters[7].Value = FileLibraryData;
            parameters[8].Value = id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);


        }
        #endregion

        #region 批量归档
        /// <summary>
        /// 批量归档
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int UpdateAllGD(string FileLibraryID, string FileLibraryName, string FileLibraryData, string values)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileEnter set ");
            strSql.Append("FileLibraryID=@FileLibraryID,FileLibraryName=@FileLibraryName,FileLibraryData=@FileLibraryData  ");
            strSql.Append(" where id in (" + values + ")");
            SqlParameter[] parameters = {
					new SqlParameter("@FileLibraryID", SqlDbType.VarChar,6),
					new SqlParameter("@FileLibraryName", SqlDbType.VarChar,50),
					new SqlParameter("@FileLibraryData", SqlDbType.VarChar,50)};
            parameters[0].Value = FileLibraryID;
            parameters[1].Value = FileLibraryName;
            parameters[2].Value = FileLibraryData;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 所属单位
        /// <summary>
        /// 返回一个DataTable数据集合
        /// </summary>
        /// <param name="strwhere">传递参数为id</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable GetDWMCDataTable(string strwhere)
        {
            return TSQLServer.ExecDt("select * from [QXMCB] where 1=1 and qxdm='" + strwhere + "' ");
        }
        #endregion

        /// <summary>
        /// 排架号保存
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public int CheckSaveValue(Dictionary<string, string> dic)
        {
            string sqlStr = "";
            foreach (KeyValuePair<string, string> k in dic)
                sqlStr += " update FileEnter set Columns='" + k.Value.Split('|')[0] + "',Cupboard='" + k.Value.Split('|')[1] + "',Frame='" + k.Value.Split('|')[2] + "' where ID='" + k.Key + "'";

            return DbHelperSQL.ExecuteSql(sqlStr);
        }
    }
}
