using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.OrderRemindSetting{

     
    /// <summary>
	/// 订单消息设置
	/// </summary>
    public class OrderRemindSettingModel : BaseViewModel{
    
        public OrderRemindSettingModel(){
        }
        
        [Required(ErrorMessage = "请输入提醒类型")]
		[Display(Name = "提醒类型")]
        public string ReminderType
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入提醒周期")]
		[Display(Name = "提醒周期")]
        public decimal ReminderCycle
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入提醒颜色")]
		[Display(Name = "提醒颜色")]
        public string ReminderColor
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入超时周期")]
		[Display(Name = "超时周期")]
        public decimal OvertimeCycle
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入超时颜色")]
		[Display(Name = "超时颜色")]
        public string OvertimeColor
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入允许对话框")]
		[Display(Name = "允许对话框")]
        public bool EnabledWarning
		{
			get;
			set;
		}
		
		[Display(Name = "警告消息")]
        public string WarningMessages
		{
			get;
			set;
		}
		
    }
    
    
    public class OrderRemindSettingListModel : BaseListViewModel<SYS_OrderRemindSetting>{

    }
}

