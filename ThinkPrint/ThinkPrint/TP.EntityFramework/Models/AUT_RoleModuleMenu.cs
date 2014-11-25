using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class AUT_RoleModuleMenu
    {
        public AUT_RoleModuleMenu()
        {
            this.AUT_RoleMenuFunction = new List<AUT_RoleMenuFunction>();
        }

        public int RoleModuleMenuId { get; set; }
        public Nullable<int> RoleModuleId { get; set; }
        public int MenuId { get; set; }
        public string AuthorizedPerson { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<AUT_RoleMenuFunction> AUT_RoleMenuFunction { get; set; }
        public virtual AUT_RoleModule AUT_RoleModule { get; set; }
        public virtual SYS_Menu SYS_Menu { get; set; }
    }
}
