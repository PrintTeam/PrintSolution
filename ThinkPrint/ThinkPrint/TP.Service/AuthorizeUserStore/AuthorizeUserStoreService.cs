using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.AuthorizeUserStore {

    /// <summary>
    /// 店铺用户授权业务服务对象
    /// </summary>
    public class AuthorizeUserStoreService:IAuthorizeUserStoreService {
        private readonly IAuthorizeUserStoreRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public AuthorizeUserStoreService(IAuthorizeUserStoreRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public ORG_AuthorizeUserStore GetAuthorizeUserStore(int  StoreId,int  UserId) {
            var q = m_Repository.Table.Where(p => p.StoreId == StoreId && p.UserId == UserId);
            return q.ToList().FirstOrDefault();            
        }

        public List<ORG_AuthorizeUserStore> GetAuthorizeUserStores() {
            return m_Repository.Table.ToList();
        }

        public PagedList<ORG_AuthorizeUserStore> GetAuthorizeUserStores(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.AuthorizedPerson.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<ORG_AuthorizeUserStore> result = q.ToPagedList<ORG_AuthorizeUserStore>(pageIndex, pageSize);
            return result;
        }

        public void InsertAuthorizeUserStore(ORG_AuthorizeUserStore AuthorizeUserStore) {
            if (AuthorizeUserStore == null) throw new ArgumentNullException("店铺用户授权实体不能为null值");            
            AuthorizeUserStore.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(AuthorizeUserStore);
            m_UnitOfWork.Commint();
        }

        public void UpdateAuthorizeUserStore(ORG_AuthorizeUserStore AuthorizeUserStore) {
            if (AuthorizeUserStore == null) throw new ArgumentNullException("店铺用户授权实体不能为null值");           
            AuthorizeUserStore.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(AuthorizeUserStore);
            m_UnitOfWork.Commint();
        }

        public void DeleteAuthorizeUserStore(ORG_AuthorizeUserStore AuthorizeUserStore) {
            if (AuthorizeUserStore == null) throw new ArgumentNullException("店铺用户授权实体不能为null值");           
            AuthorizeUserStore.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(AuthorizeUserStore);
            m_UnitOfWork.Commint();
        }    
    }
}

