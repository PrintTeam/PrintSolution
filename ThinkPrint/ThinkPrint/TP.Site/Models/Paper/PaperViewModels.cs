using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.Paper;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Paper{

     
    /// <summary>
	/// 纸张信息
	/// </summary>
    public class PaperModel : BaseViewModel{
    
        public PaperModel(){
        }

        [Required(ErrorMessage = "请输入纸张类型")]
        [Display(Name = "纸张类型")]
        public int PaperCategoryId
		{
			get;
			set;
		}

        [Required(ErrorMessage = "请输入纸张尺寸")]
        [Display(Name = "纸张尺寸")]
        public int PaperSizeId
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
		[Display(Name = "助记码")]
        public string MnemonicCode
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入克重")]
		[Display(Name = "克重")]
        public decimal Weight
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

        public List<SelectListItem> PaperSizes {
            get;
            set;
        }

        public List<SelectListItem> PaperCategorys {
            get;
            set;
        }
		
    }
    
    
    public class PaperListModel : BaseListViewModel<BOMPaper>{

    }
}

