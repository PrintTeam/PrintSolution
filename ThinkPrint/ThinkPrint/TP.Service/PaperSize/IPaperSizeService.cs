using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PaperSize {

    public interface IPaperSizeService {
        BOM_PaperSize GetPaperSize(int  PaperSizeId);
        BOM_PaperSize GetPaperSize(String UniqueCode);
        List<BOM_PaperSize> GetPaperSizes();
        PagedList<BOM_PaperSize> GetPaperSizes(int pageIndex, int pageSize, string searchKey = null);
        void InsertPaperSize(BOM_PaperSize PaperSize);
        void UpdatePaperSize(BOM_PaperSize PaperSize);
        void DeletePaperSize(BOM_PaperSize PaperSize);
    }
}

