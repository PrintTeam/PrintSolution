﻿using System;
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


        [HttpPost]
        public ActionResult Create(BusinessCategoryModel model)
        {
            VerifyModel(model);
            if (ModelState.IsValid)
            {
                BUS_BusinessCategory businessCategory = new BUS_BusinessCategory
                {

                    Name = model.Name.Trim(),
                    MnemonicCode = model.MnemonicCode.Trim(),
                    DisplayOrder = model.DisplayOrder,
                    BusinessType = model.BusinessType,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false

                };

                try
                {
                    _businessCategoryService.InsertBusinessCategory(businessCategory);
                    SuccessNotification("Success");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BUS_BusinessCategory businessCategory = _businessCategoryService.GetBusinessCategoryById(id);

            BusinessCategoryModel model = new BusinessCategoryModel
            {
                Id = businessCategory.BusinessCategoryId,
                Name = businessCategory.Name,
                MnemonicCode = businessCategory.MnemonicCode,
                DisplayOrder = businessCategory.DisplayOrder,
                BusinessType = businessCategory.BusinessType,
                BusinessTypeName=businessTypeList.SingleOrDefault(b=>b.ParamValue==businessCategory.BusinessType.Trim()).Name,
                Description = businessCategory.Description,
                IsEdit = true
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BusinessCategoryModel model)
        {

            VerifyModel(model);
            if (ModelState.IsValid)
            {
                BUS_BusinessCategory businessCategory = _businessCategoryService.GetBusinessCategoryById(model.Id);

                businessCategory.Name = model.Name;
                businessCategory.MnemonicCode = model.MnemonicCode;
                businessCategory.DisplayOrder = model.DisplayOrder;
                businessCategory.Description = model.Description;
                businessCategory.ModifiedDate = DateTime.UtcNow.ToLocalTime();

                try                            
                {
                    _businessCategoryService.UpdateBusinessCategory(businessCategory);

                    messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }

            }
            model.BusinessTypeName = businessTypeList.SingleOrDefault(b => b.ParamValue == model.BusinessType.Trim()).Name;
            PrepareModel(model);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                BUS_BusinessCategory businessCategory = _businessCategoryService.GetBusinessCategoryById(id);
                if(businessCategory.BUS_BusinessComponent.Count==0)
                {
                     _businessCategoryService.DeleteBusinessCategory(businessCategory);
                    return Redirect("~/Resource/Index");
                }
                else
                {
                    messages = "无法删除" + businessCategory.Name + "该信息具有关联的子项信息，请先删除子项信息。";
                    ErrorNotification(messages);
                }
               

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                ErrorNotification(ex.ToString());

            }
            return RedirectToAction("Index", "BusinessCategory");
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
            if(!model.IsEdit)
            {
                PrepareBusinessTypeList(model);
            }
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