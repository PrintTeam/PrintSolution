using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.ProcessRequirement{

     
    /// <summary>
	/// 制作要求
	/// </summary>
    public class ProcessRequirementModel : BaseViewModel{
    
        public ProcessRequirementModel(){
        }
        
        [Required(ErrorMessage = "请输入WorkProjectId")]
		[Display(Name = "WorkProjectId")]
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
		
        [Required(ErrorMessage = "请输入工序类别")]
		[Display(Name = "工序类别")]
        public string ProcessType
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
		
    }
    
    
    public class ProcessRequirementListModel : BaseListViewModel<PMW_ProcessRequirement>{

    }
}

