using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostRegisterCard {

    /// <summary>
    /// 补办会员卡业务服务对象
    /// </summary>
    public class PostRegisterCardService:IPostRegisterCardService {
        private readonly IPostRegisterCardRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostRegisterCardService(IPostRegisterCardRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_PostRegisterCard GetPostRegisterCard(int  PostRegisterCardId) {
            return m_Repository.GetById(PostRegisterCardId);
        }

        public List<CRM_PostRegisterCard> GetPostRegisterCards() {
            return m_Repository.Table.ToList();
        }

        public PagedList<CRM_PostRegisterCard> GetPostRegisterCards(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.QuondamCardNumber.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_PostRegisterCard> result = q.ToPagedList<CRM_PostRegisterCard>(pageIndex, pageSize);
            return result;
        }

        public void InsertPostRegisterCard(CRM_PostRegisterCard PostRegisterCard) {
            if (PostRegisterCard == null) throw new ArgumentNullException("补办会员卡实体不能为null值");           
            PostRegisterCard.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostRegisterCard);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostRegisterCard(CRM_PostRegisterCard PostRegisterCard) {
            if (PostRegisterCard == null) throw new ArgumentNullException("补办会员卡实体不能为null值");           
            PostRegisterCard.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostRegisterCard);
            m_UnitOfWork.Commint();
        }

        public void DeletePostRegisterCard(CRM_PostRegisterCard PostRegisterCard) {
            if (PostRegisterCard == null) throw new ArgumentNullException("补办会员卡实体不能为null值");           
            PostRegisterCard.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostRegisterCard);
            m_UnitOfWork.Commint();
        }    
    }
}

