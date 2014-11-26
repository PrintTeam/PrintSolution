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
    public class StoreController : BaseController {

        private readonly IStoreService _storeService;
        private string messages = "";

        public StoreController(IStoreService storeService) {
            _storeService = storeService;
        }
        [HttpGet]
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<ORG_Store> dataSource = _storeService.GetStoreList(pageIndex, SysConstant.Page_PageSize, searchKey);
            StoreListModel model = new StoreListModel();
            model.ViewList = dataSource;
            model.PageTitle = "店铺信息";
            model.PageSubTitle = "查看和维护所有的店铺信息";
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() {
            var model = new StoreModel();
            model.PageTitle = "店铺信息";
            //model.PageSubTitle = "新增或修改店铺信息";
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(StoreModel model) {
            if (ModelState.IsValid) {
                ORG_Store Store = new ORG_Store {
                    CompanyId = 1,
                    Name = model.Name,
                    UniqueCode = model.UniqueCode,
                    Address = model.Address,
                    Telephone = model.Telephone,
                    ResponsiblePerson = model.ResponsiblePerson,
                    Description = model.Description
                };
                try {
                    _storeService.InsertStore(Store);
                    messages = "创建" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            return View(model);
        }
        public ActionResult Edit(int id) {
            ORG_Store Store = _storeService.GetStore(id);
            var model = new StoreModel() {
                Id = Store.StoreId,
                CompanyID = Store.CompanyId,
                Name= Store.Name,
                UniqueCode = Store.UniqueCode,
                Address = Store.Address,
                Telephone = Store.Telephone,
                ResponsiblePerson = Store.ResponsiblePerson,
                Description = Store.ResponsiblePerson
            };
            model.PageTitle = "店铺信息";
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StoreModel model) {
            if (ModelState.IsValid) {
                ORG_Store Store = _storeService.GetStore(model.Id);
                Store.StoreId = model.Id;
                Store.UniqueCode = model.UniqueCode;
                Store.Name = model.Name;
                Store.Telephone = model.Telephone;
                Store.Address = model.Address;
                Store.ResponsiblePerson = model.ResponsiblePerson;
                Store.Description = model.Description;
                try {
                    _storeService.UpdateStore(Store);

                    messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id) {
            return RedirectToAction("Index");
            //return View();
        }
    }
}