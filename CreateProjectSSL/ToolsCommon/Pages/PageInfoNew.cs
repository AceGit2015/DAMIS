using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ToolsCommon
{

    public class PageInfoNew
    {


        private string tablename;

        public string Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }
        private string fieldkey;

        public string Fieldkey
        {
          get { return fieldkey; }
          set { fieldkey = value; }
        }
        private string fields;

        public string Fields
        {
            get { return fields; }
            set { fields = value; }
        }
        private string orderfield;

        public string Orderfield
        {
            get { return orderfield; }
            set { orderfield = value; }
        }
        private string sqlwhere = string.Empty;

        public string Sqlwhere
        {
            get { return sqlwhere; }
            set { sqlwhere = value; }
        }
        private int pagesize = 15;

        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }
        private int pageIndex = 1;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        private int ordertype = 0;

        public int OrderType
        {
            get { return ordertype; }
            set { ordertype = value; }
        }
        public PageInfoNew(string _tablename, string _fields, string _orderfield, string _sqlwhere, int _pagesize, int _pageIndex)
        {
            this.tablename = _tablename;
            this.fields = _fields;
            this.orderfield = _orderfield;
            this.pagesize = _pagesize;
            this.pageIndex = _pageIndex;
            this.Sqlwhere = _sqlwhere;

        }
        public PageInfoNew(string _tablename, string _fields, string _orderfield, string _sqlwhere, int _pagesize, int _pageIndex, int _ordertype)
        {
            this.tablename = _tablename;
            this.fields = _fields;
            this.orderfield = _orderfield;
            this.pagesize = _pagesize;
            this.pageIndex = _pageIndex;
            this.Sqlwhere = _sqlwhere;
            this.ordertype = _ordertype;

        }
        public PageInfoNew(string _tablename, string _fields, string _orderfield, string _sqlwhere, int _pagesize, int _pageIndex, string _fieldkey)
        {
            this.tablename = _tablename;
            this.fields = _fields;
            this.orderfield = _orderfield;
            this.pagesize = _pagesize;
            this.pageIndex = _pageIndex;
            this.Sqlwhere = _sqlwhere;
            this.fieldkey =_fieldkey;
        }
        public PageInfoNew()
        { }
    }

    public class QueryCenterReport
    {

        private string _TableName;

        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _sqlWhere;

        public string SqlWhere
        {
            get { return _sqlWhere; }
            set { _sqlWhere = value; }
        }
        private int _pageSize = 15;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
        private int _pageIndex = 1;

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }
        private int _totalRecord;

        public int TotalRecord
        {
            get { return _totalRecord; }
            set { _totalRecord = value; }
        }

      
    }
}
