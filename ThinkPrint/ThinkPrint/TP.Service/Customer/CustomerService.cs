﻿using System;
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
    public class CustomerService:ICustomerService {
        private readonly ICustomerRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public CustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SAL_Customer GetCustomer(int  CustomerId) {
            return m_Repository.GetById(CustomerId);
        }

        public List<SAL_Customer> GetCustomers() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SAL_Customer> GetCustomers(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<SAL_Customer> result = q.ToPagedList<SAL_Customer>(pageIndex, pageSize);
            return result;
        }

        public void InsertCustomer(SAL_Customer Customer) {
            if (Customer == null) throw new ArgumentNullException("客户信息实体不能为null值");
            Customer.IsDelete = false;
            Customer.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Customer);
            m_UnitOfWork.Commint();
        }

        public void UpdateCustomer(SAL_Customer Customer) {
            if (Customer == null) throw new ArgumentNullException("客户信息实体不能为null值");           
            Customer.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Customer);
            m_UnitOfWork.Commint();
        }

        public void DeleteCustomer(SAL_Customer Customer) {
            if (Customer == null) throw new ArgumentNullException("客户信息实体不能为null值");
            Customer.IsDelete = true;
            Customer.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Customer);
            m_UnitOfWork.Commint();
        }    
    }
}

