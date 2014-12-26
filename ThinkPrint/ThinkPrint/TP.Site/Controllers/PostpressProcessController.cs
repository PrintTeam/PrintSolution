using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Machine;
using TP.Service.PostpressProcess;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.PostpressProcess;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers{
     /// <summary>
    /// 印后工序
    /// </summary>
    public class PostpressProcessController : BaseController
    {
        private readonly IPostpressProcessService m_PostpressProcessService;
        private readonly IMachineService m_MachineService;
        private readonly IResourceService m_ResourceService;
        private string messages = "";
        public PostpressProcessController(IPostpressProcessService PostpressProcessService,
            IMachineService machineService, IResourceService resourceService) {
            m_MachineService = machineService;
            m_ResourceService = resourceService;
            m_PostpressProcessService = PostpressProcessService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null){
            searchKey = searchKey == null ? searchKey : searchKey.Trim();           
            PostpressProcessListModel model = new PostpressProcessListModel();
            model.Parameters = m_ResourceService.GetSysSettingList(SysConstant.SideProperty_titlecode);
            model.Parameters.AddRange(m_ResourceService.GetSysSettingList(SysConstant.PricingModels_titlecode));
            model.ViewList = m_PostpressProcessService.GetPostpressProcesss(pageIndex, 
                SysConstant.Page_PageSize, searchKey);
            model.PageTitle = "印后工序";
            model.PageSubTitle = "查看和维护印后工序";
            return View(model);           
        }

        public ActionResult Create(){
            var model = new PostpressProcessModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PostpressProcessModel model){
            VerifyModel(model);
            if (ModelState.IsValid){
                PMW_PostpressProcess PostpressProcess = new PMW_PostpressProcess{
                    MachineId = model.MachineId,  
                   
                    Name = model.Name,  
                    UniqueCode = model.UniqueCode,  
                    ShortName = model.ShortName,  
                    MnemonicCode = model.MnemonicCode,  
                    SideProperty = model.SideProperty,  
                    PricingModels = model.PricingModels,  
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_PostpressProcessService.InsertPostpressProcess(PostpressProcess);
                    messages = "创建" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex){
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            PrepareModel(model);
            return View(model);
        }

        public ActionResult Edit(int id){
            PMW_PostpressProcess PostpressProcess = m_PostpressProcessService.GetPostpressProcess(id);
            PostpressProcessModel model = new PostpressProcessModel{
              MachineId = PostpressProcess.MachineId,
             
              Name = PostpressProcess.Name,
              UniqueCode = PostpressProcess.UniqueCode,
              ShortName = PostpressProcess.ShortName,
              MnemonicCode = PostpressProcess.MnemonicCode,
              SideProperty = PostpressProcess.SideProperty,
              PricingModels = PostpressProcess.PricingModels,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PostpressProcessModel model){
            model.IsEdit = true;
            VerifyModel(model);
            if (ModelState.IsValid){
                PMW_PostpressProcess PostpressProcess = m_PostpressProcessService.GetPostpressProcess(model.Id);
                PostpressProcess.MachineId = model.MachineId;  
               
                PostpressProcess.Name = model.Name;  
                PostpressProcess.UniqueCode = model.UniqueCode;  
                PostpressProcess.ShortName = model.ShortName;  
                PostpressProcess.MnemonicCode = model.MnemonicCode;  
                PostpressProcess.SideProperty = model.SideProperty;  
                PostpressProcess.PricingModels = model.PricingModels;  
                PostpressProcess.IsDelete = false;
                PostpressProcess.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try{
                    m_PostpressProcessService.UpdatePostpressProcess(PostpressProcess);
                    messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex){
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }

            }
            PrepareModel(model);
            return View(model);
        }

        [NonAction]
        private void PrepareModel(PostpressProcessModel model){
            model.PageTitle = "印后工序";
            model.PageSubTitle = "维护印后工序信息";

            model.PriceModels = m_ResourceService.GetSysSettingList(SysConstant.PricingModels_titlecode)
                .Select(p => new SelectListItem {
                    Value = p.ParamValue,
                    Text = p.Name
                }).ToList();

            model.SidePropertys= m_ResourceService.GetSysSettingList(SysConstant.SideProperty_titlecode)
                .Select(p => new SelectListItem {
                    Value = p.ParamValue,
                    Text = p.Name
                }).ToList();

            model.Machines = m_MachineService.GetMachines().Select(p => new SelectListItem {
                Value = p.MachineId + "",
                Text = p.Name
            }).ToList();
        }

        [NonAction]
        private void VerifyModel(PostpressProcessModel model) {
            PMW_PostpressProcess Process = null;
            Process = m_PostpressProcessService.GetPostpressProcess(model.UniqueCode);
            if ((model.IsEdit) && (Process.MachineId != model.Id) && (Process != null)) {
                ModelState.AddModelError("UniqueCode", "工序编码已存在.");
            }
            if ((!model.IsEdit) && (Process != null)) {
                ModelState.AddModelError("UniqueCode", "工序编码已存在.");
            }
        }
    }
}
