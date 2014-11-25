using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_VoucherEncodingRule
    {
        public SYS_VoucherEncodingRule()
        {
            this.SYS_VoucherData = new List<SYS_VoucherData>();
        }

        public int VoucherEncodingRuleId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string BillType { get; set; }
        public string Prefix { get; set; }
        public int SequenceNumberLength { get; set; }
        public int SequenceNumberStartValue { get; set; }
        public string CodeModeType { get; set; }
        public Nullable<int> YearLength { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
        public virtual ORG_Store ORG_Store { get; set; }
        public virtual ICollection<SYS_VoucherData> SYS_VoucherData { get; set; }
    }
}
