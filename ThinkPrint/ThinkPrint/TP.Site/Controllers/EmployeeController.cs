using NSIS.Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Site.Helper;
using TP.Site.Models.Organization;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers
{
    public class EmployeeController : BaseController
    {
      
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
    }
}