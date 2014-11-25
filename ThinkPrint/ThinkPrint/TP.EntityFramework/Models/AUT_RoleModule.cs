using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class AUT_RoleModule
    {
        public AUT_RoleModule()
        {
            this.AUT_RoleModuleMenu = new List<AUT_RoleModuleMenu>();
        }

        public int RoleModuleId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string AuthorizedPerson { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual AUT_Role AUT_Role { get; set; }
        public virtual ICollection<AUT_RoleModuleMenu> AUT_RoleModuleMenu { get; set; }
        public virtual SYS_Module SYS_Module { get; set; }
    }
}
