using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.TaxRateCategory {
    public interface ITaxRateCategoryService {

        SYS_TaxRateCategory GetTaxRateCategory(int categoryID);
        List<SYS_TaxRateCategory> GetTaxRateCategorys();
        PagedList<SYS_TaxRateCategory> GetTaxRateCategorys(int pageIndex, int pageSize, string searchKey = null);
        void InsertTaxRateCategory(SYS_TaxRateCategory category);
        void UpdateTaxRateCategory(SYS_TaxRateCategory category);
        void DeleteTaxRateCategory(SYS_TaxRateCategory category);
    }
}
