using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.CardRecharge {

    public interface ICardRechargeService {
        CRM_CardRecharge GetCardRecharge(int  CardRechargeId);
        List<CRM_CardRecharge> GetCardRecharges();
        PagedList<CRM_CardRecharge> GetCardRecharges(int pageIndex, int pageSize, string searchKey = null);
        void InsertCardRecharge(CRM_CardRecharge CardRecharge);
        void UpdateCardRecharge(CRM_CardRecharge CardRecharge);
        void DeleteCardRecharge(CRM_CardRecharge CardRecharge);
    }
}

