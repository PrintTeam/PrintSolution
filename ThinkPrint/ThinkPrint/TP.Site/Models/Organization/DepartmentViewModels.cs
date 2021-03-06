﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Organization
{

     
    /// <summary>
	/// 部门信息
	/// </summary>
    public class DepartmentModel : BaseViewModel{
    
        public DepartmentModel(){
        }
        
		[Display(Name = "CompanyId")]
        public int CompanyId
		{
			get;
			set;
		}

        public string CompanyName { get; set; }
		
        [Required(ErrorMessage = "请输入名称")]
        [StringLength(20, ErrorMessage = "部门名称过长.")]
		[Display(Name = "名称")]
        public string Name
		{
			get;
			set;
		}
		
		[Display(Name = "简称")]
        [StringLength(20, ErrorMessage = "部门简称过长.")]
        public string ShortName
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
    
    
    public class DepartmentListModel : BaseListViewModel<ORG_Department>{

    }
}

