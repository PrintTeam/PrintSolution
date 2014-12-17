using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.CardConsumption {

    public interface ICardConsumptionService {
        CRM_CardConsumption GetCardConsumption(int  CardConsumptionId);
        List<CRM_CardConsumption> GetCardConsumptions();
        PagedList<CRM_CardConsumption> GetCardConsumptions(int pageIndex, int pageSize, string searchKey = null);
        void InsertCardConsumption(CRM_CardConsumption CardConsumption);
        void UpdateCardConsumption(CRM_CardConsumption CardConsumption);
        void DeleteCardConsumption(CRM_CardConsumption CardConsumption);
    }
}

