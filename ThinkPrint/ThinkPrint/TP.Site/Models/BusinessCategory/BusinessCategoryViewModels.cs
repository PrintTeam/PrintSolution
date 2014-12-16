using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.BusinessCategory{

     
    /// <summary>
	/// 业务类型
	/// </summary>
    public class BusinessCategoryModel : BaseViewModel{
    
        public BusinessCategoryModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入显示顺序")]
		[Display(Name = "显示顺序")]
        public int DisplayOrder
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入业务类别")]
		[Display(Name = "业务类别")]
        public string BusinessType
		{
			get;
			set;
		}
		
		[Display(Name = "助记码")]
        public string MnemonicCode
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
    
    
    public class BusinessCategoryListModel : BaseListViewModel<BUS_BusinessCategory>{

    }
}

