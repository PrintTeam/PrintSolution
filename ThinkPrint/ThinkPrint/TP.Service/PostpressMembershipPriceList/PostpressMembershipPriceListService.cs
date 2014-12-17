using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressMembershipPriceList {

    /// <summary>
    /// 会员后道加工价格业务服务对象
    /// </summary>
    public class PostpressMembershipPriceListService:IPostpressMembershipPriceListService {
        private readonly IPostpressMembershipPriceListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostpressMembershipPriceListService(IPostpressMembershipPriceListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PostpressMembershipPriceList GetPostpressMembershipPriceList(int  PostpressMembershipPriceId) {
            return m_Repository.GetById(PostpressMembershipPriceId);
        }

        public List<PMW_PostpressMembershipPriceList> GetPostpressMembershipPriceLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<PMW_PostpressMembershipPriceList> GetPostpressMembershipPriceLists(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<PMW_PostpressMembershipPriceList> result = q.ToPagedList<PMW_PostpressMembershipPriceList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPostpressMembershipPriceList(PMW_PostpressMembershipPriceList PostpressMembershipPriceList) {
            if (PostpressMembershipPriceList == null) throw new ArgumentNullException("会员后道加工价格实体不能为null值");           
            PostpressMembershipPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostpressMembershipPriceList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostpressMembershipPriceList(PMW_PostpressMembershipPriceList PostpressMembershipPriceList) {
            if (PostpressMembershipPriceList == null) throw new ArgumentNullException("会员后道加工价格实体不能为null值");           
            PostpressMembershipPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressMembershipPriceList);
            m_UnitOfWork.Commint();
        }

        public void DeletePostpressMembershipPriceList(PMW_PostpressMembershipPriceList PostpressMembershipPriceList) {
            if (PostpressMembershipPriceList == null) throw new ArgumentNullException("会员后道加工价格实体不能为null值");            
            PostpressMembershipPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressMembershipPriceList);
            m_UnitOfWork.Commint();
        }    
    }
}

