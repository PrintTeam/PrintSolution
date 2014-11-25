using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class BOM_PaperCategory
    {
        public BOM_PaperCategory()
        {
            this.BOM_Paper = new List<BOM_Paper>();
        }

        public int PaperCategoryId { get; set; }
        public string UniqueCode { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<BOM_Paper> BOM_Paper { get; set; }
    }
}
