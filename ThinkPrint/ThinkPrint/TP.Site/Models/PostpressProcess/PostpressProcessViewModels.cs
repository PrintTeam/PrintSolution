using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Service.PostpressProcess;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.PostpressProcess{

     
    /// <summary>
	/// 印后工序
	/// </summary>
    public class PostpressProcessModel : BaseViewModel{
    
        public PostpressProcessModel(){
        }
        
        [Required(ErrorMessage = "请输入MachineId")]
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
		
        [Required(ErrorMessage = "请输入编码")]
		[Display(Name = "编码")]
        public string UniqueCode
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
		
		[Display(Name = "面")]
        public string SideProperty
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入价格模式")]
		[Display(Name = "价格模式")]
        public String PricingModels
		{
			get;
			set;
		}
		
    }
    
    
    public class PostpressProcessListModel : BaseListViewModel<PMWPostpressProcess>{

    }
}

