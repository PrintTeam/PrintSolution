using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_PostpressProcess
    {
        public PMW_PostpressProcess()
        {
            this.BUS_BusinessComponent = new List<BUS_BusinessComponent>();
            this.PMW_PostpressPriceRangeList = new List<PMW_PostpressPriceRangeList>();
        }

        public int PostpressProcessId { get; set; }
        public int MachineId { get; set; }
        public string ProcessType { get; set; }
        public string Name { get; set; }
        public string UniqueCode { get; set; }
        public string ShortName { get; set; }
        public string MnemonicCode { get; set; }
        public string SideProperty { get; set; }
        public int PricingModels { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<BUS_BusinessComponent> BUS_BusinessComponent { get; set; }
        public virtual PMW_Machine PMW_Machine { get; set; }
        public virtual ICollection<PMW_PostpressPriceRangeList> PMW_PostpressPriceRangeList { get; set; }
    }
}
