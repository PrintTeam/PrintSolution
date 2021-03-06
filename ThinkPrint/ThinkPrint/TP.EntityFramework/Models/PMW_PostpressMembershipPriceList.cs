using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_PostpressMembershipPriceList
    {
        public int PostpressMembershipPriceId { get; set; }
        public int PostpressPriceRangeId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public string OperatorPerson { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsEnabled { get; set; }
        public virtual PMW_PostpressPriceRangeList PMW_PostpressPriceRangeList { get; set; }
    }
}
