using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Company {

    /// <summary>
    /// 公司信息业务服务对象
    /// </summary>
    public class CompanyService:ICompanyService {
        private readonly ICompanyRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public CompanyService(ICompanyRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public ORG_Company GetCompany(int  CompanyId) {
            return m_Repository.GetById(CompanyId);
        }

        public List<ORG_Company> GetCompanys() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<ORG_Company> GetCompanys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<ORG_Company> result = q.ToPagedList<ORG_Company>(pageIndex, pageSize);
            return result;
        }

        public void InsertCompany(ORG_Company Company) {
            if (Company == null) throw new ArgumentNullException("公司信息实体不能为null值");
            Company.IsDelete = false;
            Company.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Company);
            m_UnitOfWork.Commint();
        }

        public void UpdateCompany(ORG_Company Company) {
            if (Company == null) throw new ArgumentNullException("公司信息实体不能为null值");           
            Company.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Company);
            m_UnitOfWork.Commint();
        }

        public void DeleteCompany(ORG_Company Company) {
            if (Company == null) throw new ArgumentNullException("公司信息实体不能为null值");
            Company.IsDelete = true;
            Company.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Company);
            m_UnitOfWork.Commint();
        }    
    }
}

