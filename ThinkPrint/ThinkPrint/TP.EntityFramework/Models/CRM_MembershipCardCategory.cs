using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM_MembershipCardCategory
    {
        public CRM_MembershipCardCategory()
        {
            this.CRM_MembershipCard = new List<CRM_MembershipCard>();
        }

        public int MembershipCardCategoryId { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<CRM_MembershipCard> CRM_MembershipCard { get; set; }
    }
}
