using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM_MembershipUnfreeze
    {
        public int MembershipUnfreezeId { get; set; }
        public int MembershipCardId { get; set; }
        public string UnfreezeReason { get; set; }
        public string OperatorStoresCode { get; set; }
        public string OperatorPerson { get; set; }
        public string ApprovedPerson { get; set; }
        public System.DateTime ApprovedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual CRM_MembershipCard CRM_MembershipCard { get; set; }
    }
}
