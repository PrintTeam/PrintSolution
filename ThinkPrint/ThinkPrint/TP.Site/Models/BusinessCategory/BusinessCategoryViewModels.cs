using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.BusinessCategory
{


    /// <summary>
    /// 业务类型
    /// </summary>
    public class BusinessCategoryModel : BaseViewModel
    {
        public BusinessCategoryModel()
        {
            BusinessTypeList = new List<SelectListItem>();
        }
        public IList<SelectListItem> BusinessTypeList { get; set; }

        [Required(ErrorMessage = "请输入名称")]
        [StringLength(20, ErrorMessage = "业务类型名称过长.")]
        [Display(Name = "名称")]
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入显示顺序")]
        [Display(Name = "显示顺序")]
        public int DisplayOrder
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入业务类别")]
        [Display(Name = "业务类别")]
        public string BusinessType
        {
            get;
            set;
        }

        public string BusinessTypeName
        {
            get;
            set;
        }

        [Display(Name = "助记码")]
        [StringLength(20, ErrorMessage = "助记码过长.")]
        public string MnemonicCode
        {
            get;
            set;
        }

        [Display(Name = "描述")]
        public string Description
        {
            get;
            set;
        }

    }


    public class BusinessCategoryListModel : BaseListViewModel<BUS_BusinessCategory>
    {
        public BusinessCategoryListModel()
        {
            BusinessTypeList = new List<SYS_SysSetting>();
        }
        public IList<SYS_SysSetting> BusinessTypeList { get; set; }
    }
}

