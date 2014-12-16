using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Industry{

     
    /// <summary>
	/// 行业
	/// </summary>
    public class IndustryModel : BaseViewModel{
    
        public IndustryModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
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
    
    
    public class IndustryListModel : BaseListViewModel<SYS_Industry>{

    }
}

