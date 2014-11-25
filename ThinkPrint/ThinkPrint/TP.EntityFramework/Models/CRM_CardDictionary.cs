using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class CRM_CardDictionary
    {
        public System.Guid RowGuid { get; set; }
        public string CardNumber { get; set; }
        public string CardIMEI { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAbandoned { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
