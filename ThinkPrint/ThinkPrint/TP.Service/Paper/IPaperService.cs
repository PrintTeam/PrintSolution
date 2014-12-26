using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Paper {

    public interface IPaperService {
        BOM_Paper GetPaper(int  PaperId);
        List<BOM_Paper> GetPapers();
        PagedList<BOM_Paper> GetPapers(int pageIndex, int pageSize, string searchKey = null);
        void InsertPaper(BOM_Paper Paper);
        void UpdatePaper(BOM_Paper Paper);
        void DeletePaper(BOM_Paper Paper);
    }
    
}

