using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.CardConsumption{

     
    /// <summary>
	/// 会员卡消费
	/// </summary>
    public class CardConsumptionModel : BaseViewModel{
    
        public CardConsumptionModel(){
        }
        
        [Required(ErrorMessage = "请输入MembershipCardId")]
		[Display(Name = "MembershipCardId")]
        public int MembershipCardId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入订单编号")]
		[Display(Name = "订单编号")]
        public string OrderNumber
		{
			get;
			set;
		}
		
		[Display(Name = "消费金额")]
        public decimal ConsumptionAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入经办店铺")]
		[Display(Name = "经办店铺")]
        public string OperatorStoresCode
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入经办人")]
		[Display(Name = "经办人")]
        public string OperatorPerson
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
    
    
    public class CardConsumptionListModel : BaseListViewModel<CRM_CardConsumption>{

    }
}

