using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PrintingPriceRangeList{

     
    /// <summary>
	/// 印刷价格区间
	/// </summary>
    public class PrintingPriceRangeListModel : BaseViewModel{
    
        public PrintingPriceRangeListModel(){
        }
        
        [Required(ErrorMessage = "请输入PrintingProcessId")]
		[Display(Name = "PrintingProcessId")]
        public int PrintingProcessId
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
    
    
    public class PrintingPriceRangeListListModel : BaseListViewModel<BPM_PrintingPriceRangeList>{

    }
}

