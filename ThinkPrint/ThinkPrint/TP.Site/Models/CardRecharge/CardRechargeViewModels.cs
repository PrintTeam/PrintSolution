using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.CardRecharge{

     
    /// <summary>
	/// 会员卡充值
	/// </summary>
    public class CardRechargeModel : BaseViewModel{
    
        public CardRechargeModel(){
        }
        
        [Required(ErrorMessage = "请输入MembershipCardId")]
		[Display(Name = "MembershipCardId")]
        public int MembershipCardId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入充值金额")]
		[Display(Name = "充值金额")]
        public decimal CreditsAmount
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
		
        [Required(ErrorMessage = "请输入收款人")]
		[Display(Name = "收款人")]
        public string Payee
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入赠送金额")]
		[Display(Name = "赠送金额")]
        public decimal PresenterAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入赠送原因")]
		[Display(Name = "赠送原因")]
        public string PresenterReason
		{
			get;
			set;
		}
		
    }
    
    
    public class CardRechargeListModel : BaseListViewModel<CRM_CardRecharge>{

    }
}

