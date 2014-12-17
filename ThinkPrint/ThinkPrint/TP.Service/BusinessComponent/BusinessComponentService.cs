using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.BusinessComponent {

    /// <summary>
    /// 业务组成业务服务对象
    /// </summary>
    public class BusinessComponentService:IBusinessComponentService {
        private readonly IBusinessComponentRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public BusinessComponentService(IBusinessComponentRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BUS_BusinessComponent GetBusinessComponent(int  BusinessComponentId) {
            return m_Repository.GetById(BusinessComponentId);
        }

        public List<BUS_BusinessComponent> GetBusinessComponents() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BUS_BusinessComponent> GetBusinessComponents(int pageIndex, int pageSize) {
            var q = m_Repository.Table;           
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BUS_BusinessComponent> result = q.ToPagedList<BUS_BusinessComponent>(pageIndex, pageSize);
            return result;
        }

        public void InsertBusinessComponent(BUS_BusinessComponent BusinessComponent) {
            if (BusinessComponent == null) throw new ArgumentNullException("业务组成实体不能为null值");          
            BusinessComponent.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(BusinessComponent);
            m_UnitOfWork.Commint();
        }

        public void UpdateBusinessComponent(BUS_BusinessComponent BusinessComponent) {
            if (BusinessComponent == null) throw new ArgumentNullException("业务组成实体不能为null值");           
            BusinessComponent.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(BusinessComponent);
            m_UnitOfWork.Commint();
        }

        public void DeleteBusinessComponent(BUS_BusinessComponent BusinessComponent) {
            if (BusinessComponent == null) throw new ArgumentNullException("业务组成实体不能为null值");           
            BusinessComponent.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(BusinessComponent);
            m_UnitOfWork.Commint();
        }    
    }
}

