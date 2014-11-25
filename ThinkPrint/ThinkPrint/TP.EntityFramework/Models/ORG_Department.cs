using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_Department
    {
        public ORG_Department()
        {
            this.ORG_EmployeeDepartmentHistory = new List<ORG_EmployeeDepartmentHistory>();
            this.ORG_Employee = new List<ORG_Employee>();
        }

        public int DepartmentId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ORG_Company ORG_Company { get; set; }
        public virtual ICollection<ORG_EmployeeDepartmentHistory> ORG_EmployeeDepartmentHistory { get; set; }
        public virtual ICollection<ORG_Employee> ORG_Employee { get; set; }
    }
}
