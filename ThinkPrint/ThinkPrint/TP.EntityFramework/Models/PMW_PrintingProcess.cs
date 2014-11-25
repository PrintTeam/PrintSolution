using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_PrintingProcess
    {
        public PMW_PrintingProcess()
        {
            this.BPM_PrintingPriceRangeList = new List<BPM_PrintingPriceRangeList>();
            this.BUS_BusinessComponent = new List<BUS_BusinessComponent>();
        }

        public int PrintingProcessId { get; set; }
        public int MachineId { get; set; }
        public string ProcessType { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MnemonicCode { get; set; }
        public string PartsAttributeCode { get; set; }
        public string SideProperty { get; set; }
        public string ColorType { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<BPM_PrintingPriceRangeList> BPM_PrintingPriceRangeList { get; set; }
        public virtual ICollection<BUS_BusinessComponent> BUS_BusinessComponent { get; set; }
        public virtual PMW_Machine PMW_Machine { get; set; }
    }
}
