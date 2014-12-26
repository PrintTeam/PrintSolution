using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.ProcessRequirement{

     
    /// <summary>
	/// 制作要求
	/// </summary>
    public class ProcessRequirementModel : BaseViewModel{
    
        public ProcessRequirementModel(){
        }

        [Required(ErrorMessage = "请输入制作项目")]
        [Display(Name = "制作项目")]
        public int WorkProjectId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
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
		
		[Display(Name = "说明")]
        public string Illustrate
		{
			get;
			set;
		}

        public List<SelectListItem> BusinessTypeList {
            get;
            set;
        }

        public List<SelectListItem> WorkProjects {
            get;
            set;
        }
		
    }
    
    
    public class ProcessRequirementListModel : BaseListViewModel<PMW_ProcessRequirement>{
        public List<SYS_SysSetting> Parameters {
            get;
            set;
        }
    }
}

