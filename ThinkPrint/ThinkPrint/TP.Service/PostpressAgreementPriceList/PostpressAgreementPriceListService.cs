using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressAgreementPriceList {

    /// <summary>
    /// 后道加工协议价格业务服务对象
    /// </summary>
    public class PostpressAgreementPriceListService:IPostpressAgreementPriceListService {
        private readonly IPostpressAgreementPriceListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostpressAgreementPriceListService(IPostpressAgreementPriceListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BPM_PostpressAgreementPriceList GetPostpressAgreementPriceList(int  PostpressAgreementPriceId) {
            return m_Repository.GetById(PostpressAgreementPriceId);
        }

        public List<BPM_PostpressAgreementPriceList> GetPostpressAgreementPriceLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BPM_PostpressAgreementPriceList> GetPostpressAgreementPriceLists(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BPM_PostpressAgreementPriceList> result = q.ToPagedList<BPM_PostpressAgreementPriceList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPostpressAgreementPriceList(BPM_PostpressAgreementPriceList PostpressAgreementPriceList) {
            if (PostpressAgreementPriceList == null) throw new ArgumentNullException("后道加工协议价格实体不能为null值");           
            PostpressAgreementPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostpressAgreementPriceList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostpressAgreementPriceList(BPM_PostpressAgreementPriceList PostpressAgreementPriceList) {
            if (PostpressAgreementPriceList == null) throw new ArgumentNullException("后道加工协议价格实体不能为null值");           
            PostpressAgreementPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressAgreementPriceList);
            m_UnitOfWork.Commint();
        }

        public void DeletePostpressAgreementPriceList(BPM_PostpressAgreementPriceList PostpressAgreementPriceList) {
            if (PostpressAgreementPriceList == null) throw new ArgumentNullException("后道加工协议价格实体不能为null值");            
            PostpressAgreementPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressAgreementPriceList);
            m_UnitOfWork.Commint();
        }    
    }
}

