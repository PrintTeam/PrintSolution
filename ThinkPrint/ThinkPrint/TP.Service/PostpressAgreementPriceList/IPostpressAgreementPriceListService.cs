using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressAgreementPriceList {

    public interface IPostpressAgreementPriceListService {
        BPM_PostpressAgreementPriceList GetPostpressAgreementPriceList(int  PostpressAgreementPriceId);
        List<BPM_PostpressAgreementPriceList> GetPostpressAgreementPriceLists();
        PagedList<BPM_PostpressAgreementPriceList> GetPostpressAgreementPriceLists(int pageIndex, int pageSize, string searchKey = null);
        void InsertPostpressAgreementPriceList(BPM_PostpressAgreementPriceList PostpressAgreementPriceList);
        void UpdatePostpressAgreementPriceList(BPM_PostpressAgreementPriceList PostpressAgreementPriceList);
        void DeletePostpressAgreementPriceList(BPM_PostpressAgreementPriceList PostpressAgreementPriceList);
    }
}

