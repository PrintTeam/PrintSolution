using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingSalePriceList {

    public interface IPrintingSalePriceListService {
        BPM_PrintingSalePriceList GetPrintingSalePriceList(int  PrintingSalePriceId);
        List<BPM_PrintingSalePriceList> GetPrintingSalePriceLists();
        PagedList<BPM_PrintingSalePriceList> GetPrintingSalePriceLists(int pageIndex, int pageSize, string searchKey = null);
        void InsertPrintingSalePriceList(BPM_PrintingSalePriceList PrintingSalePriceList);
        void UpdatePrintingSalePriceList(BPM_PrintingSalePriceList PrintingSalePriceList);
        void DeletePrintingSalePriceList(BPM_PrintingSalePriceList PrintingSalePriceList);
    }
}

