using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class BOM_Paper
    {
        public int PaperId { get; set; }
        public int PaperCategoryId { get; set; }
        public int PaperSizeId { get; set; }
        public string Name { get; set; }
        public string PartsAttributeCode { get; set; }
        public string MnemonicCode { get; set; }
        public decimal Weight { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public virtual BOM_PaperSize BOM_PaperSize { get; set; }
        public virtual BOM_PaperCategory BOM_PaperCategory { get; set; }
    }
}
