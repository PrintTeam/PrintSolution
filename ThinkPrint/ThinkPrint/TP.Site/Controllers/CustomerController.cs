using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Customer;
using TP.Service.Industry;
using TP.Site.Helper;
using TP.Site.Models.Customer;
using TP.Web.Framework.Mvc;
using Webdiyer.WebControls.Mvc;

namespace TP.Site.Controllers {
    /// <summary>
    /// 
    /// </summary>
    public class CustomerController : BaseController {
        private readonly ICustomerService m_CustomerService;
        private readonly IIndustryService m_IndustryService;
        private string messages = "";
        public CustomerController(ICustomerService CustomerService,IIndustryService industryService) {
            m_CustomerService = CustomerService;
            m_IndustryService = industryService;
        }

        // GET: Resource
        public ActionResult Index(int pageIndex = 1, string searchKey = null) {
            searchKey = searchKey == null ? searchKey : searchKey.Trim();
            PagedList<SALCustomer> CustomerList = m_CustomerService.GetCustomers(pageIndex, SysConstant.Page_PageSize, searchKey);
            CustomerListModel model = new CustomerListModel();
            model.ViewList = CustomerList;
            model.PageTitle = "客户信息";
            model.PageSubTitle = "查看和维护客户信息";
            return View(model);
        }

        public ActionResult Create() {
            var model = new CustomerModel();
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model) {
            if (ModelState.IsValid) {
                SAL_Customer Customer = new SAL_Customer {
                    IndustryId = model.IndustryId,
                    Name = model.Name,
                    MembershipCode = model.MembershipCode,
                    Cardholder = model.Cardholder,
                    CardNumber = model.CardNumber,
                    CustomerType = model.CustomerType,
                    UniqueCode = model.UniqueCode,
                    MnemonicCode = model.MnemonicCode,
                    Sex = model.Sex,
                    MobilePhone = model.MobilePhone,
                    Telephone = model.Telephone,
                    Birthday = model.Birthday,
                    Email = model.Email,
                    QQ = model.QQ,
                    ZipCode = model.ZipCode,
                    Address = model.Address,
                    CreditRating = model.CreditRating,
                    IsCreditCard = model.IsCreditCard,
                    MaximumAmount = model.MaximumAmount,
                    SalePriceType = model.SalePriceType,
                    Description = model.Description,
                    ModifiedDate = DateTime.UtcNow.ToLocalTime(),
                    IsDelete = false
                };
                try {
                    m_CustomerService.InsertCustomer(Customer);
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
            SAL_Customer Customer = m_CustomerService.GetCustomer(id);
            CustomerModel model = new CustomerModel {
                IndustryId = Customer.IndustryId,
                Name = Customer.Name,
                MembershipCode = Customer.MembershipCode,
                Cardholder = Customer.Cardholder,
                CardNumber = Customer.CardNumber,
                CustomerType = Customer.CustomerType,
                UniqueCode = Customer.UniqueCode,
                MnemonicCode = Customer.MnemonicCode,
                Sex = Customer.Sex,
                MobilePhone = Customer.MobilePhone,
                Telephone = Customer.Telephone,                
                Birthday = Customer.Birthday.HasValue? Customer.Birthday.Value:DateTime.MinValue,
                Email = Customer.Email,
                QQ = Customer.QQ.HasValue?Customer.QQ.Value:0,
                ZipCode = Customer.ZipCode,
                Address = Customer.Address,
                CreditRating = Customer.CreditRating,
                IsCreditCard = Customer.IsCreditCard,
                MaximumAmount = Customer.MaximumAmount.HasValue? Customer.MaximumAmount.Value:0,
                SalePriceType = Customer.SalePriceType,
                Description = Customer.Description,
            };
            PrepareModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel model) {
            if (ModelState.IsValid) {
                SAL_Customer Customer = m_CustomerService.GetCustomer(model.Id);
                Customer.IndustryId = model.IndustryId;
                Customer.Name = model.Name;
                Customer.MembershipCode = model.MembershipCode;
                Customer.Cardholder = model.Cardholder;
                Customer.CardNumber = model.CardNumber;
                Customer.CustomerType = model.CustomerType;
                Customer.UniqueCode = model.UniqueCode;
                Customer.MnemonicCode = model.MnemonicCode;
                Customer.Sex = model.Sex;
                Customer.MobilePhone = model.MobilePhone;
                Customer.Telephone = model.Telephone;
                Customer.Birthday = model.Birthday;
                Customer.Email = model.Email;
                Customer.QQ = model.QQ;
                Customer.ZipCode = model.ZipCode;
                Customer.Address = model.Address;
                Customer.CreditRating = model.CreditRating;
                Customer.IsCreditCard = model.IsCreditCard;
                Customer.MaximumAmount = model.MaximumAmount;
                Customer.SalePriceType = model.SalePriceType;
                Customer.Description = model.Description;
                Customer.IsDelete = false;
                Customer.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                try {
                    m_CustomerService.UpdateCustomer(Customer);
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
        private void PrepareModel(CustomerModel model) {
            model.PageTitle = "客户信息";
            model.PageSubTitle = "客户信息维护";
            //model.IsEdit = model.Id == 0 ? false : true;
        }
    }
}
