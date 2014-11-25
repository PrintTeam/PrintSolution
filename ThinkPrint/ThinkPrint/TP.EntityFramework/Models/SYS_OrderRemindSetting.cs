using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SYS_OrderRemindSetting
    {
        public int OrderRemindId { get; set; }
        public string ReminderType { get; set; }
        public decimal ReminderCycle { get; set; }
        public string ReminderColor { get; set; }
        public decimal OvertimeCycle { get; set; }
        public string OvertimeColor { get; set; }
        public bool EnabledWarning { get; set; }
        public string WarningMessages { get; set; }
        public bool IsDelete { get; set; }
    }
}
