using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingPriceRangeList {

    public interface IPrintingPriceRangeListService {
        BPM_PrintingPriceRangeList GetPrintingPriceRangeList(int  PrintingPriceRangeId);
        List<BPM_PrintingPriceRangeList> GetPrintingPriceRangeLists();
        PagedList<BPM_PrintingPriceRangeList> GetPrintingPriceRangeLists(int pageIndex, int pageSize);
        void InsertPrintingPriceRangeList(BPM_PrintingPriceRangeList PrintingPriceRangeList);
        void UpdatePrintingPriceRangeList(BPM_PrintingPriceRangeList PrintingPriceRangeList);
        void DeletePrintingPriceRangeList(BPM_PrintingPriceRangeList PrintingPriceRangeList);
    }
}

