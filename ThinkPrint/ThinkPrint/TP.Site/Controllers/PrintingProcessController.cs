using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Machine;
using TP.Service.PrintingProcess;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.PrintingProcess;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
     /// <summary>
    /// 印刷工序
    /// </summary>
    public class PrintingProcessController : BaseController {
        private readonly IPrintingProcessService m_PrintingProcessService;
        private readonly IMachineService m_MachineService;
        private readonly IResourceService m_ResourceService;
        private string messages = "";
        public PrintingProcessController(IPrintingProcessService PrintingProcessService,
            IMachineService machineService, IResourceService resourceService) {
            m_MachineService = machineService;
            m_ResourceService = resourceService;
            m_PrintingProcessService = PrintingProcessService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<PMWPrintingProcess> PrintingProcessList = m_PrintingProcessService.GetPrintingProcesss(pageIndex, SysConstant.Page_PageSize, searchKey);
            PrintingProcessListModel model = new PrintingProcessListModel();
            model.ViewList = PrintingProcessList;
            model.PageTitle = "印刷工序";
            model.PageSubTitle = "查看和维护印刷工序";
            return View(model);           
        }

        public ActionResult Create() {
            var model = new PrintingProcessModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PrintingProcessModel model) {
            if (ModelState.IsValid) {
                PMW_PrintingProcess PrintingProcess = new PMW_PrintingProcess {
                    MachineId = model.MachineId,  
                     
                    Name = model.Name,  
                    ShortName = model.ShortName,  
                    MnemonicCode = model.MnemonicCode,  
                    PartsAttributeCode = model.PartsAttributeCode,  
                    SideProperty = model.SideProperty,  
                    ColorType = model.ColorType,  
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_PrintingProcessService.InsertPrintingProcess(PrintingProcess);
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
            PMW_PrintingProcess PrintingProcess = m_PrintingProcessService.GetPrintingProcess(id);
            PrintingProcessModel model = new PrintingProcessModel {
              MachineId = PrintingProcess.MachineId,
          
              Name = PrintingProcess.Name,
              ShortName = PrintingProcess.ShortName,
              MnemonicCode = PrintingProcess.MnemonicCode,
              PartsAttributeCode = PrintingProcess.PartsAttributeCode,
              SideProperty = PrintingProcess.SideProperty,
              ColorType = PrintingProcess.ColorType,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PrintingProcessModel model) {
            if (ModelState.IsValid) {
                PMW_PrintingProcess PrintingProcess = m_PrintingProcessService.GetPrintingProcess(model.Id);
                PrintingProcess.MachineId = model.MachineId;  
            
                PrintingProcess.Name = model.Name;  
                PrintingProcess.ShortName = model.ShortName;  
                PrintingProcess.MnemonicCode = model.MnemonicCode;  
                PrintingProcess.PartsAttributeCode = model.PartsAttributeCode;  
                PrintingProcess.SideProperty = model.SideProperty;  
                PrintingProcess.ColorType = model.ColorType;  
                PrintingProcess.IsDelete = false;
                PrintingProcess.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_PrintingProcessService.UpdatePrintingProcess(PrintingProcess);
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
        private void PrepareModel(PrintingProcessModel model) {
            model.PageTitle = "印刷工序";
            model.PageSubTitle = "维护印刷工序信息";
            //model.IsEdit = model.Id == 0 ? false : true;
            model.ColorTypes = m_ResourceService.GetSysSettingList(SysConstant.ColorType_titlecode)
                .Select(p => new SelectListItem {
                    Value = p.ParamValue,
                    Text = p.Name
                }).ToList();

            model.ProcessTypes = m_ResourceService.GetSysSettingList(SysConstant.BillType_titleCode)
                .Select(p => new SelectListItem {
                    Value = p.ParamValue,
                    Text = p.Name
                }).ToList();

            model.Machines = m_MachineService.GetMachines().Select(p => new SelectListItem {
                Value = p.MachineId + "",
                Text = p.Name
            }).ToList();
        }       
    }
}
