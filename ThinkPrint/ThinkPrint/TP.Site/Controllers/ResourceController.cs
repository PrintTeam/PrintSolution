using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.SysSetting;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers
{
    public class ResourceController : BaseController
    {
        private readonly IResourceService _resourceService;
        private string messages = "";
        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null)
        {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<SYS_SysSetting> sysSettingList = _resourceService.GetSysSettingList(pageIndex, SysConstant.Page_PageSize, searchKey);

            ResourceListModel model = new ResourceListModel();
            model.ViewList = sysSettingList;
            model.PageTitle = "系统参数";
            model.PageSubTitle = "查看和维护系统中重要参数信息";
            return View(model);
           
        }

        public ActionResult Create()
        {
            var model = new ResourceModel();
            model.IsEdit = false;
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ResourceModel model)
        {
            VerifyModel(model);

            if (ModelState.IsValid)
            {
                SYS_SysSetting sysSetting = new SYS_SysSetting
                {
                    RowGuid=Guid.NewGuid(),
                    Name = model.Name,
                    Title=model.Title.Trim(),
                    UniqueCode = model.UniqueCode.Trim(),
                    TitleCode = model.TitleCode.Trim(),
                    ParamValue = model.ParamValue.Trim(),
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };

                try
                {
                    _resourceService.InsertSysSetting(sysSetting);
                    messages = "创建" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }


            PrepareModel(model);
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            SYS_SysSetting sysSetting = _resourceService.GetSysSettingByCode(id);

            ResourceModel model = new ResourceModel
            {
                RowGuid = sysSetting.RowGuid,
                Name = sysSetting.Name,
                Title=sysSetting.Title,
                UniqueCode = sysSetting.UniqueCode,
                TitleCode = sysSetting.TitleCode,
                ParamValue = sysSetting.ParamValue,
                ModifiedDate = sysSetting.ModifiedDate,
                Description = sysSetting.Description,
                IsEdit = true
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ResourceModel model)
        {

            VerifyModel(model);
            if (ModelState.IsValid)
            {
                SYS_SysSetting sysSetting = _resourceService.GetSysSettingByCode(model.UniqueCode);

                sysSetting.Name = model.Name;
                sysSetting.UniqueCode = model.UniqueCode;
                sysSetting.Title = model.Title;
                sysSetting.TitleCode = model.TitleCode;
                sysSetting.ParamValue = model.ParamValue;
                sysSetting.Description = model.Description;
                sysSetting.ModifiedDate = DateTime.UtcNow.ToLocalTime();

                try
                {
                    _resourceService.UpdateSysSetting(sysSetting);

                    messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }

            }
            PrepareModel(model);
            return View(model);
        }


        public ActionResult Delete(string id)
        {
            try
            {
                SYS_SysSetting sysSetting = _resourceService.GetSysSettingByCode(id);
                _resourceService.DeleteSysSetting(sysSetting);
                return Redirect("~/Resource/Index");
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                ErrorNotification(ex.ToString());

            }
            return RedirectToAction("Index", "Resource");
        }

        [NonAction]
        private void PrepareModel(ResourceModel model)
        {
            model.PageTitle = "系统参数";
            model.PageSubTitle = "维护系统中重要参数信息";
        }

        [NonAction]
        private void VerifyModel(ResourceModel model)
        {

            SYS_SysSetting sysSetting = null;
            if (model.IsEdit)
            {

                sysSetting = _resourceService.CheckExistSysSettingByCode(model.RowGuid, model.UniqueCode.Trim());

            }
            else
            {
                sysSetting = _resourceService.CheckExistSysSettingByCode(model.UniqueCode.Trim());
            }

            if (sysSetting != null)
                ModelState.AddModelError("UniqueCode", "参数编码已存在.");

            if (model.IsEdit)
            {

                sysSetting = _resourceService.CheckExistSysSettingByTitleCode(model.RowGuid, model.TitleCode.Trim());

            }
            else
            {
                sysSetting = _resourceService.CheckExistSysSettingByTitleCode(model.TitleCode.Trim());
            }
            if (sysSetting != null)
                ModelState.AddModelError("TitleCode", "参数的标识编码已存在.");

        }
    }
}