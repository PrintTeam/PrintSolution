using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.BusinessComponent{

     
    /// <summary>
	/// 业务组成
	/// </summary>
    public class BusinessComponentModel : BaseViewModel{
    
        public BusinessComponentModel(){
        }
        
        [Required(ErrorMessage = "请输入BusinessCategoryId")]
		[Display(Name = "BusinessCategoryId")]
        public int BusinessCategoryId
		{
			get;
			set;
		}
		
		[Display(Name = "PrintingProcessId")]
        public int PrintingProcessId
		{
			get;
			set;
		}
		
		[Display(Name = "PostpressProcessId")]
        public int PostpressProcessId
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
    
    
    public class BusinessComponentListModel : BaseListViewModel<BUS_BusinessComponent>{

    }
}

