using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM__PostRegisterCard
    {
        public int PostRegisterCardId { get; set; }
        public int MembershipCardId { get; set; }
        public string QuondamCardNumber { get; set; }
        public decimal Charge { get; set; }
        public string OperatorStoresCode { get; set; }
        public string OperatorPerson { get; set; }
        public System.DateTime HandleDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual CRM_MembershipCard CRM_MembershipCard { get; set; }
    }
}
