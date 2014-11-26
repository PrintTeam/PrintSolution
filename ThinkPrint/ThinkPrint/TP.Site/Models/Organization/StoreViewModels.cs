using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Organization {
    public class StoreModel : BaseViewModel {
        public int CompanyID { get; set; }
        [Display(Name="店铺名称")]
        public String Name { get; set; }
        [Display(Name = "店铺编号")]
        public String UniqueCode { get; set; }
        [Display(Name = "店铺地址")]
        public String Address { get; set; }
         [Display(Name = "联系电话")]
        public String Telephone { get; set; }
         [Display(Name = "负责人")]
        public String ResponsiblePerson { get; set; }
         [Display(Name = "备注")]
        public String Description { get; set; }
    }

    public class StoreListModel : BaseListViewModel<ORG_Store> {

    }
}