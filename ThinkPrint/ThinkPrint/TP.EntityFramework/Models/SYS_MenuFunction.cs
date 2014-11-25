using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_MenuFunction
    {
        public SYS_MenuFunction()
        {
            this.AUT_RoleMenuFunction = new List<AUT_RoleMenuFunction>();
        }

        public int MenuFunctionId { get; set; }
        public int MenuId { get; set; }
        public int FunctionId { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<AUT_RoleMenuFunction> AUT_RoleMenuFunction { get; set; }
        public virtual SYS_Function SYS_Function { get; set; }
        public virtual SYS_Menu SYS_Menu { get; set; }
    }
}
