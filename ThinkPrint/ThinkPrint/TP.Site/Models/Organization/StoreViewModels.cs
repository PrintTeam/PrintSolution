using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Organization {
    public class StoreViewModels : BaseViewModel {

        public String Name { get; set; }
        public String UniqueCode { get; set; }
        public String Address { get; set; }
        public String Telephone { get; set; }
        public String ResponsiblePerson { get; set; }
        public String Description { get; set; }
    }

    public class StoreListModel : BaseListViewModel<ORG_Store> {

    }
}