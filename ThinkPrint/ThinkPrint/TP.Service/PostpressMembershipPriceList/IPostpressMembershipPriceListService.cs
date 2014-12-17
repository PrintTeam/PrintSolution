using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressMembershipPriceList {

    public interface IPostpressMembershipPriceListService {
        PMW_PostpressMembershipPriceList GetPostpressMembershipPriceList(int  PostpressMembershipPriceId);
        List<PMW_PostpressMembershipPriceList> GetPostpressMembershipPriceLists();
        PagedList<PMW_PostpressMembershipPriceList> GetPostpressMembershipPriceLists(int pageIndex, int pageSize, string searchKey = null);
        void InsertPostpressMembershipPriceList(PMW_PostpressMembershipPriceList PostpressMembershipPriceList);
        void UpdatePostpressMembershipPriceList(PMW_PostpressMembershipPriceList PostpressMembershipPriceList);
        void DeletePostpressMembershipPriceList(PMW_PostpressMembershipPriceList PostpressMembershipPriceList);
    }
}

