using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.SysSetting
{
    public class ResourceModel : BaseViewModel
    {
        public ResourceModel()
        {

        }
        public System.Guid RowGuid { get; set; }

        [Required(ErrorMessage = "请输入参数名称")]
        [StringLength(20, ErrorMessage = "参数名称过长.")]
        [Display(Name = "参数名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入参数标识")]
        [StringLength(20, ErrorMessage = "参数标识过长.")]
        [Display(Name = "参数标识")]
        public string Title { get; set; }

        [Required(ErrorMessage = "请输入标识编码")]
        [StringLength(20, ErrorMessage = "标识编码过长.")]
        [Display(Name = "标识编码")]
        public string TitleCode { get; set; }

        [Required(ErrorMessage = "请输入参数编码")]
        [StringLength(20, ErrorMessage = "参数编码过长.")]
        [Display(Name = "参数编码")]
        public string UniqueCode { get; set; }

        [Required(ErrorMessage = "请输入参数值")]
        [StringLength(50, ErrorMessage = "参数值过长.")]
        [Display(Name = "参数值")]
        public string ParamValue { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public string Description { get; set; }
    }
    public class ResourceListModel : BaseListViewModel<SYS_SysSetting>
    {

    }
}