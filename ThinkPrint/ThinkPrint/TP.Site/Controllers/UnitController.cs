using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Unit;
using TP.Site.Helper;
using TP.Site.Models.SysSetting;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    public class UnitController : BaseController {
        private IUnitService m_Service;
        private String m_Messages;
        public UnitController(IUnitService service) {
            m_Service = service;
        }
        // GET: Unit
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            UnitListModel model = new UnitListModel();
            model.PageTitle = "计量单位";
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            model.ViewList = m_Service.GetUnits(pageIndex, SysConstant.Page_PageSize, searchKey);
            return View(model);
        }
        public ActionResult Create() {
            UnitModel model = new UnitModel();
            model.PageTitle = "计量单位";
            model.PageSubTitle = "查看和维护计量单位信息";
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UnitModel model) {
            if (ModelState.IsValid) {
                SYS_Unit Unit = new SYS_Unit {
                    Name = model.Name,
                    UnitType = model.UnitType,
                    Description = model.Description
                };
                try {
                    m_Service.InsertUnit(Unit);
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
            SYS_Unit Unit = m_Service.GetUnit(id);
            UnitModel model = new UnitModel {
                Name = Unit.Name,
                UnitType = Unit.UnitType,
                Description = Unit.Description
            };
            model.PageTitle = "计量单位";
            model.PageSubTitle = "查看和维护计量单位信息";
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UnitModel model) {
            if (ModelState.IsValid) {
                SYS_Unit Unit = m_Service.GetUnit(model.Id);
                Unit.Name = model.Name;
                Unit.UnitType = model.UnitType;
                Unit.Description = model.Description;
                try {
                    m_Service.UpdateUnit(Unit);
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
            SYS_Unit Unit = m_Service.GetUnit(id);
            m_Service.DeleteUnit(Unit);
            return RedirectToAction("Index");
        }
    }
}