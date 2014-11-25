using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_Function
    {
        public SYS_Function()
        {
            this.SYS_MenuFunction = new List<SYS_MenuFunction>();
        }

        public int FunctionId { get; set; }
        public string Name { get; set; }
        public string ControlCode { get; set; }
        public string ActionEvent { get; set; }
        public string Tooltips { get; set; }
        public string Icon { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<SYS_MenuFunction> SYS_MenuFunction { get; set; }
    }
}
