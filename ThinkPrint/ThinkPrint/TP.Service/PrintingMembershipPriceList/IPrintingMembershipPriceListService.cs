using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingMembershipPriceList {

    public interface IPrintingMembershipPriceListService {
        BPM_PrintingMembershipPriceList GetPrintingMembershipPriceList(int  PrintingMembershipPriceId);
        List<BPM_PrintingMembershipPriceList> GetPrintingMembershipPriceLists();
        PagedList<BPM_PrintingMembershipPriceList> GetPrintingMembershipPriceLists(int pageIndex, int pageSize, string searchKey = null);
        void InsertPrintingMembershipPriceList(BPM_PrintingMembershipPriceList PrintingMembershipPriceList);
        void UpdatePrintingMembershipPriceList(BPM_PrintingMembershipPriceList PrintingMembershipPriceList);
        void DeletePrintingMembershipPriceList(BPM_PrintingMembershipPriceList PrintingMembershipPriceList);
    }
}

