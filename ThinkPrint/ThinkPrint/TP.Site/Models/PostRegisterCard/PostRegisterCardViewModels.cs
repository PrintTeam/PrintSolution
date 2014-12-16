using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PostRegisterCard{

     
    /// <summary>
	/// 补办会员卡
	/// </summary>
    public class PostRegisterCardModel : BaseViewModel{
    
        public PostRegisterCardModel(){
        }
        
        [Required(ErrorMessage = "请输入MembershipCardId")]
		[Display(Name = "MembershipCardId")]
        public int MembershipCardId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入原卡编号")]
		[Display(Name = "原卡编号")]
        public string QuondamCardNumber
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入费用")]
		[Display(Name = "费用")]
        public decimal Charge
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
		
        [Required(ErrorMessage = "请输入办理时间")]
		[Display(Name = "办理时间")]
        public DateTime HandleDate
		{
			get;
			set;
		}
		
    }
    
    
    public class PostRegisterCardListModel : BaseListViewModel<CRM_PostRegisterCard>{

    }
}

