using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Company{

     
    /// <summary>
	/// 公司信息
	/// </summary>
    public class CompanyModel : BaseViewModel{
    
        public CompanyModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入负责人")]
		[Display(Name = "负责人")]
        public string ResponsiblePerson
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入地址")]
		[Display(Name = "地址")]
        public string Address
		{
			get;
			set;
		}
		
		[Display(Name = "传真")]
        public string FaxNumber
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入电话")]
		[Display(Name = "电话")]
        public string Telephone
		{
			get;
			set;
		}
		
    }
    
    
    public class CompanyListModel : BaseListViewModel<ORG_Company>{

    }
}

