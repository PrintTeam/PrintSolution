using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.PaperCategory;
using TP.Site.Helper;
using TP.Site.Models.PaperCategory;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers{
     /// <summary>
    /// 纸张类型
    /// </summary>
    public class PaperCategoryController : BaseController
    {
        private readonly IPaperCategoryService m_PaperCategoryService;
        private string messages = "";
        public PaperCategoryController(IPaperCategoryService PaperCategoryService){
            m_PaperCategoryService = PaperCategoryService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null){
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<BOM_PaperCategory> PaperCategoryList = m_PaperCategoryService.GetPaperCategorys(pageIndex, SysConstant.Page_PageSize, searchKey);
            PaperCategoryListModel model = new PaperCategoryListModel();
            model.ViewList = PaperCategoryList;
            model.PageTitle = "纸张类型";
            model.PageSubTitle = "查看和维护纸张类型";
            return View(model);           
        }

        public ActionResult Create(){
            var model = new PaperCategoryModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PaperCategoryModel model){            
            if (ModelState.IsValid){
                BOM_PaperCategory PaperCategory = new BOM_PaperCategory{
                    UniqueCode = model.UniqueCode,  
                    Name = model.Name,  
                    Description = model.Description,  
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_PaperCategoryService.InsertPaperCategory(PaperCategory);
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
            BOM_PaperCategory PaperCategory = m_PaperCategoryService.GetPaperCategory(id);
            PaperCategoryModel model = new PaperCategoryModel{
              UniqueCode = PaperCategory.UniqueCode,
              Name = PaperCategory.Name,
              Description = PaperCategory.Description,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PaperCategoryModel model){            
            if (ModelState.IsValid){
                BOM_PaperCategory PaperCategory = m_PaperCategoryService.GetPaperCategory(model.Id);
                PaperCategory.UniqueCode = model.UniqueCode;  
                PaperCategory.Name = model.Name;  
                PaperCategory.Description = model.Description;  
                PaperCategory.IsDelete = false;
                PaperCategory.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try{
                    m_PaperCategoryService.UpdatePaperCategory(PaperCategory);
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
        private void PrepareModel(PaperCategoryModel model){
            model.PageTitle = "纸张类型";
            model.PageSubTitle = "维护纸张类型信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }       
    }
}
