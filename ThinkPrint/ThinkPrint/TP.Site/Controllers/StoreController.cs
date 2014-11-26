using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Site.Helper;
using TP.Site.Models.Organization;
using TP.Web.Framework.Mvc;
using TP.Service.Store;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    public class StoreController : Controller {

        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService) {
            _storeService = storeService;
        }
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<ORG_Store> dataSource = _storeService.GetStoreList(pageIndex, SysConstant.Page_PageSize, searchKey);
            StoreListModel model = new StoreListModel();
            model.ViewList = dataSource;
            model.PageTitle = "店铺信息";
            model.PageSubTitle = "查看和维护所有的店铺信息";
            return View(model);           
        }
    }
}