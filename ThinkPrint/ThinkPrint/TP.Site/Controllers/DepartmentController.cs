using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Department;
using TP.Site.Helper;
using TP.Site.Models.Organization;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Department
        public ActionResult Index(int pageIndex = 1, string searchKey = null)
        {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<ORG_Department> departmentList = _departmentService.GetDepartments(pageIndex, SysConstant.Page_PageSize, searchKey); ;

            DepartmentListModel model = new DepartmentListModel();
            model.ViewList = departmentList;
            model.PageTitle = "部门信息";
            model.PageSubTitle = "查看和维护所有的部门信息";
            return View(model);
        }
    }
}