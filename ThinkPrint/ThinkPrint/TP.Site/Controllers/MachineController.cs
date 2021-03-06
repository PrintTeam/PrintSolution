﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Machine;
using TP.Service.MachineCategory;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.Machine;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    /// <summary>
    /// 机器设备
    /// </summary>
    public class MachineController : BaseController {
        private readonly IMachineService m_MachineService;
        private readonly IMachineCategoryService m_MachineCategoryService;
        private readonly IResourceService m_ResourceService;
        private string messages = "";
        public MachineController(IMachineService MachineService, IMachineCategoryService MachineCategoryService,
            IResourceService ResourceService) {
            m_MachineService = MachineService;
            m_MachineCategoryService = MachineCategoryService;
            m_ResourceService = ResourceService;
            m_ResourceService.GetSysSettingList();
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            MachineListModel model = new MachineListModel();
            model.Parameters = m_ResourceService.GetSysSettingList(SysConstant.ColorType_titlecode);
            model.Parameters.AddRange(m_ResourceService.GetSysSettingList(SysConstant.MachineType_titlecode));
            model.ViewList =  m_MachineService.GetMachines(pageIndex, SysConstant.Page_PageSize, searchKey);;
            model.PageTitle = "机器设备";
            model.PageSubTitle = "查看和维护机器设备";
            return View(model);
        }

        public ActionResult Create() {
            var model = new MachineModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MachineModel model) {
            VerifyModel(model);
            if (ModelState.IsValid) {
                PMW_Machine Machine = new PMW_Machine {
                    MachineCategoryId = model.MachineCategoryId,
                    Name = model.Name,
                    UniqueCode = model.UniqueCode,
                    ShortName = model.ShortName,
                    MnemonicCode = model.MnemonicCode,
                    MachineType = model.MachineType,
                    ColorType = model.ColorType,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_MachineService.InsertMachine(Machine);
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
            PMW_Machine Machine = m_MachineService.GetMachine(id);
            MachineModel model = new MachineModel {
                MachineCategoryId = Machine.MachineCategoryId,
                Name = Machine.Name,
                UniqueCode = Machine.UniqueCode,
                ShortName = Machine.ShortName,
                MnemonicCode = Machine.MnemonicCode,
                MachineType = Machine.MachineType,
                ColorType = Machine.ColorType,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MachineModel model) {
            model.IsEdit = true;
            VerifyModel(model);
            if (ModelState.IsValid) {
                PMW_Machine Machine = m_MachineService.GetMachine(model.Id);
                Machine.MachineCategoryId = model.MachineCategoryId;
                Machine.Name = model.Name;
                Machine.UniqueCode = model.UniqueCode;
                Machine.ShortName = model.ShortName;
                Machine.MnemonicCode = model.MnemonicCode;
                Machine.MachineType = model.MachineType;
                Machine.ColorType = model.ColorType;
                Machine.IsDelete = false;
                Machine.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_MachineService.UpdateMachine(Machine);
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
        private void PrepareModel(MachineModel model) {
            model.PageTitle = "机器设备";
            model.PageSubTitle = "维护机器设备信息";
            model.MachineCategorys = m_MachineCategoryService.GetMachineCategorys().Select(p => new SelectListItem {
                Value = p.MachineCategoryId + "",
                Text = p.Name
            }).ToList();

            model.ColorCategorys = m_ResourceService.GetSysSettingList(SysConstant.ColorType_titlecode)
                .Select(p => new SelectListItem {
                    Value = p.ParamValue,
                    Text = p.Name
                }).ToList();

            model.MachineTypes = m_ResourceService.GetSysSettingList(SysConstant.MachineType_titlecode)
                .Select(p => new SelectListItem {
                    Value = p.ParamValue,
                    Text = p.Name
                }).ToList();
        }

        [NonAction]
        private void VerifyModel(MachineModel model) {
            PMW_Machine Machine = null;
            Machine = m_MachineService.GetMachine(model.UniqueCode);
            if ((model.IsEdit) && (Machine.MachineId != model.Id) && (Machine != null)) {
                ModelState.AddModelError("UniqueCode", "设备编码已存在.");
            }
            if ((!model.IsEdit) && (Machine != null)) {
                ModelState.AddModelError("UniqueCode", "设备编码已存在.");
            }           
        }
    }
}
