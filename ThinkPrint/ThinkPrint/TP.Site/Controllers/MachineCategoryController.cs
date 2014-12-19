using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.MachineCategory;
using TP.Site.Helper;
using TP.Site.Models.MachineCategory;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers{
     /// <summary>
    /// 机器类型
    /// </summary>
    public class MachineCategoryController : BaseController
    {
        private readonly IMachineCategoryService m_MachineCategoryService;
        private string messages = "";
        public MachineCategoryController(IMachineCategoryService MachineCategoryService){
            m_MachineCategoryService = MachineCategoryService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null){
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<PMW_MachineCategory> MachineCategoryList = m_MachineCategoryService.GetMachineCategorys(pageIndex, SysConstant.Page_PageSize, searchKey);
            MachineCategoryListModel model = new MachineCategoryListModel();
            model.ViewList = MachineCategoryList;
            model.PageTitle = "机器类型";
            model.PageSubTitle = "查看和维护机器类型";
            return View(model);           
        }

        public ActionResult Create(){
            var model = new MachineCategoryModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MachineCategoryModel model){            
            if (ModelState.IsValid){
                PMW_MachineCategory MachineCategory = new PMW_MachineCategory{
                    Name = model.Name,  
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_MachineCategoryService.InsertMachineCategory(MachineCategory);
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
            PMW_MachineCategory MachineCategory = m_MachineCategoryService.GetMachineCategory(id);
            MachineCategoryModel model = new MachineCategoryModel{
              Name = MachineCategory.Name,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MachineCategoryModel model){            
            if (ModelState.IsValid){
                PMW_MachineCategory MachineCategory = m_MachineCategoryService.GetMachineCategory(model.Id);
                MachineCategory.Name = model.Name;  
                MachineCategory.IsDelete = false;
                MachineCategory.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try{
                    m_MachineCategoryService.UpdateMachineCategory(MachineCategory);
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
        private void PrepareModel(MachineCategoryModel model){
            model.PageTitle = "机器类型";
            model.PageSubTitle = "维护机器类型信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }       
    }
}
