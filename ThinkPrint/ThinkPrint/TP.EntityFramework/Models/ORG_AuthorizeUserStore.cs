using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_AuthorizeUserStore
    {
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public string AuthorizedPerson { get; set; }
        public bool IsStoreManager { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public virtual AUT_User AUT_User { get; set; }
        public virtual ORG_Store ORG_Store { get; set; }
    }
}
