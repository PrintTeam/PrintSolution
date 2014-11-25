using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM_MembershipCard
    {
        public CRM_MembershipCard()
        {
            this.CRM__PostRegisterCard = new List<CRM__PostRegisterCard>();
            this.CRM_CardConsumption = new List<CRM_CardConsumption>();
            this.CRM_CardRecharge = new List<CRM_CardRecharge>();
            this.CRM_MembershipUnfreeze = new List<CRM_MembershipUnfreeze>();
            this.CRM_MembershipFreeze = new List<CRM_MembershipFreeze>();
        }

        public int MembershipCardId { get; set; }
        public int MembershipCardCategoryId { get; set; }
        public int StoreId { get; set; }
        public string UniqueCode { get; set; }
        public string CardNumber { get; set; }
        public int CreditRating { get; set; }
        public string Cardholder { get; set; }
        public bool Sex { get; set; }
        public string MobilePhone { get; set; }
        public string Telephone { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> QQ { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CardPassword { get; set; }
        public string CredentialsType { get; set; }
        public string CredentialsNum { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal PresenterAmount { get; set; }
        public decimal Deposit { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public string OperatorPerson { get; set; }
        public string CardStatus { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<CRM__PostRegisterCard> CRM__PostRegisterCard { get; set; }
        public virtual ICollection<CRM_CardConsumption> CRM_CardConsumption { get; set; }
        public virtual ICollection<CRM_CardRecharge> CRM_CardRecharge { get; set; }
        public virtual ICollection<CRM_MembershipUnfreeze> CRM_MembershipUnfreeze { get; set; }
        public virtual CRM_MembershipCardCategory CRM_MembershipCardCategory { get; set; }
        public virtual ICollection<CRM_MembershipFreeze> CRM_MembershipFreeze { get; set; }
        public virtual ORG_Store ORG_Store { get; set; }
    }
}
