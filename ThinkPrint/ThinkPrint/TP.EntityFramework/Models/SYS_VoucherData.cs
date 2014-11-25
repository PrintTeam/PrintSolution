using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_VoucherData
    {
        public int VoucherDataId { get; set; }
        public int VoucherEncodingRuleId { get; set; }
        public string CurrentValue { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual SYS_VoucherEncodingRule SYS_VoucherEncodingRule { get; set; }
    }
}
