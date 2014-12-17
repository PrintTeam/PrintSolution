using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.OrderRemindSetting {

    public interface IOrderRemindSettingService {
        SYS_OrderRemindSetting GetOrderRemindSetting(int  OrderRemindId);
        List<SYS_OrderRemindSetting> GetOrderRemindSettings();
        PagedList<SYS_OrderRemindSetting> GetOrderRemindSettings(int pageIndex, int pageSize);
        void InsertOrderRemindSetting(SYS_OrderRemindSetting OrderRemindSetting);
        void UpdateOrderRemindSetting(SYS_OrderRemindSetting OrderRemindSetting);
        void DeleteOrderRemindSetting(SYS_OrderRemindSetting OrderRemindSetting);
    }
}

