using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipUnfreeze {

    /// <summary>
    /// 解冻业务服务对象
    /// </summary>
    public class MembershipUnfreezeService:IMembershipUnfreezeService {
        private readonly IMembershipUnfreezeRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public MembershipUnfreezeService(IMembershipUnfreezeRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_MembershipUnfreeze GetMembershipUnfreeze(int  MembershipUnfreezeId) {
            return m_Repository.GetById(MembershipUnfreezeId);
        }

        public List<CRM_MembershipUnfreeze> GetMembershipUnfreezes() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_MembershipUnfreeze> GetMembershipUnfreezes(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.UnfreezeReason.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_MembershipUnfreeze> result = q.ToPagedList<CRM_MembershipUnfreeze>(pageIndex, pageSize);
            return result;
        }

        public void InsertMembershipUnfreeze(CRM_MembershipUnfreeze MembershipUnfreeze) {
            if (MembershipUnfreeze == null) throw new ArgumentNullException("解冻实体不能为null值");        
            MembershipUnfreeze.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(MembershipUnfreeze);
            m_UnitOfWork.Commint();
        }

        public void UpdateMembershipUnfreeze(CRM_MembershipUnfreeze MembershipUnfreeze) {
            if (MembershipUnfreeze == null) throw new ArgumentNullException("解冻实体不能为null值");           
            MembershipUnfreeze.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipUnfreeze);
            m_UnitOfWork.Commint();
        }

        public void DeleteMembershipUnfreeze(CRM_MembershipUnfreeze MembershipUnfreeze) {
            if (MembershipUnfreeze == null) throw new ArgumentNullException("解冻实体不能为null值");          
            MembershipUnfreeze.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipUnfreeze);
            m_UnitOfWork.Commint();
        }    
    }
}

