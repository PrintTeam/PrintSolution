using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class AUT_User
    {
        public AUT_User()
        {
            this.AUT_UserRole = new List<AUT_UserRole>();
            this.ORG_AuthorizeUserStore = new List<ORG_AuthorizeUserStore>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<AUT_UserRole> AUT_UserRole { get; set; }
        public virtual ICollection<ORG_AuthorizeUserStore> ORG_AuthorizeUserStore { get; set; }
    }
}
