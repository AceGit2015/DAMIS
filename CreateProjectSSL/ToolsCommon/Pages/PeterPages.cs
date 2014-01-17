using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ToolsCommon
{
    public class PeterPages
    {
        #region 属性
        /// <summary>
        /// 分页大小 (一页几条)
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public DataSet Ds { get; set; }

        /// <summary>
        /// 总页数 (计算所得)
        /// </summary>
        public int PageCount
        {
            get
            {
                int pageCount = 0;

                try
                {
                    pageCount = RecordCount / PageSize;
                    if ((RecordCount % PageSize) > 0)
                        pageCount++;
                }
                catch { }

                return pageCount;
            }
        }


        #region 构造函数
        public PeterPages()
        { }
        /// <summary>
        /// 分页信息类
        /// </summary>
        public PeterPages(int pageSize, int pageIndex)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
        }
        /// <summary>
        /// 分页信息类
        /// </summary>
        public PeterPages(int pageSize, int pageIndex, int recordCount)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.RecordCount = recordCount;
        }
        public PeterPages(int pageSize, int pageIndex, int recordCount, DataSet _ds)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.RecordCount = recordCount;
            this.Ds = _ds;
        }
        #endregion

        #endregion
    }
}
