using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class ORG_Company
    {
        public ORG_Company()
        {
            this.ORG_Department = new List<ORG_Department>();
            this.ORG_Store = new List<ORG_Store>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Address { get; set; }
        public string FaxNumber { get; set; }
        public string Telephone { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<ORG_Department> ORG_Department { get; set; }
        public virtual ICollection<ORG_Store> ORG_Store { get; set; }
    }
}
