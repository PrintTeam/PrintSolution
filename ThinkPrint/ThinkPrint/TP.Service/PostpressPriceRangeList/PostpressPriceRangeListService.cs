using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressPriceRangeList {

    /// <summary>
    /// 后道加工价格区间业务服务对象
    /// </summary>
    public class PostpressPriceRangeListService:IPostpressPriceRangeListService {
        private readonly IPostpressPriceRangeListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostpressPriceRangeListService(IPostpressPriceRangeListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PostpressPriceRangeList GetPostpressPriceRangeList(int  PostpressPriceRangeId) {
            return m_Repository.GetById(PostpressPriceRangeId);
        }

        public List<PMW_PostpressPriceRangeList> GetPostpressPriceRangeLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<PMW_PostpressPriceRangeList> GetPostpressPriceRangeLists(int pageIndex, int pageSize) {            
            var q = m_Repository.Table.OrderByDescending(p => p.ModifiedDate);
            PagedList<PMW_PostpressPriceRangeList> result = q.ToPagedList<PMW_PostpressPriceRangeList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPostpressPriceRangeList(PMW_PostpressPriceRangeList PostpressPriceRangeList) {
            if (PostpressPriceRangeList == null) throw new ArgumentNullException("后道加工价格区间实体不能为null值");           
            PostpressPriceRangeList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostpressPriceRangeList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostpressPriceRangeList(PMW_PostpressPriceRangeList PostpressPriceRangeList) {
            if (PostpressPriceRangeList == null) throw new ArgumentNullException("后道加工价格区间实体不能为null值");           
            PostpressPriceRangeList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressPriceRangeList);
            m_UnitOfWork.Commint();
        }

        public void DeletePostpressPriceRangeList(PMW_PostpressPriceRangeList PostpressPriceRangeList) {
            if (PostpressPriceRangeList == null) throw new ArgumentNullException("后道加工价格区间实体不能为null值");            
            PostpressPriceRangeList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressPriceRangeList);
            m_UnitOfWork.Commint();
        }    
    }
}

