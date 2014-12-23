using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Customer {

    /// <summary>
    /// 客户信息业务服务对象
    /// </summary>
    public class CustomerService : ICustomerService {
        private readonly ICustomerRepository m_Repository;
        private readonly IIndustryRepository m_IndustryRepository;
        private readonly IUnitOfWork m_UnitOfWork;

        public CustomerService(ICustomerRepository repository, IIndustryRepository IndustryRepository,
            IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_IndustryRepository = IndustryRepository;
            m_UnitOfWork = unitOfWork;
        }

        public SAL_Customer GetCustomer(int CustomerId) {
            return m_Repository.GetById(CustomerId);
        }
        public SAL_Customer GetCustomer(String UniqueCode) {
            List<SAL_Customer> List = m_Repository.Table.
                Where(p => p.IsDelete == false && p.UniqueCode == UniqueCode).ToList();
            if (List.Count > 0)
                return List.First();
            return null;
        }

        public List<SALCustomer> GetCustomers() {
            var q = from a in m_Repository.Table
                    join b in m_IndustryRepository.Table on a.IndustryId equals b.IndustryId
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new SALCustomer {
                        CustomerId = a.CustomerId,
                        IndustryId = a.IndustryId,
                        IndustryName = b.Name,
                        Name = a.Name,
                        MembershipCode = a.MembershipCode,
                        Cardholder = a.Cardholder,
                        CardNumber = a.CardNumber,
                        CustomerType = a.CustomerType,
                        UniqueCode = a.UniqueCode,
                        MnemonicCode = a.MnemonicCode,
                        Sex = a.Sex,
                        MobilePhone = a.MobilePhone,
                        Telephone = a.Telephone,
                        Birthday = a.Birthday,
                        Email = a.Email,
                        QQ = a.QQ,
                        ZipCode = a.ZipCode,
                        Address = a.Address,
                        CreditRating = a.CreditRating,
                        IsCreditCard = a.IsCreditCard,
                        MaximumAmount = a.MaximumAmount,
                        SalePriceType = a.SalePriceType,
                        Description = a.Description
                    };
            return q.ToList();
            //return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SALCustomer> GetCustomers(int pageIndex, int pageSize, string searchKey = null) {
            var q = from a in m_Repository.Table
                    join b in m_IndustryRepository.Table on a.IndustryId equals b.IndustryId
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new SALCustomer {
                        CustomerId = a.CustomerId,
                        IndustryId = a.IndustryId,
                        IndustryName = b.Name,
                        Name = a.Name,
                        MembershipCode = a.MembershipCode,
                        Cardholder = a.Cardholder,
                        CardNumber = a.CardNumber,
                        CustomerType = a.CustomerType,
                        UniqueCode = a.UniqueCode,
                        MnemonicCode = a.MnemonicCode,
                        Sex = a.Sex,
                        MobilePhone = a.MobilePhone,
                        Telephone = a.Telephone,
                        Birthday = a.Birthday,
                        Email = a.Email,
                        QQ = a.QQ,
                        ZipCode = a.ZipCode,
                        Address = a.Address,
                        CreditRating = a.CreditRating,
                        IsCreditCard = a.IsCreditCard,
                        MaximumAmount = a.MaximumAmount,
                        SalePriceType = a.SalePriceType,
                        Description = a.Description
                    };
            if (!String.IsNullOrWhiteSpace(searchKey)) {
                q = from a in m_Repository.Table
                    join b in m_IndustryRepository.Table on a.IndustryId equals b.IndustryId
                    where a.IsDelete == false && a.Name.Contains(searchKey)
                    orderby a.ModifiedDate descending
                    select new SALCustomer {
                        CustomerId = a.CustomerId,
                        IndustryId = a.IndustryId,
                        IndustryName = b.Name,
                        Name = a.Name,
                        MembershipCode = a.MembershipCode,
                        Cardholder = a.Cardholder,
                        CardNumber = a.CardNumber,
                        CustomerType = a.CustomerType,
                        UniqueCode = a.UniqueCode,
                        MnemonicCode = a.MnemonicCode,
                        Sex = a.Sex,
                        MobilePhone = a.MobilePhone,
                        Telephone = a.Telephone,
                        Birthday = a.Birthday,
                        Email = a.Email,
                        QQ = a.QQ,
                        ZipCode = a.ZipCode,
                        Address = a.Address,
                        CreditRating = a.CreditRating,
                        IsCreditCard = a.IsCreditCard,
                        MaximumAmount = a.MaximumAmount,
                        SalePriceType = a.SalePriceType,
                        Description = a.Description
                    };
            }
            PagedList<SALCustomer> result = q.ToPagedList<SALCustomer>(pageIndex, pageSize);
            return result;
        }

        public void InsertCustomer(SAL_Customer Customer) {
            if (Customer == null)
                throw new ArgumentNullException("客户信息实体不能为null值");
            Customer.IsDelete = false;
            Customer.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Customer);
            m_UnitOfWork.Commint();
        }

        public void UpdateCustomer(SAL_Customer Customer) {
            if (Customer == null)
                throw new ArgumentNullException("客户信息实体不能为null值");
            Customer.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Customer);
            m_UnitOfWork.Commint();
        }

        public void DeleteCustomer(SAL_Customer Customer) {
            if (Customer == null)
                throw new ArgumentNullException("客户信息实体不能为null值");
            Customer.IsDelete = true;
            Customer.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Customer);
            m_UnitOfWork.Commint();
        }
    }
}

