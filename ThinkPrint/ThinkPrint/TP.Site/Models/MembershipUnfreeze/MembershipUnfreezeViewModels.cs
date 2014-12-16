using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.MembershipUnfreeze{

     
    /// <summary>
	/// 解冻
	/// </summary>
    public class MembershipUnfreezeModel : BaseViewModel{
    
        public MembershipUnfreezeModel(){
        }
        
        [Required(ErrorMessage = "请输入MembershipCardId")]
		[Display(Name = "MembershipCardId")]
        public int MembershipCardId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入解冻原因")]
		[Display(Name = "解冻原因")]
        public string UnfreezeReason
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
    
    
    public class MembershipUnfreezeListModel : BaseListViewModel<CRM_MembershipUnfreeze>{

    }
}

