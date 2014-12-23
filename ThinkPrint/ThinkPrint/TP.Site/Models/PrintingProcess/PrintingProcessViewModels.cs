using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Service.PrintingProcess;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PrintingProcess{

     
    /// <summary>
	/// 印刷工序
	/// </summary>
    public class PrintingProcessModel : BaseViewModel{
    
        public PrintingProcessModel(){
        }        
       
		[Display(Name = "MachineId")]
        public int MachineId
		{
			get;
			set;
		}       
		
        [Required(ErrorMessage = "请输入工序类别")]
		[Display(Name = "工序类别")]
        public string ProcessType
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
		
		[Display(Name = "简称")]
        public string ShortName
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
		
        [Required(ErrorMessage = "请输入组成编码")]
		[Display(Name = "组成编码")]
        public string PartsAttributeCode
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入面")]
		[Display(Name = "面")]
        public string SideProperty
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入色彩类别")]
		[Display(Name = "色彩类别")]
        public string ColorType
		{
			get;
			set;
		}

        public List<SelectListItem> Machines {
            get;
            set;
        }

        public List<SelectListItem> ProcessTypes {
            get;
            set;
        }

        public List<SelectListItem> ColorTypes {
            get;
            set;
        }
		
    }
    
    
    public class PrintingProcessListModel : BaseListViewModel<PMWPrintingProcess>{

    }
}

