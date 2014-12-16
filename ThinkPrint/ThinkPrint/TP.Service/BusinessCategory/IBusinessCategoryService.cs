using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.BusinessCategory {

    public interface IBusinessCategoryService {
        BUS_BusinessCategory GetBusinessCategory(int  BusinessCategoryId);
        List<BUS_BusinessCategory> GetBusinessCategorys();
        PagedList<BUS_BusinessCategory> GetBusinessCategorys(int pageIndex, int pageSize, string searchKey = null);
        void InsertBusinessCategory(BUS_BusinessCategory BusinessCategory);
        void UpdateBusinessCategory(BUS_BusinessCategory BusinessCategory);
        void DeleteBusinessCategory(BUS_BusinessCategory BusinessCategory);
    }
}

