using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Service.Machine;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Machine{

     
    /// <summary>
	/// 机器设备
	/// </summary>
    public class MachineModel : BaseViewModel{
    
        public MachineModel(){
        }

        [Required(ErrorMessage = "请输入机器类型")]
        [Display(Name = "机器类型")]
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
        [StringLength(3, ErrorMessage = "{0}最大长度为2")]
        public string MachineType
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入色彩类别")]
        [StringLength(3,ErrorMessage="{0}最大长度为3")]
		[Display(Name = "色彩类别")]
        public string ColorType
		{
			get;
			set;
		}

        public List<SelectListItem> MachineCategorys {
            get;
            set;
        }

        public List<SelectListItem> ColorCategorys {
            get;
            set;
        }

        public List<SelectListItem> MachineTypes {

            get;
            set;
        }
		
    }


    public class MachineListModel : BaseListViewModel<PMWMachine> {

    }
}

