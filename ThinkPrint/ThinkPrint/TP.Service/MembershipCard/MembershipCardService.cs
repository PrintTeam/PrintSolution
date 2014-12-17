using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipCard {

    /// <summary>
    /// 会员卡信息业务服务对象
    /// </summary>
    public class MembershipCardService:IMembershipCardService {
        private readonly IMembershipCardRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public MembershipCardService(IMembershipCardRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_MembershipCard GetMembershipCard(int  MembershipCardId) {
            return m_Repository.GetById(MembershipCardId);
        }

        public List<CRM_MembershipCard> GetMembershipCards() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_MembershipCard> GetMembershipCards(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.CardNumber.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_MembershipCard> result = q.ToPagedList<CRM_MembershipCard>(pageIndex, pageSize);
            return result;
        }

        public void InsertMembershipCard(CRM_MembershipCard MembershipCard) {
            if (MembershipCard == null) throw new ArgumentNullException("会员卡信息实体不能为null值");          
            MembershipCard.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(MembershipCard);
            m_UnitOfWork.Commint();
        }

        public void UpdateMembershipCard(CRM_MembershipCard MembershipCard) {
            if (MembershipCard == null) throw new ArgumentNullException("会员卡信息实体不能为null值");           
            MembershipCard.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipCard);
            m_UnitOfWork.Commint();
        }

        public void DeleteMembershipCard(CRM_MembershipCard MembershipCard) {
            if (MembershipCard == null) throw new ArgumentNullException("会员卡信息实体不能为null值");           
            MembershipCard.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipCard);
            m_UnitOfWork.Commint();
        }    
    }
}

