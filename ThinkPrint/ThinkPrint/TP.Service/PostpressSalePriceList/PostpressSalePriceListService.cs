using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressSalePriceList {

    /// <summary>
    /// 后道加工销售价格业务服务对象
    /// </summary>
    public class PostpressSalePriceListService:IPostpressSalePriceListService {
        private readonly IPostpressSalePriceListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostpressSalePriceListService(IPostpressSalePriceListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BPM_PostpressSalePriceList GetPostpressSalePriceList(int  PostpressSalePriceId) {
            return m_Repository.GetById(PostpressSalePriceId);
        }

        public List<BPM_PostpressSalePriceList> GetPostpressSalePriceLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BPM_PostpressSalePriceList> GetPostpressSalePriceLists(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BPM_PostpressSalePriceList> result = q.ToPagedList<BPM_PostpressSalePriceList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPostpressSalePriceList(BPM_PostpressSalePriceList PostpressSalePriceList) {
            if (PostpressSalePriceList == null) throw new ArgumentNullException("后道加工销售价格实体不能为null值");          
            PostpressSalePriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostpressSalePriceList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostpressSalePriceList(BPM_PostpressSalePriceList PostpressSalePriceList) {
            if (PostpressSalePriceList == null) throw new ArgumentNullException("后道加工销售价格实体不能为null值");           
            PostpressSalePriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressSalePriceList);
            m_UnitOfWork.Commint();
        }

        public void DeletePostpressSalePriceList(BPM_PostpressSalePriceList PostpressSalePriceList) {
            if (PostpressSalePriceList == null) throw new ArgumentNullException("后道加工销售价格实体不能为null值");           
            PostpressSalePriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressSalePriceList);
            m_UnitOfWork.Commint();
        }    
    }
}

