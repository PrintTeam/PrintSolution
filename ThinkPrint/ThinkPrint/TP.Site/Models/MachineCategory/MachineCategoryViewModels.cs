using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.MachineCategory{

     
    /// <summary>
	/// 机器类型
	/// </summary>
    public class MachineCategoryModel : BaseViewModel{
    
        public MachineCategoryModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
    }
    
    
    public class MachineCategoryListModel : BaseListViewModel<PMW_MachineCategory>{

    }
}

