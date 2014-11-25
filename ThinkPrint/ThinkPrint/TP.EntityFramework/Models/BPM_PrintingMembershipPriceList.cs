using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class BPM_PrintingMembershipPriceList
    {
        public int PrintingMembershipPriceId { get; set; }
        public int PrintingPriceRangeId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public string OperatorPerson { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsEnabled { get; set; }
        public virtual BPM_PrintingPriceRangeList BPM_PrintingPriceRangeList { get; set; }
    }
}
