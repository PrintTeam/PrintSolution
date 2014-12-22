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
        private string messages = "";
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IStoreService storeService, IResourceService resourceService)
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

        public ActionResult ShowDetailView(int id)
        {
            ORG_Employee employee = _employeeService.GetEmployeeById(id);
            EmployeeModel model = new EmployeeModel
            {
                Id = employee.EmployeeId,
                Name = employee.Name,
                JobNumber = employee.JobNumber,
                CredentialsNum = employee.CredentialsNum,
                Email = employee.Email,
                Sex = employee.Sex,
                Age = employee.Age,
                MobilePhone = employee.MobilePhone,
                StatusName = statusList.SingleOrDefault(s => s.ParamValue == employee.Status.Trim()).Name,
                Status = employee.Status.Trim(),
                StatusList = statusList,
                EntryDate = employee.EntryDate,
                LeaveDate = employee.LeaveDate,
                CurrentDepartment = employee.ORG_Department.Name,
                CurrentStrore = employee.ORG_Store != null ? employee.ORG_Store.Name : "",
                ManagerName = employee.ORG_Employee2 != null ? employee.ORG_Employee2.Name : ""
            };
            model.PageTitle = "员工信息明细";
            model.PageSubTitle = "查看员工明细信息";
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new EmployeeModel();
            model.EntryDate = DateTime.Now.Date;
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            model.Status = statusList.SingleOrDefault(s => s.UniqueCode == SysConstant.EmployeeStatus_normal).ParamValue;
            VerifyModel(model);

            if (ModelState.IsValid)
            {
                ORG_Employee employee = new ORG_Employee
                {
                    Name = model.Name,
                    ManagerId = model.ManagerId,
                    DepartmentId = model.CurrentDepartmentId,
                    StoreId = model.CurrentStroreId,
                    JobNumber = model.JobNumber.Trim(),
                    CredentialsNum = model.CredentialsNum,
                    Email = model.Email,
                    Sex = model.Sex,
                    Age = model.Age,
                    MobilePhone = model.MobilePhone,
                    Status = model.Status,
                    EntryDate = model.EntryDate,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime()

                };

                try
                {
                    _employeeService.InsertEmployee(employee);

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


        [HttpGet]
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

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {

            VerifyModel(model);
            if (ModelState.IsValid)
            {
                ORG_Employee employee = _employeeService.GetEmployeeById(model.Id);

                employee.Name = model.Name;
                employee.ManagerId = model.ManagerId;
                employee.DepartmentId = model.CurrentDepartmentId;
                employee.StoreId = model.CurrentStroreId;
                employee.Email = model.Email;
                employee.JobNumber = model.JobNumber;
                employee.CredentialsNum = model.CredentialsNum;
                employee.Sex = model.Sex;
                employee.Age = model.Age;
                employee.MobilePhone = model.MobilePhone;
                employee.EntryDate = model.EntryDate;
                employee.ModifiedDate = DateTime.UtcNow.ToLocalTime();

                try
                {
                    _employeeService.UpdateEmployee(employee);

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


        public ActionResult Delete(int id)
        {
            try
            {
                ORG_Employee employee = _employeeService.GetEmployeeById(id);

                _employeeService.DeleteEmployee(employee);
                return Redirect("~/Employee/Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                ErrorNotification(ex.ToString());

            }
            return RedirectToAction("Index", "Employee");
        }

        [NonAction]
        private void PrepareModel(EmployeeModel model)
        {

            model.PageTitle = "员工信息";
            model.PageSubTitle = "维护系统中员工信息";
            model.IsEdit = model.Id == 0 ? false : true;
            if (!model.IsEdit)
            {
                model.Sex = true;
            }
            PrepareDepartmnet(model);
            PrepareStore(model);
            PrepareManager(model);
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

        private void PrepareManager(EmployeeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            IList<ORG_Employee> employeeList = _employeeService.GetEmployeeList();

            if (model.IsEdit)
            {
                employeeList = employeeList.Where(e => e.EmployeeId != model.Id).ToList();

            }

            foreach (var item in employeeList)
            {
                model.ManagerList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.EmployeeId.ToString()
                });
            }

            if (!model.IsEdit)
            {
                model.ManagerList.Insert(0, new SelectListItem { Selected = true, Text = "选择直属领导", Value = "0" });
            }
            else
            {
                var selected = model.ManagerList.FirstOrDefault(u => u.Value == model.ManagerId.ToString());
                selected.Selected = true;
            }
        }

        [NonAction]
        private void VerifyModel(EmployeeModel model)
        {

            if (model.CurrentDepartmentId == 0)
            {
                ModelState.AddModelError("", "请选择指标所属的部门信息.");
                return;
            }

            if (string.IsNullOrWhiteSpace(model.JobNumber))
            {
                ModelState.AddModelError("", "员工工号不能为空.");
                return;
            }

            ORG_Employee employee = null;

            if (model.IsEdit)
            {

                employee = _employeeService.CheckExistEmployeeByJobNumber(model.Id, model.JobNumber.Trim());

            }
            else
            {
                employee = _employeeService.CheckExistEmployeeByJobNumber(model.JobNumber.Trim());
            }
            if (employee != null)
                ModelState.AddModelError("", "员工工号已存在.");

        }
    }
}