using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM_CardConsumption
    {
        public int CardConsumptionId { get; set; }
        public int MembershipCardId { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<decimal> ConsumptionAmount { get; set; }
        public string OperatorStoresCode { get; set; }
        public string OperatorPerson { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual CRM_MembershipCard CRM_MembershipCard { get; set; }
    }
}
