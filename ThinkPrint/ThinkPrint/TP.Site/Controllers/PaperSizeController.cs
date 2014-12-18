using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.PaperSize;
using TP.Site.Helper;
using TP.Site.Models.PaperSize;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers{
     /// <summary>
    /// 纸张尺寸
    /// </summary>
    public class PaperSizeController : BaseController
    {
        private readonly IPaperSizeService m_PaperSizeService;
        private string messages = "";
        public PaperSizeController(IPaperSizeService PaperSizeService){
            m_PaperSizeService = PaperSizeService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null){
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<BOM_PaperSize> PaperSizeList = m_PaperSizeService.GetPaperSizes(pageIndex, SysConstant.Page_PageSize, searchKey);
            PaperSizeListModel model = new PaperSizeListModel();
            model.ViewList = PaperSizeList;
            model.PageTitle = "纸张尺寸";
            model.PageSubTitle = "查看和维护纸张尺寸";
            return View(model);           
        }

        public ActionResult Create(){
            var model = new PaperSizeModel();         
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PaperSizeModel model){
            VerifyModel(model);
            if (ModelState.IsValid){
                BOM_PaperSize PaperSize = new BOM_PaperSize{
                    Name = model.Name,  
                    UniqueCode = model.UniqueCode,  
                    Height = model.Height,  
                    Width = model.Width,  
                    Description = model.Description,  
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_PaperSizeService.InsertPaperSize(PaperSize);
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
            BOM_PaperSize PaperSize = m_PaperSizeService.GetPaperSize(id);
            PaperSizeModel model = new PaperSizeModel{
              Name = PaperSize.Name,
              UniqueCode = PaperSize.UniqueCode,
              Height = PaperSize.Height,
              Width = PaperSize.Width,
              Description = PaperSize.Description
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PaperSizeModel model){
            model.IsEdit = true;
            VerifyModel(model);
            if (ModelState.IsValid){
                BOM_PaperSize PaperSize = m_PaperSizeService.GetPaperSize(model.Id);
                PaperSize.Name = model.Name;  
                PaperSize.UniqueCode = model.UniqueCode;  
                PaperSize.Height = model.Height;  
                PaperSize.Width = model.Width;  
                PaperSize.Description = model.Description;  
                PaperSize.IsDelete = false;
                PaperSize.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try{
                    m_PaperSizeService.UpdatePaperSize(PaperSize);
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
        private void PrepareModel(PaperSizeModel model){
            model.PageTitle = "纸张尺寸";
            model.PageSubTitle = "维护纸张尺寸信息";
            //model.IsEdit = model.Id == 0 ? false : true;
        }

        [NonAction]
        private void VerifyModel(PaperSizeModel model) {
            BOM_PaperSize PaperSize = null;
            PaperSize = m_PaperSizeService.GetPaperSize(model.UniqueCode);
            if ((model.IsEdit) && (PaperSize.PaperSizeId != model.Id) && (PaperSize != null)) {
                ModelState.AddModelError("UniqueCode", "参数编码已存在."); 
            }
            if ((!model.IsEdit) && (PaperSize != null)) {
                ModelState.AddModelError("UniqueCode", "参数编码已存在.");
            }   
        }
    }
}
