using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.EmployeeDepartmentHistory{

     
    /// <summary>
	/// 部门员工工作信息
	/// </summary>
    public class EmployeeDepartmentHistoryModel : BaseViewModel{
    
        public EmployeeDepartmentHistoryModel(){
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
    
    
    public class EmployeeDepartmentHistoryListModel : BaseListViewModel<ORG_EmployeeDepartmentHistory>{

    }
}

