using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PostpressPriceRangeList{

     
    /// <summary>
	/// 后道加工价格区间
	/// </summary>
    public class PostpressPriceRangeListModel : BaseViewModel{
    
        public PostpressPriceRangeListModel(){
        }
        
        [Required(ErrorMessage = "请输入PostpressProcessId")]
		[Display(Name = "PostpressProcessId")]
        public int PostpressProcessId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入UnitId")]
		[Display(Name = "UnitId")]
        public int UnitId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入Form")]
		[Display(Name = "Form")]
        public int Form
		{
			get;
			set;
		}
		
		[Display(Name = "To")]
        public int To
		{
			get;
			set;
		}
		
		[Display(Name = "成本价格")]
        public decimal CostPrice
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
    
    
    public class PostpressPriceRangeListListModel : BaseListViewModel<PMW_PostpressPriceRangeList>{

    }
}

