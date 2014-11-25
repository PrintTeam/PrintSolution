using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class BUS_BusinessCategory
    {
        public BUS_BusinessCategory()
        {
            this.BUS_BusinessComponent = new List<BUS_BusinessComponent>();
        }

        public int BusinessCategoryId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string BusinessType { get; set; }
        public string MnemonicCode { get; set; }
        public string Description { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<BUS_BusinessComponent> BUS_BusinessComponent { get; set; }
    }
}
