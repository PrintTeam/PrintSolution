using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM_CardRecharge
    {
        public int CardRechargeId { get; set; }
        public int MembershipCardId { get; set; }
        public decimal CreditsAmount { get; set; }
        public string OperatorStoresCode { get; set; }
        public string Payee { get; set; }
        public decimal PresenterAmount { get; set; }
        public string PresenterReason { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual CRM_MembershipCard CRM_MembershipCard { get; set; }
    }
}
