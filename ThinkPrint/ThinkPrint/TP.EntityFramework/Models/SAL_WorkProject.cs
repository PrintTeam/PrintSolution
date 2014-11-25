using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SAL_WorkProject
    {
        public SAL_WorkProject()
        {
            this.PMW_ProcessRequirement = new List<PMW_ProcessRequirement>();
            this.SAL_WorkProjectDetail = new List<SAL_WorkProjectDetail>();
        }

        public int WorkProjectId { get; set; }
        public int UnitId { get; set; }
        public int OrderId { get; set; }
        public string ProjectName { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Standard { get; set; }
        public string ProjectType { get; set; }
        public string PartsType { get; set; }
        public Nullable<int> PNumber { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PMW_ProcessRequirement> PMW_ProcessRequirement { get; set; }
        public virtual SAL_Order SAL_Order { get; set; }
        public virtual ICollection<SAL_WorkProjectDetail> SAL_WorkProjectDetail { get; set; }
        public virtual SYS_Unit SYS_Unit { get; set; }
    }
}
