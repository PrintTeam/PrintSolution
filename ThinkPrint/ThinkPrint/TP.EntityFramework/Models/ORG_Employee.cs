using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_Employee
    {
        public ORG_Employee()
        {
            this.ORG_EmployeeDepartmentHistory = new List<ORG_EmployeeDepartmentHistory>();
            this.ORG_Employee1 = new List<ORG_Employee>();
        }

        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public string Name { get; set; }
        public string JobNumber { get; set; }
        public string CredentialsNum { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; }
        public int Age { get; set; }
        public string MobilePhone { get; set; }
        public string Status { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<System.DateTime> LeaveDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ORG_Department ORG_Department { get; set; }
        public virtual ICollection<ORG_EmployeeDepartmentHistory> ORG_EmployeeDepartmentHistory { get; set; }
        public virtual ICollection<ORG_Employee> ORG_Employee1 { get; set; }
        public virtual ORG_Employee ORG_Employee2 { get; set; }
        public virtual ORG_Store ORG_Store { get; set; }
    }
}
