using NSIS.Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Department;
using TP.Service.Store;
using TP.Service.SysResource;
using TP.Site.Helper;
using TP.Site.Models.Organization;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers
{
    public class EmployeeController : BaseController
    {
      
        private readonly IEmployeeService _employeeService;
        private readonly IResourceService _resourceService;
        private readonly IDepartmentService _departmentService;
        private readonly IStoreService _storeService;
        private IList<SYS_SysSetting> statusList;
        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService,IStoreService storeService, IResourceService resourceService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _storeService = storeService;
            _resourceService = resourceService;
            PrepareStatusList();
        }
        // GET: Employee
        public ActionResult Index(int pageIndex = 1, string searchKey = null)
        {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<ORG_Employee> employeeList = _employeeService.GetEmployeeList(pageIndex, SysConstant.Page_PageSize, searchKey);

            EmployeeListModel model = new EmployeeListModel();
            model.ViewList = employeeList;
            
           
            model.PageTitle = "员工信息";
            model.PageSubTitle = "查看和维护所有的员工信息";
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new EmployeeModel();
            model.EntryDate = DateTime.Now.Date;
            PrepareModel(model);
            return View(model);
        }

        public ActionResult Edit(int id) 
        {
            ORG_Employee employee = _employeeService.GetEmployeeById(id);

            EmployeeModel model = new EmployeeModel
            {
                Id = employee.EmployeeId,
                Name = employee.Name,
                JobNumber = employee.JobNumber,
                CredentialsNum = employee.CredentialsNum,
                Sex = employee.Sex,
                Age = employee.Age,
                MobilePhone = employee.MobilePhone,
                Status = employee.Status,
                EntryDate = employee.EntryDate,
                IsEdit = true
            };
            PrepareModel(model);
            return View(model);
        }

        [NonAction]
        private void PrepareModel(EmployeeModel model)
        {

            model.PageTitle = "创建信息";
            model.PageSubTitle = "新增一个员工信息";
            model.IsEdit = model.Id == 0 ? false : true;
            if (!model.IsEdit)
            {
                model.Sex = true;
            }
            //PrepareDepartmnet(model);
        }

        [NonAction]
        private void PrepareStatusList()
        {
            statusList = _resourceService.GetSysSettingList(SysConstant.EmployeeStatus_titleCode);
        }

        [NonAction]
        private void PrepareDepartmnet(EmployeeModel model) 
        {
            if (model == null)
                throw new ArgumentNullException("model");

            IList<ORG_Department> departmentList = _departmentService.GetDepartments();

            foreach (var item in departmentList)
            {
                model.DepartmentList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.DepartmentId.ToString()
                });
            }

            if (!model.IsEdit)
            {
                model.DepartmentList.Insert(0, new SelectListItem { Selected = true, Text = "选择部门信息", Value = "0" });
            }
            else
            {
                var selected = model.DepartmentList.FirstOrDefault(u => u.Value == model.CurrentDepartmentId.ToString());
                selected.Selected = true;
            }
        }

        private void PrepareStore(EmployeeModel model) 
        {
            if (model == null)
                throw new ArgumentNullException("model");

            IList<ORG_Store> storeList = _storeService.GetStores();

            foreach (var item in storeList)
            {
                model.StoreList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StoreId.ToString()
                });
            }

            if (!model.IsEdit)
            {
                model.StoreList.Insert(0, new SelectListItem { Selected = true, Text = "选择店铺信息", Value = "0" });
            }
            else
            {
                var selected = model.StoreList.FirstOrDefault(u => u.Value == model.CurrentStroreId.ToString());
                selected.Selected = true;
            }
        }
    }
}