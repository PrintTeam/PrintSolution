using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SAL_Customer
    {
        public SAL_Customer()
        {
            this.BPM_PostpressAgreementPriceList = new List<BPM_PostpressAgreementPriceList>();
            this.BPM_PrintingAgreementPriceList = new List<BPM_PrintingAgreementPriceList>();
            this.SAL_Order = new List<SAL_Order>();
        }

        public int CustomerId { get; set; }
        public int IndustryId { get; set; }
        public string Name { get; set; }
        public string MembershipCode { get; set; }
        public string Cardholder { get; set; }
        public string CardNumber { get; set; }
        public string CustomerType { get; set; }
        public string UniqueCode { get; set; }
        public string MnemonicCode { get; set; }
        public bool Sex { get; set; }
        public string MobilePhone { get; set; }
        public string Telephone { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public Nullable<int> QQ { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public int CreditRating { get; set; }
        public bool IsCreditCard { get; set; }
        public Nullable<decimal> MaximumAmount { get; set; }
        public string SalePriceType { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<BPM_PostpressAgreementPriceList> BPM_PostpressAgreementPriceList { get; set; }
        public virtual ICollection<BPM_PrintingAgreementPriceList> BPM_PrintingAgreementPriceList { get; set; }
        public virtual SYS_Industry SYS_Industry { get; set; }
        public virtual ICollection<SAL_Order> SAL_Order { get; set; }
    }
}
