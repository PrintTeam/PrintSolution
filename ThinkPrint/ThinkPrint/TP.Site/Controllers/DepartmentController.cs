using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Company;
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
        private readonly ICompanyService _companyService;
        private string messages = "";

        public DepartmentController(IDepartmentService departmentService, ICompanyService companyService)
        {
            _departmentService = departmentService;
            _companyService = companyService;
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

        [HttpGet]
        public ActionResult Create()
        {
            var model = new DepartmentModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                ORG_Department department = new ORG_Department
                {
                    Name = model.Name,
                    CompanyId = model.CompanyId,
                    ShortName = model.ShortName,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false

                };

                try
                {
                    _departmentService.InsertDepartment(department);

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
            ORG_Department employee = _departmentService.GetDepartment(id);

            DepartmentModel model = new DepartmentModel
            {
                Id = employee.DepartmentId,
                Name = employee.Name,
                ShortName = employee.ShortName,
                CompanyId = (Int32)employee.CompanyId,
                CompanyName = employee.ORG_Company.Name,
                Description = employee.Description,
                IsEdit = true
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentModel model)
        {

            if (ModelState.IsValid)
            {
                ORG_Department department = _departmentService.GetDepartment(model.Id);

                department.Name = model.Name;
                department.CompanyId = model.CompanyId;
                department.ShortName = model.ShortName;
                department.Description = model.Description;
                department.ModifiedDate = DateTime.UtcNow.ToLocalTime();

                try
                {
                    _departmentService.UpdateDepartment(department);

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
                ORG_Department department = _departmentService.GetDepartment(id);
                if (department.ORG_Employee.Count == 0)
                {
                    _departmentService.DeleteDepartment(department);
                    return Redirect("~/Department/Index");
                }
                else
                {
                    messages = "无法删除" + department.Name + "该信息具有关联的子项信息，请先删除子项信息。";
                    ErrorNotification(messages);
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                ErrorNotification(ex.ToString());

            }
            return RedirectToAction("Index", "Department");
        }


        [NonAction]
        private void PrepareModel(DepartmentModel model)
        {

            model.PageTitle = "部门信息";
            model.PageSubTitle = "维护系统中部门信息";
            model.IsEdit = model.Id == 0 ? false : true;
            if (!model.IsEdit)
            {
                PrepareCompany(model);
            }

        }

        private void PrepareCompany(DepartmentModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            ORG_Company company = _companyService.GetCompanys().FirstOrDefault();
            model.CompanyId = company.CompanyId;
            model.CompanyName = company.Name;
        }



    }
}