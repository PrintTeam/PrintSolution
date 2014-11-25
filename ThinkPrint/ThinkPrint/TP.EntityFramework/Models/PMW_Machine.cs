using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_Machine
    {
        public PMW_Machine()
        {
            this.PMW_PostpressProcess = new List<PMW_PostpressProcess>();
            this.PMW_PrintingProcess = new List<PMW_PrintingProcess>();
        }

        public int MachineId { get; set; }
        public int MachineCategoryId { get; set; }
        public string Name { get; set; }
        public string UniqueCode { get; set; }
        public string ShortName { get; set; }
        public string MnemonicCode { get; set; }
        public string MachineType { get; set; }
        public string ColorType { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual PMW_MachineCategory PMW_MachineCategory { get; set; }
        public virtual ICollection<PMW_PostpressProcess> PMW_PostpressProcess { get; set; }
        public virtual ICollection<PMW_PrintingProcess> PMW_PrintingProcess { get; set; }
    }
}
