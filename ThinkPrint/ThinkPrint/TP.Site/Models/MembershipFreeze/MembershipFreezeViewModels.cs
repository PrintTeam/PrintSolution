using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.MembershipFreeze{

     
    /// <summary>
	/// 冻结
	/// </summary>
    public class MembershipFreezeModel : BaseViewModel{
    
        public MembershipFreezeModel(){
        }
        
        [Required(ErrorMessage = "请输入MembershipCardId")]
		[Display(Name = "MembershipCardId")]
        public int MembershipCardId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入冻结金额")]
		[Display(Name = "冻结金额")]
        public decimal FreezeAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入冻结原因")]
		[Display(Name = "冻结原因")]
        public string FreezeReason
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
		
        [Required(ErrorMessage = "请输入审批人")]
		[Display(Name = "审批人")]
        public string ApprovedPerson
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入审批时间")]
		[Display(Name = "审批时间")]
        public DateTime ApprovedDate
		{
			get;
			set;
		}
		
    }
    
    
    public class MembershipFreezeListModel : BaseListViewModel<CRM_MembershipFreeze>{

    }
}

