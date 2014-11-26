using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.SysSetting;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IResourceService _resourceService;
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
    }
}