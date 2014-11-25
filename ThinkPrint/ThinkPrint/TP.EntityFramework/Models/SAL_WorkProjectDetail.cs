using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SAL_WorkProjectDetail
    {
        public int WorkProjectDetailId { get; set; }
        public int WorkProjectId { get; set; }
        public int BusinessComponentId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual BUS_BusinessComponent BUS_BusinessComponent { get; set; }
        public virtual SAL_WorkProject SAL_WorkProject { get; set; }
    }
}
