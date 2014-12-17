using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressSalePriceList {

    public interface IPostpressSalePriceListService {
        BPM_PostpressSalePriceList GetPostpressSalePriceList(int  PostpressSalePriceId);
        List<BPM_PostpressSalePriceList> GetPostpressSalePriceLists();
        PagedList<BPM_PostpressSalePriceList> GetPostpressSalePriceLists(int pageIndex, int pageSize, string searchKey = null);
        void InsertPostpressSalePriceList(BPM_PostpressSalePriceList PostpressSalePriceList);
        void UpdatePostpressSalePriceList(BPM_PostpressSalePriceList PostpressSalePriceList);
        void DeletePostpressSalePriceList(BPM_PostpressSalePriceList PostpressSalePriceList);
    }
}

