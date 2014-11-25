using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_EmployeeDepartmentHistory
    {
        public int ShiftId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ORG_Department ORG_Department { get; set; }
        public virtual ORG_Employee ORG_Employee { get; set; }
        public virtual ORG_Shift ORG_Shift { get; set; }
    }
}
