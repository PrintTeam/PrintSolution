using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressPriceRangeList {

    public interface IPostpressPriceRangeListService {
        PMW_PostpressPriceRangeList GetPostpressPriceRangeList(int  PostpressPriceRangeId);
        List<PMW_PostpressPriceRangeList> GetPostpressPriceRangeLists();
        PagedList<PMW_PostpressPriceRangeList> GetPostpressPriceRangeLists(int pageIndex, int pageSize);
        void InsertPostpressPriceRangeList(PMW_PostpressPriceRangeList PostpressPriceRangeList);
        void UpdatePostpressPriceRangeList(PMW_PostpressPriceRangeList PostpressPriceRangeList);
        void DeletePostpressPriceRangeList(PMW_PostpressPriceRangeList PostpressPriceRangeList);
    }
}

