using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Machine{

     
    /// <summary>
	/// 机器设备
	/// </summary>
    public class MachineModel : BaseViewModel{
    
        public MachineModel(){
        }
        
        [Required(ErrorMessage = "请输入MachineCategoryId")]
		[Display(Name = "MachineCategoryId")]
        public int MachineCategoryId
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
		
        [Required(ErrorMessage = "请输入设备类别")]
		[Display(Name = "设备类别")]
        public string MachineType
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
		
    }
    
    
    public class MachineListModel : BaseListViewModel<PMW_Machine>{

    }
}

