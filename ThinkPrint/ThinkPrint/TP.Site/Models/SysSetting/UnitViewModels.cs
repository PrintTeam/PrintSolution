using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.SysSetting {
    public class UnitModel : BaseViewModel {

        [Required(ErrorMessage="计量单位名称不能为空")]
        [StringLength(50, ErrorMessage = "计量单位名称不能超过50个字符")]
        [Display(Name = "单位名称")]
        public String Name { get; set; }

        [Required(ErrorMessage = "计量单位类型不能为空")]
        [StringLength(50, ErrorMessage = "计量单位类型不能超过2个字符")]
        [Display(Name = "单位类型")]
        public String UnitType { get; set; }

        [Display(Name = "备注")]
        public String Description { get; set; }
    }

    public class UnitListModel : BaseListViewModel<SYS_Unit> {

    }
}