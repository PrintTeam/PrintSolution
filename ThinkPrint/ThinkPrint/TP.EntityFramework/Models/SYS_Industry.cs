using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_Industry
    {
        public SYS_Industry()
        {
            this.SAL_Customer = new List<SAL_Customer>();
        }

        public int IndustryId { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SAL_Customer> SAL_Customer { get; set; }
    }
}
