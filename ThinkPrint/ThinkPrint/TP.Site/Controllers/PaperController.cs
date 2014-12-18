using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Paper;
using TP.Service.PaperCategory;
using TP.Service.PaperSize;
using TP.Site.Helper;
using TP.Site.Models.Paper;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    /// <summary>
    /// 纸张信息
    /// </summary>
    public class PaperController : BaseController {
        private readonly IPaperService m_PaperService;
        private readonly IPaperSizeService m_PaperSizeService;
        private readonly IPaperCategoryService m_PaperCategoryService;
        private string messages = "";
        public PaperController(IPaperService PaperService, IPaperSizeService PaperSizeService,
            IPaperCategoryService PaperCategoryService) {
            m_PaperService = PaperService;
            m_PaperSizeService = PaperSizeService;
            m_PaperCategoryService = PaperCategoryService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<BOM_Paper> PaperList = m_PaperService.GetPapers(pageIndex, SysConstant.Page_PageSize, searchKey);
            PaperListModel model = new PaperListModel();
            model.ViewList = PaperList;
            model.PageTitle = "纸张信息";
            model.PageSubTitle = "查看和维护纸张信息";
            return View(model);
        }

        public ActionResult Create() {
            var model = new PaperModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PaperModel model) {
            if (ModelState.IsValid) {
                BOM_Paper Paper = new BOM_Paper {
                    PaperCategoryId = model.PaperCategoryId,
                    PaperSizeId = model.PaperSizeId,
                    Name = model.Name,
                    PartsAttributeCode = model.PartsAttributeCode,
                    MnemonicCode = model.MnemonicCode,
                    Weight = model.Weight,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_PaperService.InsertPaper(Paper);
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
            BOM_Paper Paper = m_PaperService.GetPaper(id);
            PaperModel model = new PaperModel {
                PaperCategoryId = Paper.PaperCategoryId,
                PaperSizeId = Paper.PaperSizeId,
                Name = Paper.Name,
                PartsAttributeCode = Paper.PartsAttributeCode,
                MnemonicCode = Paper.MnemonicCode,
                Weight = Paper.Weight,
                Description = Paper.Description,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PaperModel model) {
            if (ModelState.IsValid) {
                BOM_Paper Paper = m_PaperService.GetPaper(model.Id);
                Paper.PaperCategoryId = model.PaperCategoryId;
                Paper.PaperSizeId = model.PaperSizeId;
                Paper.Name = model.Name;
                Paper.PartsAttributeCode = model.PartsAttributeCode;
                Paper.MnemonicCode = model.MnemonicCode;
                Paper.Weight = model.Weight;
                Paper.Description = model.Description;
                Paper.IsDelete = false;
                Paper.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_PaperService.UpdatePaper(Paper);
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
        private void PrepareModel(PaperModel model) {
            model.PageTitle = "纸张信息";
            model.PageSubTitle = "维护纸张信息信息";
            model.PaperSizes = m_PaperSizeService.GetPaperSizes().Select(p => new SelectListItem {
                Value = p.PaperSizeId + "",
                Text = p.Name
            }).ToList();
            model.PaperCategorys = m_PaperCategoryService.GetPaperCategorys().Select(p => new SelectListItem {
                Value = p.PaperCategoryId + "",
                Text = p.Name
            }).ToList();
        }
    }
}
