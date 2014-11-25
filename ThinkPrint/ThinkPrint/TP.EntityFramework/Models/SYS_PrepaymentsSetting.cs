using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_PrepaymentsSetting
    {
        public int PrepaymentsSettingId { get; set; }
        public decimal OrderMinAmount { get; set; }
        public decimal OrderMaxAmount { get; set; }
        public decimal PrepaymentsAmount { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
    }
}
