using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Store;
using TP.Service.SysResource;
using TP.Service.VoucherEncodingRule;
using TP.Site.Helper;
using TP.Site.Models.VoucherEncodingRule;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    /// <summary>
    /// 单据编码规则
    /// </summary>
    public class VoucherEncodingRuleController : BaseController {
        private readonly IVoucherEncodingRuleService m_VoucherEncodingRuleService;
        private readonly IStoreService m_StoreService;
        private readonly IResourceService m_ResourceService;
        private string messages = "";
        public VoucherEncodingRuleController(IVoucherEncodingRuleService VoucherEncodingRuleService,
            IStoreService storeService,IResourceService resourceService) {
            m_VoucherEncodingRuleService = VoucherEncodingRuleService;
            m_StoreService = storeService;
            m_ResourceService = resourceService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<SYS_VoucherEncodingRule> VoucherEncodingRuleList = m_VoucherEncodingRuleService.GetVoucherEncodingRules(pageIndex, SysConstant.Page_PageSize, searchKey);
            VoucherEncodingRuleListModel model = new VoucherEncodingRuleListModel();
            model.ViewList = VoucherEncodingRuleList;
            model.PageTitle = "单据编码规则";
            model.PageSubTitle = "查看和维护单据编码规则";
            return View(model);
        }

        public ActionResult Create() {           
            var model = new VoucherEncodingRuleModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VoucherEncodingRuleModel model) {
            if (ModelState.IsValid) {
                SYS_VoucherEncodingRule VoucherEncodingRule = new SYS_VoucherEncodingRule {
                    StoreId = Convert.ToInt32(model.StoreId),
                    Name = model.Name,
                    BillType = model.BillType,
                    Prefix = model.Prefix,
                    SequenceNumberLength = model.SequenceNumberLength,
                    SequenceNumberStartValue = model.SequenceNumberStartValue,
                    CodeModeType = model.CodeModeType,
                    YearLength = model.YearLength,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_VoucherEncodingRuleService.InsertVoucherEncodingRule(VoucherEncodingRule);
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
            SYS_VoucherEncodingRule VoucherEncodingRule = m_VoucherEncodingRuleService.GetVoucherEncodingRule(id);
            VoucherEncodingRuleModel model = new VoucherEncodingRuleModel {
                Id = VoucherEncodingRule.VoucherEncodingRuleId,
                StoreId = VoucherEncodingRule.StoreId+"",
                Name = VoucherEncodingRule.Name,
                BillType = VoucherEncodingRule.BillType,
                Prefix = VoucherEncodingRule.Prefix,
                SequenceNumberLength = VoucherEncodingRule.SequenceNumberLength,
                SequenceNumberStartValue = VoucherEncodingRule.SequenceNumberStartValue,
                CodeModeType = VoucherEncodingRule.CodeModeType,
                YearLength = VoucherEncodingRule.YearLength,
                Description = VoucherEncodingRule.Description
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VoucherEncodingRuleModel model) {
            if (ModelState.IsValid) {
                SYS_VoucherEncodingRule VoucherEncodingRule = m_VoucherEncodingRuleService.GetVoucherEncodingRule(model.Id);
                VoucherEncodingRule.VoucherEncodingRuleId = model.Id;
                VoucherEncodingRule.StoreId = Convert.ToInt32(model.StoreId);
                VoucherEncodingRule.Name = model.Name;
                VoucherEncodingRule.BillType = model.BillType;
                VoucherEncodingRule.Prefix = model.Prefix;
                VoucherEncodingRule.SequenceNumberLength = model.SequenceNumberLength;
                VoucherEncodingRule.SequenceNumberStartValue = model.SequenceNumberStartValue;
                VoucherEncodingRule.CodeModeType = model.CodeModeType;
                VoucherEncodingRule.YearLength = model.YearLength;
                VoucherEncodingRule.Description = model.Description;
                VoucherEncodingRule.IsDelete = false;
                VoucherEncodingRule.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_VoucherEncodingRuleService.UpdateVoucherEncodingRule(VoucherEncodingRule);
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
        private void PrepareModel(VoucherEncodingRuleModel model) {
            model.PageTitle = "单据编码规则";
            model.PageSubTitle = "维护单据编码规则信息";
            //model.IsEdit = model.Id == 0 ? false : true;
            model.StoreList = new List<SelectListItem>();
             List<ORG_Store> Stores = m_StoreService.GetStores();
             foreach (ORG_Store Store in Stores) {
                 model.StoreList.Add(new SelectListItem {
                     Value = Store.StoreId+"",
                     Text = Store.Name
                 });
             }
             model.BillCategoryList = new List<SelectListItem>();
             IList<SYS_SysSetting> SysSettings = m_ResourceService.GetSysSettingList("001");
             foreach (SYS_SysSetting SysSetting in SysSettings) {
                 model.BillCategoryList.Add(new SelectListItem {
                     Value = SysSetting.UniqueCode,
                     Text = SysSetting.ParamValue
                 });
             }
             
             model.CodeModeTypeList = new List<SelectListItem>();
             SysSettings = m_ResourceService.GetSysSettingList("002");
             foreach (SYS_SysSetting SysSetting in SysSettings) {
                 model.CodeModeTypeList.Add(new SelectListItem {
                     Value = SysSetting.UniqueCode,
                     Text = SysSetting.ParamValue
                 });
             }
        }
    }
}
