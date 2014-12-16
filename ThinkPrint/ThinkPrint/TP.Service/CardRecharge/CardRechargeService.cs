using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.CardRecharge {

    /// <summary>
    /// 会员卡充值业务服务对象
    /// </summary>
    public class CardRechargeService:ICardRechargeService {
        private readonly ICardRechargeRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public CardRechargeService(ICardRechargeRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_CardRecharge GetCardRecharge(int  CardRechargeId) {
            return m_Repository.GetById(CardRechargeId);
        }

        public List<CRM_CardRecharge> GetCardRecharges() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_CardRecharge> GetCardRecharges(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Payee.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_CardRecharge> result = q.ToPagedList<CRM_CardRecharge>(pageIndex, pageSize);
            return result;
        }

        public void InsertCardRecharge(CRM_CardRecharge CardRecharge) {
            if (CardRecharge == null) throw new ArgumentNullException("会员卡充值实体不能为null值");           
            CardRecharge.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(CardRecharge);
            m_UnitOfWork.Commint();
        }

        public void UpdateCardRecharge(CRM_CardRecharge CardRecharge) {
            if (CardRecharge == null) throw new ArgumentNullException("会员卡充值实体不能为null值");           
            CardRecharge.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(CardRecharge);
            m_UnitOfWork.Commint();
        }

        public void DeleteCardRecharge(CRM_CardRecharge CardRecharge) {
            if (CardRecharge == null) throw new ArgumentNullException("会员卡充值实体不能为null值");          
            CardRecharge.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(CardRecharge);
            m_UnitOfWork.Commint();
        }    
    }
}

