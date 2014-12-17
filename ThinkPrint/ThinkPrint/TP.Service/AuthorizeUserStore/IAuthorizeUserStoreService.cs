using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.AuthorizeUserStore {

    public interface IAuthorizeUserStoreService {
        ORG_AuthorizeUserStore GetAuthorizeUserStore(int  StoreId,int  UserId);
        List<ORG_AuthorizeUserStore> GetAuthorizeUserStores();
        PagedList<ORG_AuthorizeUserStore> GetAuthorizeUserStores(int pageIndex, int pageSize, string searchKey = null);
        void InsertAuthorizeUserStore(ORG_AuthorizeUserStore AuthorizeUserStore);
        void UpdateAuthorizeUserStore(ORG_AuthorizeUserStore AuthorizeUserStore);
        void DeleteAuthorizeUserStore(ORG_AuthorizeUserStore AuthorizeUserStore);
    }
}

