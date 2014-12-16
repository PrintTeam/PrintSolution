using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.CardDictionary{

     
    /// <summary>
	/// 卡片字典
	/// </summary>
    public class CardDictionaryModel : BaseViewModel{
    
        public CardDictionaryModel(){
        }
        
        [Required(ErrorMessage = "请输入卡编号")]
		[Display(Name = "卡编号")]
        public string CardNumber
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入卡片内码")]
		[Display(Name = "卡片内码")]
        public string CardIMEI
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否启用")]
		[Display(Name = "是否启用")]
        public bool IsEnabled
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否废弃")]
		[Display(Name = "是否废弃")]
        public bool IsAbandoned
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入创建时间")]
		[Display(Name = "创建时间")]
        public DateTime CreateDate
		{
			get;
			set;
		}
		
    }
    
    
    public class CardDictionaryListModel : BaseListViewModel<CRM_CardDictionary>{

    }
}

