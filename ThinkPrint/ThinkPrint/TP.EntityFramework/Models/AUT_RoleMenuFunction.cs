using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class AUT_RoleMenuFunction
    {
        public int RoleMenuFunctionId { get; set; }
        public int MenuFunctionId { get; set; }
        public int RoleModuleMenuId { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual AUT_RoleModuleMenu AUT_RoleModuleMenu { get; set; }
        public virtual SYS_MenuFunction SYS_MenuFunction { get; set; }
    }
}
