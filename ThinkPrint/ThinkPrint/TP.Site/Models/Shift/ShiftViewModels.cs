using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Shift{

     
    /// <summary>
	/// 工作轮班信息
	/// </summary>
    public class ShiftModel : BaseViewModel{
    
        public ShiftModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入开始时间")]
		[Display(Name = "开始时间")]
        public DateTime StartDate
		{
			get;
			set;
		}
		
		[Display(Name = "结束时间")]
        public DateTime EndDate
		{
			get;
			set;
		}
		
    }
    
    
    public class ShiftListModel : BaseListViewModel<ORG_Shift>{

    }
}

