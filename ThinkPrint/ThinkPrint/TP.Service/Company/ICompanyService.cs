using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Company {

    public interface ICompanyService {
        ORG_Company GetCompany(int  CompanyId);
        List<ORG_Company> GetCompanys();
        PagedList<ORG_Company> GetCompanys(int pageIndex, int pageSize, string searchKey = null);
        void InsertCompany(ORG_Company Company);
        void UpdateCompany(ORG_Company Company);
        void DeleteCompany(ORG_Company Company);
    }
}

