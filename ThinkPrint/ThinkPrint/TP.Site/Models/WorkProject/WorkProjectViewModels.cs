using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.WorkProject{

     
    /// <summary>
	/// 制作项目
	/// </summary>
    public class WorkProjectModel : BaseViewModel{
    
        public WorkProjectModel(){
        }
        
        [Required(ErrorMessage = "请输入UnitId")]
		[Display(Name = "UnitId")]
        public int UnitId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入OrderId")]
		[Display(Name = "OrderId")]
        public int OrderId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入项目名称")]
		[Display(Name = "项目名称")]
        public string ProjectName
		{
			get;
			set;
		}
		
		[Display(Name = "文件名称")]
        public string FileName
		{
			get;
			set;
		}
		
		[Display(Name = "文件地址")]
        public string FilePath
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入规格")]
		[Display(Name = "规格")]
        public string Standard
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入项目类型")]
		[Display(Name = "项目类型")]
        public string ProjectType
		{
			get;
			set;
		}
		
		[Display(Name = "部件类型")]
        public string PartsType
		{
			get;
			set;
		}
		
		[Display(Name = "P数")]
        public int PNumber
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
    
    
    public class WorkProjectListModel : BaseListViewModel<SAL_WorkProject>{

    }
}

