using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_Store
    {
        public ORG_Store()
        {
            this.CRM_MembershipCard = new List<CRM_MembershipCard>();
            this.ORG_AuthorizeUserStore = new List<ORG_AuthorizeUserStore>();
            this.ORG_Employee = new List<ORG_Employee>();
            this.SYS_VoucherEncodingRule = new List<SYS_VoucherEncodingRule>();
        }

        public int StoreId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string UniqueCode { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string ResponsiblePerson { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<CRM_MembershipCard> CRM_MembershipCard { get; set; }
        public virtual ICollection<ORG_AuthorizeUserStore> ORG_AuthorizeUserStore { get; set; }
        public virtual ORG_Company ORG_Company { get; set; }
        public virtual ICollection<ORG_Employee> ORG_Employee { get; set; }
        public virtual ICollection<SYS_VoucherEncodingRule> SYS_VoucherEncodingRule { get; set; }
    }
}
