using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_PostpressPriceRangeList
    {
        public PMW_PostpressPriceRangeList()
        {
            this.BPM_PostpressAgreementPriceList = new List<BPM_PostpressAgreementPriceList>();
            this.BPM_PostpressSalePriceList = new List<BPM_PostpressSalePriceList>();
            this.PMW_PostpressMembershipPriceList = new List<PMW_PostpressMembershipPriceList>();
        }

        public int PostpressPriceRangeId { get; set; }
        public int PostpressProcessId { get; set; }
        public int UnitId { get; set; }
        public int Form { get; set; }
        public Nullable<int> To { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BPM_PostpressAgreementPriceList> BPM_PostpressAgreementPriceList { get; set; }
        public virtual ICollection<BPM_PostpressSalePriceList> BPM_PostpressSalePriceList { get; set; }
        public virtual ICollection<PMW_PostpressMembershipPriceList> PMW_PostpressMembershipPriceList { get; set; }
        public virtual PMW_PostpressProcess PMW_PostpressProcess { get; set; }
        public virtual SYS_Unit SYS_Unit { get; set; }
    }
}
