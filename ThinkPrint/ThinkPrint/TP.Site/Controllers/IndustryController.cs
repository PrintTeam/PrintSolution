using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Industry;
using TP.Site.Helper;
using TP.Site.Models.Industry;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    /// <summary>
    /// 
    /// </summary>
    public class IndustryController : BaseController {
        private readonly IIndustryService m_IndustryService;
        private string messages = "";
        public IndustryController(IIndustryService IndustryService) {
            m_IndustryService = IndustryService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<SYS_Industry> IndustryList = m_IndustryService.GetIndustrys(pageIndex, SysConstant.Page_PageSize, searchKey);
            IndustryListModel model = new IndustryListModel();
            model.ViewList = IndustryList;
            model.PageTitle = "";
            model.PageSubTitle = "查看和维护";
            return View(model);
        }

        public ActionResult Create() {
            var model = new IndustryModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(IndustryModel model) {
            if (ModelState.IsValid) {
                SYS_Industry Industry = new SYS_Industry {
                    Name = model.Name,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_IndustryService.InsertIndustry(Industry);
                    messages = "创建" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                } catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            PrepareModel(model);
            return View(model);
        }

        public ActionResult Edit(int id) {
            SYS_Industry Industry = m_IndustryService.GetIndustry(id);
            IndustryModel model = new IndustryModel {
                Name = Industry.Name,
                Description = Industry.Description
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(IndustryModel model) {
            if (ModelState.IsValid) {
                SYS_Industry Industry = m_IndustryService.GetIndustry(model.Id);
                Industry.Name = model.Name;
                Industry.Description = model.Description;
                Industry.IsDelete = false;
                Industry.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_IndustryService.UpdateIndustry(Industry);
                    messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                } catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }

            }
            PrepareModel(model);
            return View(model);
        }

        [NonAction]
        private void PrepareModel(IndustryModel model) {
            model.PageTitle = "";
            model.PageSubTitle = "维护信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }
    }
}
