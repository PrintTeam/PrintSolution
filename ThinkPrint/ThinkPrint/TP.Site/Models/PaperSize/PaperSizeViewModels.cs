using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PaperSize{

     
    /// <summary>
	/// 纸张尺寸
	/// </summary>
    public class PaperSizeModel : BaseViewModel{
    
        public PaperSizeModel(){
        }
        
        [Required(ErrorMessage = "请输入名称")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入编码")]
		[Display(Name = "编码")]
        public string UniqueCode
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入高度")]
        [DisplayFormat(DataFormatString="0.00")]
		[Display(Name = "高度")]
        public decimal Height
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入宽度")]
		[Display(Name = "宽度")]
        [DisplayFormat(DataFormatString = "0.00")]
        public decimal Width
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
    
    
    public class PaperSizeListModel : BaseListViewModel<BOM_PaperSize>{

    }
}

