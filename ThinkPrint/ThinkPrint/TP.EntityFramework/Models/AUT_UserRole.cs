using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class AUT_UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual AUT_Role AUT_Role { get; set; }
        public virtual AUT_User AUT_User { get; set; }
    }
}
