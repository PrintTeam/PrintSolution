using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.BusinessComponent {

    public interface IBusinessComponentService {
        BUS_BusinessComponent GetBusinessComponent(int  BusinessComponentId);
        List<BUS_BusinessComponent> GetBusinessComponents();
        PagedList<BUS_BusinessComponent> GetBusinessComponents(int pageIndex, int pageSize);
        void InsertBusinessComponent(BUS_BusinessComponent BusinessComponent);
        void UpdateBusinessComponent(BUS_BusinessComponent BusinessComponent);
        void DeleteBusinessComponent(BUS_BusinessComponent BusinessComponent);
    }
}

