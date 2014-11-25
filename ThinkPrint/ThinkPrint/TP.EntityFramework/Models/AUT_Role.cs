using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class AUT_Role
    {
        public AUT_Role()
        {
            this.AUT_RoleModule = new List<AUT_RoleModule>();
            this.AUT_UserRole = new List<AUT_UserRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AUT_RoleModule> AUT_RoleModule { get; set; }
        public virtual ICollection<AUT_UserRole> AUT_UserRole { get; set; }
    }
}
