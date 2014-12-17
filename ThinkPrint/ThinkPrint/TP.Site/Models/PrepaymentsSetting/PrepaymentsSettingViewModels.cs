using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PrepaymentsSetting{

     
    /// <summary>
	/// 预收款设置信息
	/// </summary>
    public class PrepaymentsSettingModel : BaseViewModel{
    
        public PrepaymentsSettingModel(){
        }

        public int PrepaymentsSettingId {
            get;
            set;
        }
        
        [Required(ErrorMessage = "请输入订单最小金额")]
		[Display(Name = "订单最小金额")]
        public decimal OrderMinAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入订单最大金额")]
		[Display(Name = "订单最大金额")]
        public decimal OrderMaxAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入预收金额")]
		[Display(Name = "预收金额")]
        public decimal PrepaymentsAmount
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
    
    
    public class PrepaymentsSettingListModel : BaseListViewModel<SYS_PrepaymentsSetting>{

    }
}

