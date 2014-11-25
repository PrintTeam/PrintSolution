using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_Menu
    {
        public SYS_Menu()
        {
            this.AUT_RoleModuleMenu = new List<AUT_RoleModuleMenu>();
            this.SYS_MenuFunction = new List<SYS_MenuFunction>();
            this.SYS_Menu1 = new List<SYS_Menu>();
        }

        public int MenuId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Target { get; set; }
        public int MenuType { get; set; }
        public string Icon { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<AUT_RoleModuleMenu> AUT_RoleModuleMenu { get; set; }
        public virtual ICollection<SYS_MenuFunction> SYS_MenuFunction { get; set; }
        public virtual ICollection<SYS_Menu> SYS_Menu1 { get; set; }
        public virtual SYS_Menu SYS_Menu2 { get; set; }
        public virtual SYS_Module SYS_Module { get; set; }
    }
}
