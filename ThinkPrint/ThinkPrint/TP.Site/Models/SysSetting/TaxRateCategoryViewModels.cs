using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.SysSetting {
    public class TaxRateCategoryModel:BaseViewModel {

        [Required(ErrorMessage="税率分类名称不能为空")]
        [Display(Name="名称")]
        public String Name { get; set; }
        [Required(ErrorMessage="税率不能为空")]
        [Range(typeof(decimal),"0.00","1.00")]
        [DisplayFormat(DataFormatString = "{0: P}")]
        [Display(Name="税率")]
        public decimal TaxRate { get; set; }
        [Display(Name="备注")]
        public String Description { get; set; }

    }

    public class TaxRateCategoryListModel : BaseListViewModel<SYS_TaxRateCategory> {

    }
}