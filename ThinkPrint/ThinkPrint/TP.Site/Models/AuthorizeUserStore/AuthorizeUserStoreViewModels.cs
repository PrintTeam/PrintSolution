using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.AuthorizeUserStore{

     
    /// <summary>
	/// 店铺用户授权
	/// </summary>
    public class AuthorizeUserStoreModel : BaseViewModel{
    
        public AuthorizeUserStoreModel(){
        }
        
        [Required(ErrorMessage = "请输入授权人")]
		[Display(Name = "授权人")]
        public string AuthorizedPerson
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否店长")]
		[Display(Name = "是否店长")]
        public bool IsStoreManager
		{
			get;
			set;
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
		
		[Display(Name = "描述")]
        public string Description
		{
			get;
			set;
		}
		
    }
    
    
    public class AuthorizeUserStoreListModel : BaseListViewModel<ORG_AuthorizeUserStore>{

    }
}

