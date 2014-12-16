using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrepaymentsSetting {

    public interface IPrepaymentsSettingService {
        SYS_PrepaymentsSetting GetPrepaymentsSetting(int  PrepaymentsSettingId);
        List<SYS_PrepaymentsSetting> GetPrepaymentsSettings();
        PagedList<SYS_PrepaymentsSetting> GetPrepaymentsSettings(int pageIndex, int pageSize);
        void InsertPrepaymentsSetting(SYS_PrepaymentsSetting PrepaymentsSetting);
        void UpdatePrepaymentsSetting(SYS_PrepaymentsSetting PrepaymentsSetting);
        void DeletePrepaymentsSetting(SYS_PrepaymentsSetting PrepaymentsSetting);
    }
}

