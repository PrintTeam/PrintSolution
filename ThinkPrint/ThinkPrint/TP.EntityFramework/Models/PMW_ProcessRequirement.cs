using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_ProcessRequirement
    {
        public int ProcessRequirementId { get; set; }
        public int WorkProjectId { get; set; }
        public string Name { get; set; }
        public string ProcessType { get; set; }
        public string Illustrate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual SAL_WorkProject SAL_WorkProject { get; set; }
    }
}
