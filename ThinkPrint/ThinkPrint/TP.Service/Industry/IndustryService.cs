using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Industry {

    /// <summary>
    /// 行业业务服务对象
    /// </summary>
    public class IndustryService:IIndustryService {
        private readonly IIndustryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public IndustryService(IIndustryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SYS_Industry GetIndustry(int  IndustryId) {
            return m_Repository.GetById(IndustryId);
        }

        public List<SYS_Industry> GetIndustrys() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SYS_Industry> GetIndustrys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<SYS_Industry> result = q.ToPagedList<SYS_Industry>(pageIndex, pageSize);
            return result;
        }

        public void InsertIndustry(SYS_Industry Industry) {
            if (Industry == null) throw new ArgumentNullException("行业实体不能为null值");
            Industry.IsDelete = false;
            Industry.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Industry);
            m_UnitOfWork.Commint();
        }

        public void UpdateIndustry(SYS_Industry Industry) {
            if (Industry == null) throw new ArgumentNullException("行业实体不能为null值");           
            Industry.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Industry);
            m_UnitOfWork.Commint();
        }

        public void DeleteIndustry(SYS_Industry Industry) {
            if (Industry == null) throw new ArgumentNullException("行业实体不能为null值");
            Industry.IsDelete = true;
            Industry.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Industry);
            m_UnitOfWork.Commint();
        }    
    }
}

