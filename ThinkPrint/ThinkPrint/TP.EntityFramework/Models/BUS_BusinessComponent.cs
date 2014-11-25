using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class BUS_BusinessComponent
    {
        public BUS_BusinessComponent()
        {
            this.SAL_WorkProjectDetail = new List<SAL_WorkProjectDetail>();
        }

        public int BusinessComponentId { get; set; }
        public int BusinessCategoryId { get; set; }
        public Nullable<int> PrintingProcessId { get; set; }
        public Nullable<int> PostpressProcessId { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public virtual BUS_BusinessCategory BUS_BusinessCategory { get; set; }
        public virtual PMW_PostpressProcess PMW_PostpressProcess { get; set; }
        public virtual PMW_PrintingProcess PMW_PrintingProcess { get; set; }
        public virtual ICollection<SAL_WorkProjectDetail> SAL_WorkProjectDetail { get; set; }
    }
}
