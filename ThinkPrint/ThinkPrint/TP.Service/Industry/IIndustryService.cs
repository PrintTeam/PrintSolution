using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Industry {

    public interface IIndustryService {
        SYS_Industry GetIndustry(int  IndustryId);
        List<SYS_Industry> GetIndustrys();
        PagedList<SYS_Industry> GetIndustrys(int pageIndex, int pageSize, string searchKey = null);
        void InsertIndustry(SYS_Industry Industry);
        void UpdateIndustry(SYS_Industry Industry);
        void DeleteIndustry(SYS_Industry Industry);
    }
}

