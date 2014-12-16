using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipFreeze {

    /// <summary>
    /// 冻结业务服务对象
    /// </summary>
    public class MembershipFreezeService:IMembershipFreezeService {
        private readonly IMembershipFreezeRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public MembershipFreezeService(IMembershipFreezeRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_MembershipFreeze GetMembershipFreeze(int  MembershipFreezeId) {
            return m_Repository.GetById(MembershipFreezeId);
        }

        public List<CRM_MembershipFreeze> GetMembershipFreezes() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_MembershipFreeze> GetMembershipFreezes(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.FreezeReason.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_MembershipFreeze> result = q.ToPagedList<CRM_MembershipFreeze>(pageIndex, pageSize);
            return result;
        }

        public void InsertMembershipFreeze(CRM_MembershipFreeze MembershipFreeze) {
            if (MembershipFreeze == null) throw new ArgumentNullException("冻结实体不能为null值");           
            MembershipFreeze.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(MembershipFreeze);
            m_UnitOfWork.Commint();
        }

        public void UpdateMembershipFreeze(CRM_MembershipFreeze MembershipFreeze) {
            if (MembershipFreeze == null) throw new ArgumentNullException("冻结实体不能为null值");           
            MembershipFreeze.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipFreeze);
            m_UnitOfWork.Commint();
        }

        public void DeleteMembershipFreeze(CRM_MembershipFreeze MembershipFreeze) {
            if (MembershipFreeze == null) throw new ArgumentNullException("冻结实体不能为null值");           
            MembershipFreeze.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipFreeze);
            m_UnitOfWork.Commint();
        }    
    }
}

