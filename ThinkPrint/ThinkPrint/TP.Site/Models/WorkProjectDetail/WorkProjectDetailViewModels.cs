using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.WorkProjectDetail{

     
    /// <summary>
	/// 制作项目明细
	/// </summary>
    public class WorkProjectDetailModel : BaseViewModel{
    
        public WorkProjectDetailModel(){
        }
        
        [Required(ErrorMessage = "请输入WorkProjectId")]
		[Display(Name = "WorkProjectId")]
        public int WorkProjectId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入BusinessComponentId")]
		[Display(Name = "BusinessComponentId")]
        public int BusinessComponentId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入数量")]
		[Display(Name = "数量")]
        public int Quantity
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入价格")]
		[Display(Name = "价格")]
        public decimal UnitPrice
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
    
    
    public class WorkProjectDetailListModel : BaseListViewModel<SAL_WorkProjectDetail>{

    }
}

