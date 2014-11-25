using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_SysSetting
    {
        public System.Guid RowGuid { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string TitleCode { get; set; }
        public string UniqueCode { get; set; }
        public string ParamValue { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
    }
}
