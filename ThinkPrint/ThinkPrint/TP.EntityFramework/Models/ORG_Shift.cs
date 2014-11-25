using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_Shift
    {
        public ORG_Shift()
        {
            this.ORG_EmployeeDepartmentHistory = new List<ORG_EmployeeDepartmentHistory>();
        }

        public int ShiftId { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<ORG_EmployeeDepartmentHistory> ORG_EmployeeDepartmentHistory { get; set; }
    }
}
