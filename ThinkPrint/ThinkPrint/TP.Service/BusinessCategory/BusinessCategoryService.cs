using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.BusinessCategory {

    /// <summary>
    /// 业务类型业务服务对象
    /// </summary>
    public class BusinessCategoryService:IBusinessCategoryService {
        private readonly IBusinessCategoryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public BusinessCategoryService(IBusinessCategoryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BUS_BusinessCategory GetBusinessCategory(int  BusinessCategoryId) {
            return m_Repository.GetById(BusinessCategoryId);
        }

        public List<BUS_BusinessCategory> GetBusinessCategorys() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<BUS_BusinessCategory> GetBusinessCategorys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BUS_BusinessCategory> result = q.ToPagedList<BUS_BusinessCategory>(pageIndex, pageSize);
            return result;
        }

        public void InsertBusinessCategory(BUS_BusinessCategory BusinessCategory) {
            if (BusinessCategory == null) throw new ArgumentNullException("业务类型实体不能为null值");
            BusinessCategory.IsDelete = false;
            BusinessCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(BusinessCategory);
            m_UnitOfWork.Commint();
        }

        public void UpdateBusinessCategory(BUS_BusinessCategory BusinessCategory) {
            if (BusinessCategory == null) throw new ArgumentNullException("业务类型实体不能为null值");           
            BusinessCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(BusinessCategory);
            m_UnitOfWork.Commint();
        }

        public void DeleteBusinessCategory(BUS_BusinessCategory BusinessCategory) {
            if (BusinessCategory == null) throw new ArgumentNullException("业务类型实体不能为null值");
            BusinessCategory.IsDelete = true;
            BusinessCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(BusinessCategory);
            m_UnitOfWork.Commint();
        }    
    }
}

