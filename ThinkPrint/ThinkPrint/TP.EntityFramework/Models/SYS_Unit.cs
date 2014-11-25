using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_Unit
    {
        public SYS_Unit()
        {
            this.BPM_PrintingPriceRangeList = new List<BPM_PrintingPriceRangeList>();
            this.PMW_PostpressPriceRangeList = new List<PMW_PostpressPriceRangeList>();
            this.SAL_WorkProject = new List<SAL_WorkProject>();
        }

        public int UnitId { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<BPM_PrintingPriceRangeList> BPM_PrintingPriceRangeList { get; set; }
        public virtual ICollection<PMW_PostpressPriceRangeList> PMW_PostpressPriceRangeList { get; set; }
        public virtual ICollection<SAL_WorkProject> SAL_WorkProject { get; set; }
    }
}
