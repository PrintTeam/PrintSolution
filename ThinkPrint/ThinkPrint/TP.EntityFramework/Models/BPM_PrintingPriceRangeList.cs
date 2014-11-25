using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class BPM_PrintingPriceRangeList
    {
        public BPM_PrintingPriceRangeList()
        {
            this.BPM_PrintingAgreementPriceList = new List<BPM_PrintingAgreementPriceList>();
            this.BPM_PrintingMembershipPriceList = new List<BPM_PrintingMembershipPriceList>();
            this.BPM_PrintingSalePriceList = new List<BPM_PrintingSalePriceList>();
        }

        public int PrintingPriceRangeId { get; set; }
        public int PrintingProcessId { get; set; }
        public int UnitId { get; set; }
        public int Form { get; set; }
        public Nullable<int> To { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<BPM_PrintingAgreementPriceList> BPM_PrintingAgreementPriceList { get; set; }
        public virtual ICollection<BPM_PrintingMembershipPriceList> BPM_PrintingMembershipPriceList { get; set; }
        public virtual ICollection<BPM_PrintingSalePriceList> BPM_PrintingSalePriceList { get; set; }
        public virtual PMW_PrintingProcess PMW_PrintingProcess { get; set; }
        public virtual SYS_Unit SYS_Unit { get; set; }
    }
}
