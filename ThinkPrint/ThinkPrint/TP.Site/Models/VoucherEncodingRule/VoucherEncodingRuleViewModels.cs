﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.VoucherEncodingRule{

     
    /// <summary>
	/// 单据编码规则
	/// </summary>
    public class VoucherEncodingRuleModel : BaseViewModel{
    
        public VoucherEncodingRuleModel(){
        }
        
        [Required(ErrorMessage = "请输入StoreId")]
		[Display(Name = "StoreId")]
        public int StoreId
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
		
        [Required(ErrorMessage = "请输入单据类型")]
		[Display(Name = "单据类型")]
        public string BillType
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入前缀")]
		[Display(Name = "前缀")]
        public string Prefix
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入流水号长度")]
		[Display(Name = "流水号长度")]
        public int SequenceNumberLength
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入流水号起始值")]
		[Display(Name = "流水号起始值")]
        public int SequenceNumberStartValue
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入编码方式")]
		[Display(Name = "编码方式")]
        public string CodeModeType
		{
			get;
			set;
		}
		
		[Display(Name = "年位数")]
        public int YearLength
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
    
    
    public class VoucherEncodingRuleListModel : BaseListViewModel<SYS_VoucherEncodingRule>{

    }
}

