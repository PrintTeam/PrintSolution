using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;

namespace TP.Service.Store {
    public class StoreService:IStoreService {

        private readonly IStoreRepository _storeRepository;      
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork) {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public EntityFramework.Models.ORG_Store GetStore(int StoreID) {
            throw new NotImplementedException();
        }

        public Webdiyer.WebControls.Mvc.PagedList<EntityFramework.Models.ORG_Store> GetStoreList(int pageIndex, int pageSize, string searchKey = null) {
            throw new NotImplementedException();
        }

        public void InsertStore(EntityFramework.Models.ORG_Store store) {
            throw new NotImplementedException();
        }

        public void UpdateStore(EntityFramework.Models.ORG_Store store) {
            throw new NotImplementedException();
        }

        public void DeleteStore(EntityFramework.Models.ORG_Store store) {
            throw new NotImplementedException();
        }
    }
}
