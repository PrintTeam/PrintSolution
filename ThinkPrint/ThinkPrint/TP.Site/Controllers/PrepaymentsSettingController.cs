using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.PrepaymentsSetting;
using TP.Site.Helper;
using TP.Site.Models.PrepaymentsSetting;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {

    public class PrepaymentsSettingController : BaseController {
        private readonly IPrepaymentsSettingService m_PrepaymentsSettingService;
        private string messages = "";
        public PrepaymentsSettingController(IPrepaymentsSettingService PrepaymentsSettingService) {
            m_PrepaymentsSettingService = PrepaymentsSettingService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<SYS_PrepaymentsSetting> PrepaymentsSettingList = m_PrepaymentsSettingService.GetPrepaymentsSettings(pageIndex, SysConstant.Page_PageSize);
            PrepaymentsSettingListModel model = new PrepaymentsSettingListModel();
            model.ViewList = PrepaymentsSettingList;
            model.PageTitle = "预收款设置信息";
            model.PageSubTitle = "查看和维护预收款设置信息";
            return View(model);
        }

        public ActionResult Create() {
            var model = new PrepaymentsSettingModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PrepaymentsSettingModel model) {
            if (ModelState.IsValid) {
                SYS_PrepaymentsSetting PrepaymentsSetting = new SYS_PrepaymentsSetting {
                    OrderMinAmount = model.OrderMinAmount,
                    OrderMaxAmount = model.OrderMaxAmount,
                    PrepaymentsAmount = model.PrepaymentsAmount,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_PrepaymentsSettingService.InsertPrepaymentsSetting(PrepaymentsSetting);
                    messages = "创建预收款设置信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            PrepareModel(model);
            return View(model);
        }

        public ActionResult Edit(int id) {
            SYS_PrepaymentsSetting PrepaymentsSetting = m_PrepaymentsSettingService.GetPrepaymentsSetting(id);
            PrepaymentsSettingModel model = new PrepaymentsSettingModel {
                OrderMinAmount = PrepaymentsSetting.OrderMinAmount,
                OrderMaxAmount = PrepaymentsSetting.OrderMaxAmount,
                PrepaymentsAmount = PrepaymentsSetting.PrepaymentsAmount,
                Description = PrepaymentsSetting.Description,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PrepaymentsSettingModel model) {
            if (ModelState.IsValid) {
                SYS_PrepaymentsSetting PrepaymentsSetting = m_PrepaymentsSettingService.GetPrepaymentsSetting(model.PrepaymentsSettingId);
                PrepaymentsSetting.OrderMinAmount = model.OrderMinAmount;
                PrepaymentsSetting.OrderMaxAmount = model.OrderMaxAmount;
                PrepaymentsSetting.PrepaymentsAmount = model.PrepaymentsAmount;
                PrepaymentsSetting.Description = model.Description;
                PrepaymentsSetting.IsDelete = false;
                PrepaymentsSetting.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_PrepaymentsSettingService.UpdatePrepaymentsSetting(PrepaymentsSetting);
                    messages = "编辑预收款设置信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }

            }
            PrepareModel(model);
            return View(model);
        }

        [NonAction]
        private void PrepareModel(PrepaymentsSettingModel model) {
            model.PageTitle = "预收款设置信息";
            model.PageSubTitle = "维护预收款设置信息信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }
    }
}
