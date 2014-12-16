using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PostpressSalePriceList{

     
    /// <summary>
	/// 后道加工销售价格
	/// </summary>
    public class PostpressSalePriceListModel : BaseViewModel{
    
        public PostpressSalePriceListModel(){
        }
        
        [Required(ErrorMessage = "请输入PostpressPriceRangeId")]
		[Display(Name = "PostpressPriceRangeId")]
        public int PostpressPriceRangeId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入销售价格")]
		[Display(Name = "销售价格")]
        public decimal SalePrice
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
		
        [Required(ErrorMessage = "请输入是否启用")]
		[Display(Name = "是否启用")]
        public bool IsEnabled
		{
			get;
			set;
		}
		
    }
    
    
    public class PostpressSalePriceListListModel : BaseListViewModel<BPM_PostpressSalePriceList>{

    }
}

