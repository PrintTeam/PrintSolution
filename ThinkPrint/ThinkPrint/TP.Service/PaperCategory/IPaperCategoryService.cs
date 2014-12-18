using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PaperCategory {

    public interface IPaperCategoryService {
        BOM_PaperCategory GetPaperCategory(int  PaperCategoryId);
        BOM_PaperCategory GetPaperCategory(String UniqueCode);
        List<BOM_PaperCategory> GetPaperCategorys();
        PagedList<BOM_PaperCategory> GetPaperCategorys(int pageIndex, int pageSize, string searchKey = null);
        void InsertPaperCategory(BOM_PaperCategory PaperCategory);
        void UpdatePaperCategory(BOM_PaperCategory PaperCategory);
        void DeletePaperCategory(BOM_PaperCategory PaperCategory);
    }
}

