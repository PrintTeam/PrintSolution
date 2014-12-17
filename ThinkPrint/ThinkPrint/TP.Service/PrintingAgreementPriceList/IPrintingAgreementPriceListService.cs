using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingAgreementPriceList {

    public interface IPrintingAgreementPriceListService {
        BPM_PrintingAgreementPriceList GetPrintingAgreementPriceList(int  PrintingAgreementPriceId);
        List<BPM_PrintingAgreementPriceList> GetPrintingAgreementPriceLists();
        PagedList<BPM_PrintingAgreementPriceList> GetPrintingAgreementPriceLists(int pageIndex, int pageSize, string searchKey = null);
        void InsertPrintingAgreementPriceList(BPM_PrintingAgreementPriceList PrintingAgreementPriceList);
        void UpdatePrintingAgreementPriceList(BPM_PrintingAgreementPriceList PrintingAgreementPriceList);
        void DeletePrintingAgreementPriceList(BPM_PrintingAgreementPriceList PrintingAgreementPriceList);
    }
}

