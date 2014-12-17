using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.CardDictionary {

    /// <summary>
    /// 卡片字典业务服务对象
    /// </summary>
    public class CardDictionaryService:ICardDictionaryService {
        private readonly ICardDictionaryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public CardDictionaryService(ICardDictionaryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_CardDictionary GetCardDictionary(Guid  RowGuid) {
            return m_Repository.GetById(RowGuid);
        }

        public List<CRM_CardDictionary> GetCardDictionarys() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_CardDictionary> GetCardDictionarys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.CardNumber.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.CreateDate);
            PagedList<CRM_CardDictionary> result = q.ToPagedList<CRM_CardDictionary>(pageIndex, pageSize);
            return result;
        }

        public void InsertCardDictionary(CRM_CardDictionary CardDictionary) {
            if (CardDictionary == null) throw new ArgumentNullException("卡片字典实体不能为null值");           
            m_Repository.Add(CardDictionary);
            m_UnitOfWork.Commint();
        }

        public void UpdateCardDictionary(CRM_CardDictionary CardDictionary) {
            if (CardDictionary == null) throw new ArgumentNullException("卡片字典实体不能为null值");  
            m_Repository.Update(CardDictionary);
            m_UnitOfWork.Commint();
        }

        public void DeleteCardDictionary(CRM_CardDictionary CardDictionary) {
            if (CardDictionary == null) throw new ArgumentNullException("卡片字典实体不能为null值");          
            m_Repository.Update(CardDictionary);
            m_UnitOfWork.Commint();
        }    
    }
}

