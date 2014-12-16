using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.CardConsumption {

    /// <summary>
    /// 会员卡消费业务服务对象
    /// </summary>
    public class CardConsumptionService:ICardConsumptionService {
        private readonly ICardConsumptionRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public CardConsumptionService(ICardConsumptionRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_CardConsumption GetCardConsumption(int  CardConsumptionId) {
            return m_Repository.GetById(CardConsumptionId);
        }

        public List<CRM_CardConsumption> GetCardConsumptions() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_CardConsumption> GetCardConsumptions(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.OperatorPerson.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_CardConsumption> result = q.ToPagedList<CRM_CardConsumption>(pageIndex, pageSize);
            return result;
        }

        public void InsertCardConsumption(CRM_CardConsumption CardConsumption) {
            if (CardConsumption == null) throw new ArgumentNullException("会员卡消费实体不能为null值");          
            CardConsumption.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(CardConsumption);
            m_UnitOfWork.Commint();
        }

        public void UpdateCardConsumption(CRM_CardConsumption CardConsumption) {
            if (CardConsumption == null) throw new ArgumentNullException("会员卡消费实体不能为null值");           
            CardConsumption.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(CardConsumption);
            m_UnitOfWork.Commint();
        }

        public void DeleteCardConsumption(CRM_CardConsumption CardConsumption) {
            if (CardConsumption == null) throw new ArgumentNullException("会员卡消费实体不能为null值");           
            CardConsumption.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(CardConsumption);
            m_UnitOfWork.Commint();
        }    
    }
}

