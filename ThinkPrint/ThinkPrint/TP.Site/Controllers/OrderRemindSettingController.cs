using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.OrderRemindSetting;
using TP.Site.Helper;
using TP.Site.Models.OrderRemindSetting;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    /// <summary>
    /// 订单消息设置
    /// </summary>
    public class OrderRemindSettingController : BaseController {
        private readonly IOrderRemindSettingService m_OrderRemindSettingService;
        private string messages = "";
        public OrderRemindSettingController(IOrderRemindSettingService OrderRemindSettingService) {
            m_OrderRemindSettingService = OrderRemindSettingService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<SYS_OrderRemindSetting> OrderRemindSettingList = m_OrderRemindSettingService.GetOrderRemindSettings(pageIndex, SysConstant.Page_PageSize);
            OrderRemindSettingListModel model = new OrderRemindSettingListModel();
            model.ViewList = OrderRemindSettingList;
            model.PageTitle = "订单消息设置";
            model.PageSubTitle = "查看和维护订单消息设置";
            return View(model);
        }

        public ActionResult Create() {
            var model = new OrderRemindSettingModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OrderRemindSettingModel model) {
            if (ModelState.IsValid) {
                SYS_OrderRemindSetting OrderRemindSetting = new SYS_OrderRemindSetting {
                    ReminderType = model.ReminderType,
                    ReminderCycle = model.ReminderCycle,
                    ReminderColor = model.ReminderColor,
                    OvertimeCycle = model.OvertimeCycle,
                    OvertimeColor = model.OvertimeColor,
                    EnabledWarning = model.EnabledWarning,
                    WarningMessages = model.WarningMessages,                  
                    IsDelete = false
                };
                try {
                    m_OrderRemindSettingService.InsertOrderRemindSetting(OrderRemindSetting);
                    messages = "创建订单消息设置信息成功.";
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
            SYS_OrderRemindSetting OrderRemindSetting = m_OrderRemindSettingService.GetOrderRemindSetting(id);
            OrderRemindSettingModel model = new OrderRemindSettingModel {
                ReminderType = OrderRemindSetting.ReminderType,
                ReminderCycle = OrderRemindSetting.ReminderCycle,
                ReminderColor = OrderRemindSetting.ReminderColor,
                OvertimeCycle = OrderRemindSetting.OvertimeCycle,
                OvertimeColor = OrderRemindSetting.OvertimeColor,
                EnabledWarning = OrderRemindSetting.EnabledWarning,
                WarningMessages = OrderRemindSetting.WarningMessages,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderRemindSettingModel model) {
            if (ModelState.IsValid) {
                SYS_OrderRemindSetting OrderRemindSetting = m_OrderRemindSettingService.GetOrderRemindSetting(model.Id);
                OrderRemindSetting.ReminderType = model.ReminderType;
                OrderRemindSetting.ReminderCycle = model.ReminderCycle;
                OrderRemindSetting.ReminderColor = model.ReminderColor;
                OrderRemindSetting.OvertimeCycle = model.OvertimeCycle;
                OrderRemindSetting.OvertimeColor = model.OvertimeColor;
                OrderRemindSetting.EnabledWarning = model.EnabledWarning;
                OrderRemindSetting.WarningMessages = model.WarningMessages;
                OrderRemindSetting.IsDelete = false;               
                try {
                    m_OrderRemindSettingService.UpdateOrderRemindSetting(OrderRemindSetting);
                    messages = "编辑订单消息设置信息成功.";
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
        private void PrepareModel(OrderRemindSettingModel model) {
            model.PageTitle = "订单消息设置";
            model.PageSubTitle = "维护订单消息设置信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }
    }
}
