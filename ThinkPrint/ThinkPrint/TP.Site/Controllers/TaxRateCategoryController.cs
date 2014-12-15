using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.TaxRateCategory;
using TP.Site.Helper;
using TP.Site.Models.SysSetting;
using TP.Web.Framework.Mvc;

namespace TP.Site.Controllers {
    public class TaxRateCategoryController : BaseController {
        private ITaxRateCategoryService m_Service;
        private String m_Messages;

        public TaxRateCategoryController(ITaxRateCategoryService service) {
            m_Service = service;
        }
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            TaxRateCategoryListModel model = new TaxRateCategoryListModel();
            model.PageTitle = "税率分类";
            model.PageSubTitle = "查看和维护税率分类信息";
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            model.ViewList = m_Service.GetTaxRateCategorys(pageIndex, SysConstant.Page_PageSize, searchKey);
            return View(model);
        }

        public ActionResult Create() {
            TaxRateCategoryModel model = new TaxRateCategoryModel();
            model.PageTitle = "税率分类";
            model.PageSubTitle = "查看和维护税率分类信息";
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TaxRateCategoryModel model) {
            if (ModelState.IsValid) {
                SYS_TaxRateCategory TaxRateCategory = new SYS_TaxRateCategory {
                    Name = model.Name,
                    TaxRate = model.TaxRate,
                    Description = model.Description
                };
                try {
                    m_Service.InsertTaxRateCategory(TaxRateCategory);
                    m_Messages = "创建" + model.Name + "信息成功.";
                    SuccessNotification(m_Messages);
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id) {
            SYS_TaxRateCategory TaxRateCategory = m_Service.GetTaxRateCategory(id);
            TaxRateCategoryModel model = new TaxRateCategoryModel {
                Name = TaxRateCategory.Name,
                TaxRate = TaxRateCategory.TaxRate,
                Description = TaxRateCategory.Description
            };
            model.PageTitle = "税率分类";
            model.PageSubTitle = "查看和维护税率分类信息";
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TaxRateCategoryModel model) {
            if (ModelState.IsValid) {
                SYS_TaxRateCategory TaxRateCategory = m_Service.GetTaxRateCategory(model.Id);
                TaxRateCategory.Name = model.Name;
                TaxRateCategory.TaxRate = model.TaxRate;
                TaxRateCategory.Description = model.Description;
                try {
                    m_Service.UpdateTaxRateCategory(TaxRateCategory);
                    m_Messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(m_Messages);
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            return View(model);
        }
        public ActionResult Delete(int id) {
            SYS_TaxRateCategory Unit = m_Service.GetTaxRateCategory(id);
            m_Service.DeleteTaxRateCategory(Unit);
            return RedirectToAction("Index");
        }
    }
}