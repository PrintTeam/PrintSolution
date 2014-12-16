using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.MembershipCardCategory{

     
    /// <summary>
	/// 会员卡类型
	/// </summary>
    public class MembershipCardCategoryModel : BaseViewModel{
    
        public MembershipCardCategoryModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
    }
    
    
    public class MembershipCardCategoryListModel : BaseListViewModel<CRM_MembershipCardCategory>{

    }
}

