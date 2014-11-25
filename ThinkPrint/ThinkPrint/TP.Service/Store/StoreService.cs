using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;

namespace TP.Service.Store {
    public class StoreService : IStoreService {

        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork) {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public ORG_Store GetStore(int storeID) {
            return _storeRepository.GetById(storeID);
        }

        public PagedList<ORG_Store> GetStoreList(int pageIndex, int pageSize, string searchKey = null) {
            var q = _storeRepository.Table.Where(u=>u.IsDelete==false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q.Where(p => p.Name.Contains(searchKey));
            }
            q.OrderByDescending(p => p.ModifiedDate);
            PagedList<ORG_Store> result = q.ToPagedList(pageIndex, pageSize);
            return result;
        }

        public void InsertStore(ORG_Store store) {
            if (store == null) {
                throw new ArgumentNullException("Insert ORG_Store entity is Null");
            }
            try {
                store.IsDelete = false;
                _storeRepository.Add(store);
                _unitOfWork.Commint();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void UpdateStore(ORG_Store store) {
            if (store == null) {
                throw new ArgumentNullException("Update ORG_Store entity is Null");
            }
            try {
                store.ModifiedDate = DateTime.Now.ToLocalTime();
                _storeRepository.Update(store);
                _unitOfWork.Commint();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void DeleteStore(ORG_Store store) {
            if (store == null) {
                throw new ArgumentNullException("Update ORG_Store entity is Null");
            }
            try {
                store.IsDelete = true;
                _storeRepository.Update(store);
                _unitOfWork.Commint();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
