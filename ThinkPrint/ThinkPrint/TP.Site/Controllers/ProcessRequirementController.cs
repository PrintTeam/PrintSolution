using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.ProcessRequirement;
using TP.Site.Helper;
using TP.Site.Models.ProcessRequirement;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers{
     /// <summary>
    /// 制作要求
    /// </summary>
    public class ProcessRequirementController : BaseController
    {
        private readonly IProcessRequirementService m_ProcessRequirementService;
        private string messages = "";
        public ProcessRequirementController(IProcessRequirementService ProcessRequirementService){
            m_ProcessRequirementService = ProcessRequirementService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null){
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<PMW_ProcessRequirement> ProcessRequirementList = m_ProcessRequirementService.GetProcessRequirements(pageIndex, SysConstant.Page_PageSize, searchKey);
            ProcessRequirementListModel model = new ProcessRequirementListModel();
            model.ViewList = ProcessRequirementList;
            model.PageTitle = "制作要求";
            model.PageSubTitle = "查看和维护制作要求";
            return View(model);           
        }

        public ActionResult Create(){
            var model = new ProcessRequirementModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProcessRequirementModel model){            
            if (ModelState.IsValid){
                PMW_ProcessRequirement ProcessRequirement = new PMW_ProcessRequirement{
                    WorkProjectId = model.WorkProjectId,  
                    Name = model.Name,  
                    
                    Illustrate = model.Illustrate,  
                    ModifiedDate = DateTime.UtcNow.ToLocalTime()
                };
                try {
                    m_ProcessRequirementService.InsertProcessRequirement(ProcessRequirement);
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
            PMW_ProcessRequirement ProcessRequirement = m_ProcessRequirementService.GetProcessRequirement(id);
            ProcessRequirementModel model = new ProcessRequirementModel{
              WorkProjectId = ProcessRequirement.WorkProjectId,
              Name = ProcessRequirement.Name,
         
              Illustrate = ProcessRequirement.Illustrate,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProcessRequirementModel model){            
            if (ModelState.IsValid){
                PMW_ProcessRequirement ProcessRequirement = m_ProcessRequirementService.GetProcessRequirement(model.Id);
                ProcessRequirement.WorkProjectId = model.WorkProjectId;  
                ProcessRequirement.Name = model.Name;  
           
                ProcessRequirement.Illustrate = model.Illustrate;                 
                ProcessRequirement.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try{
                    m_ProcessRequirementService.UpdateProcessRequirement(ProcessRequirement);
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
        private void PrepareModel(ProcessRequirementModel model){
            model.PageTitle = "制作要求";
            model.PageSubTitle = "维护制作要求信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }       
    }
}
