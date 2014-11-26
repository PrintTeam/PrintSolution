using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.SysSetting
{
    public class ResourceModel :BaseViewModel
    {
        public ResourceModel()
        {

        }

        [Required(ErrorMessage = "请输入员工名称")]
        [StringLength(20, ErrorMessage = "员工名称过长.")]
        [Display(Name = "员工名称")]
        public string Name { get; set; }
    }
    public class ResourceListModel : BaseListViewModel<SYS_SysSetting> 
    {
        
    }
}