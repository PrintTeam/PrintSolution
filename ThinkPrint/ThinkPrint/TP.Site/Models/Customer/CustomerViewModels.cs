using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Customer{

     
    /// <summary>
	/// 客户信息
	/// </summary>
    public class CustomerModel : BaseViewModel{
    
        public CustomerModel(){
        }
        
        [Required(ErrorMessage = "请输入IndustryId")]
		[Display(Name = "IndustryId")]
        public int IndustryId
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
		
		[Display(Name = "会员编码")]
        public string MembershipCode
		{
			get;
			set;
		}
		
		[Display(Name = "持卡人")]
        public string Cardholder
		{
			get;
			set;
		}
		
		[Display(Name = "卡编号")]
        public string CardNumber
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入客户类型")]
		[Display(Name = "客户类型")]
        public string CustomerType
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
		
        [Required(ErrorMessage = "请输入助记码")]
		[Display(Name = "助记码")]
        public string MnemonicCode
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入性别")]
		[Display(Name = "性别")]
        public bool Sex
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入手机")]
		[Display(Name = "手机")]
        public string MobilePhone
		{
			get;
			set;
		}
		
		[Display(Name = "电话")]
        public string Telephone
		{
			get;
			set;
		}
		
		[Display(Name = "生日")]
        public DateTime Birthday
		{
			get;
			set;
		}
		
		[Display(Name = "邮箱")]
        public string Email
		{
			get;
			set;
		}
		
		[Display(Name = "QQ")]
        public int QQ
		{
			get;
			set;
		}
		
		[Display(Name = "邮编")]
        public string ZipCode
		{
			get;
			set;
		}
		
		[Display(Name = "地址")]
        public string Address
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入信誉等级")]
		[Display(Name = "信誉等级")]
        public int CreditRating
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否记账")]
		[Display(Name = "是否记账")]
        public bool IsCreditCard
		{
			get;
			set;
		}
		
		[Display(Name = "记账额度")]
        public decimal MaximumAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入启用的价格类型")]
		[Display(Name = "启用的价格类型")]
        public string SalePriceType
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
    
    
    public class CustomerListModel : BaseListViewModel<SAL_Customer>{

    }
}

