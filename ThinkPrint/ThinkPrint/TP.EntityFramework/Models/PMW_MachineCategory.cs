using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class PMW_MachineCategory
    {
        public PMW_MachineCategory()
        {
            this.PMW_Machine = new List<PMW_Machine>();
        }

        public int MachineCategoryId { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<PMW_Machine> PMW_Machine { get; set; }
    }
}
