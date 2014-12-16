using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.VoucherData{

     
    /// <summary>
	/// 单据数据
	/// </summary>
    public class VoucherDataModel : BaseViewModel{
    
        public VoucherDataModel(){
        }
        
        [Required(ErrorMessage = "请输入VoucherEncodingRuleId")]
		[Display(Name = "VoucherEncodingRuleId")]
        public int VoucherEncodingRuleId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入当前值")]
		[Display(Name = "当前值")]
        public string CurrentValue
		{
			get;
			set;
		}
		
    }
    
    
    public class VoucherDataListModel : BaseListViewModel<SYS_VoucherData>{

    }
}

