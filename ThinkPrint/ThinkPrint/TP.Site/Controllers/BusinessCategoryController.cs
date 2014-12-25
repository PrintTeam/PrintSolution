using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.BusinessCategory;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.BusinessCategory;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers
{
    public class BusinessCategoryController : BaseController
    {
        private readonly IBusinessCategoryService _businessCategoryService;
        private readonly IResourceService _resourceService;
        private IList<SYS_SysSetting> businessTypeList;
        private string messages = "";
        public BusinessCategoryController(IBusinessCategoryService businessCategoryService, IResourceService resourceService)
        {
            _businessCategoryService = businessCategoryService;
            _resourceService = resourceService;
            PrepareBusinessTypeList();
        }

        // GET: BusinessCategory
        public ActionResult Index(int pageIndex = 1, string searchKey = null)
        {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<BUS_BusinessCategory> businessCategoryList = _businessCategoryService.GetBusinessCategoryList(pageIndex, SysConstant.Page_PageSize, searchKey);

            BusinessCategoryListModel model = new BusinessCategoryListModel();
            model.ViewList = businessCategoryList;
            model.BusinessTypeList = businessTypeList;
            model.PageTitle = "业务类型";
            model.PageSubTitle = "查看和维护经营的业务类型信息";
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new BusinessCategoryModel();
            PrepareModel(model);
            return View(model);
        }

        [NonAction]
        private void PrepareBusinessTypeList()
        {
            businessTypeList = _resourceService.GetSysSettingList(SysConstant.BusinessType_titlecode);
        }
        [NonAction]
        private void PrepareBusinessTypeList(BusinessCategoryModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            foreach (var item in businessTypeList)
            {
                model.BusinessTypeList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ParamValue.ToString()
                });
            }
            if (!model.IsEdit)
            {
                model.BusinessTypeList.Insert(0, new SelectListItem { Selected = true, Text = "选择业务类别", Value = "0" });
            }
            else
            {
                var selected = model.BusinessTypeList.FirstOrDefault(u => u.Value == model.BusinessType.Trim());
                selected.Selected = true;
            }

        }


        [NonAction]
        private void PrepareModel(BusinessCategoryModel model)
        {

            model.PageTitle = "业务类型";
            model.PageSubTitle = "维护系统中业务类型信息";
            model.IsEdit = model.Id == 0 ? false : true;
            PrepareBusinessTypeList(model);

        }

        [NonAction]
        private void VerifyModel(BusinessCategoryModel model)
        {

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("", "业务类型名称不能为空.");
                return;
            }

            BUS_BusinessCategory businessCategory = null;

            if (model.IsEdit)
            {

                businessCategory = _businessCategoryService.CheckExistBusinessCategoryByName(model.Id, model.Name.Trim());

            }
            else
            {
                businessCategory = _businessCategoryService.CheckExistBusinessCategoryByName(model.Name.Trim());
            }
            if (businessCategory != null)
                ModelState.AddModelError("", "业务类型名称已存在.");

        }
    }
}