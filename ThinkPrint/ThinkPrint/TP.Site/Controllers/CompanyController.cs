using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Company;
using TP.Site.Models.Organization;
using TP.Web.Framework.Mvc;

namespace TP.Site.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        private string messages = "";

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: Company
        public ActionResult Index()
        {
            CompanyModel model = new CompanyModel();

            ORG_Company company = _companyService.GetCompany();
            if (company == null)
            {
                model = null;
            }
            else
            {
                model.Id = company.CompanyId;
                model.Name = company.Name;
                model.ResponsiblePerson = company.ResponsiblePerson;
                model.FaxNumber = company.FaxNumber;
                model.Address = company.Address;
                model.Telephone = company.Telephone;
                model.PageTitle = "公司信息";
                model.PageSubTitle = "查看和维护公司信息";

            }

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CompanyModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                ORG_Company company = new ORG_Company
                {
                    Name = model.Name.Trim(),
                    ResponsiblePerson = model.ResponsiblePerson,
                    Address = model.Address,
                    Telephone = model.Telephone,
                    FaxNumber = model.FaxNumber,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false

                };

                try
                {
                    _companyService.InsertCompany(company);
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

        public ActionResult Edit(int id)
        {
            CompanyModel model = new CompanyModel();

            ORG_Company company = _companyService.GetCompanyById(id);

            model.Id = company.CompanyId;
            model.Name = company.Name;
            model.Address = company.Address;
            model.Telephone = company.Telephone;
            model.FaxNumber = company.FaxNumber;
            model.ResponsiblePerson = company.ResponsiblePerson;
            PrepareModel(model);
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                ORG_Company company = _companyService.GetCompanyById(model.Id);

                company.Name = model.Name;
                company.Address = model.Address;
                company.Telephone = model.Telephone;
                company.FaxNumber = model.FaxNumber;
                company.ResponsiblePerson = model.ResponsiblePerson;
                company.ModifiedDate = DateTime.UtcNow.ToLocalTime();

                try
                {
                    _companyService.UpdateCompany(company);

                    messages = "编辑" + model.Name + "信息成功.";
                    SuccessNotification(messages);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    ErrorNotification(ex.ToString());
                }
            }
            return View(model);
        }

        [NonAction]
        private void PrepareModel(CompanyModel model)
        {

            model.PageTitle = "公司信息";
            model.PageSubTitle = "维护系统中公司信息";
            model.IsEdit = model.Id == 0 ? false : true;
        }

    }
}