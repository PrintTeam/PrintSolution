using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipCardCategory {

    /// <summary>
    /// 会员卡类型业务服务对象
    /// </summary>
    public class MembershipCardCategoryService:IMembershipCardCategoryService {
        private readonly IMembershipCardCategoryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public MembershipCardCategoryService(IMembershipCardCategoryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public CRM_MembershipCardCategory GetMembershipCardCategory(int  MembershipCardCategoryId) {
            return m_Repository.GetById(MembershipCardCategoryId);
        }

        public List<CRM_MembershipCardCategory> GetMembershipCardCategorys() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<CRM_MembershipCardCategory> GetMembershipCardCategorys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<CRM_MembershipCardCategory> result = q.ToPagedList<CRM_MembershipCardCategory>(pageIndex, pageSize);
            return result;
        }

        public void InsertMembershipCardCategory(CRM_MembershipCardCategory MembershipCardCategory) {
            if (MembershipCardCategory == null) throw new ArgumentNullException("会员卡类型实体不能为null值");
            MembershipCardCategory.IsDelete = false;
            MembershipCardCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(MembershipCardCategory);
            m_UnitOfWork.Commint();
        }

        public void UpdateMembershipCardCategory(CRM_MembershipCardCategory MembershipCardCategory) {
            if (MembershipCardCategory == null) throw new ArgumentNullException("会员卡类型实体不能为null值");           
            MembershipCardCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipCardCategory);
            m_UnitOfWork.Commint();
        }

        public void DeleteMembershipCardCategory(CRM_MembershipCardCategory MembershipCardCategory) {
            if (MembershipCardCategory == null) throw new ArgumentNullException("会员卡类型实体不能为null值");
            MembershipCardCategory.IsDelete = true;
            MembershipCardCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MembershipCardCategory);
            m_UnitOfWork.Commint();
        }    
    }
}

