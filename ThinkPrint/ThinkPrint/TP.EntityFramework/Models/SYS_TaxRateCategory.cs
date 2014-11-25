using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_TaxRateCategory
    {
        public int TaxRateCategoryId { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
