using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.PostpressProcess;
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
        private string messages = "";
        public PostpressProcessController(IPostpressProcessService PostpressProcessService){
            m_PostpressProcessService = PostpressProcessService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null){
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<PMWPostpressProcess> PostpressProcessList = m_PostpressProcessService.GetPostpressProcesss(pageIndex, SysConstant.Page_PageSize, searchKey);
            PostpressProcessListModel model = new PostpressProcessListModel();
            model.ViewList = PostpressProcessList;
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
            if (ModelState.IsValid){
                PMW_PostpressProcess PostpressProcess = new PMW_PostpressProcess{
                    MachineId = model.MachineId,  
                    ProcessType = model.ProcessType,  
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
              ProcessType = PostpressProcess.ProcessType,
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
            if (ModelState.IsValid){
                PMW_PostpressProcess PostpressProcess = m_PostpressProcessService.GetPostpressProcess(model.Id);
                PostpressProcess.MachineId = model.MachineId;  
                PostpressProcess.ProcessType = model.ProcessType;  
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
            //model.IsEdit = model.Id == 0 ? false : true;
        }       
    }
}
