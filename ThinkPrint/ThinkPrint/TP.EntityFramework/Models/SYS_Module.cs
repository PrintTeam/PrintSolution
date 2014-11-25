using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_Module
    {
        public SYS_Module()
        {
            this.AUT_RoleModule = new List<AUT_RoleModule>();
            this.SYS_Menu = new List<SYS_Menu>();
        }

        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Icon { get; set; }
        public string DefaultPage { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<AUT_RoleModule> AUT_RoleModule { get; set; }
        public virtual ICollection<SYS_Menu> SYS_Menu { get; set; }
    }
}
