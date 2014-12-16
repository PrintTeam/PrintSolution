using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.MembershipCard{

     
    /// <summary>
	/// 会员卡信息
	/// </summary>
    public class MembershipCardModel : BaseViewModel{
    
        public MembershipCardModel(){
        }
        
        [Required(ErrorMessage = "请输入MembershipCardCategoryId")]
		[Display(Name = "MembershipCardCategoryId")]
        public int MembershipCardCategoryId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入StoreId")]
		[Display(Name = "StoreId")]
        public int StoreId
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
		
        [Required(ErrorMessage = "请输入卡编号")]
		[Display(Name = "卡编号")]
        public string CardNumber
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
		
        [Required(ErrorMessage = "请输入持卡人")]
		[Display(Name = "持卡人")]
        public string Cardholder
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
		
		[Display(Name = "QQ")]
        public int QQ
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
		
        [Required(ErrorMessage = "请输入地址")]
		[Display(Name = "地址")]
        public string Address
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入卡密码")]
		[Display(Name = "卡密码")]
        public string CardPassword
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入证件类型")]
		[Display(Name = "证件类型")]
        public string CredentialsType
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入证件号码")]
		[Display(Name = "证件号码")]
        public string CredentialsNum
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入账户余额")]
		[Display(Name = "账户余额")]
        public decimal AccountBalance
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入赠送金额")]
		[Display(Name = "赠送金额")]
        public decimal PresenterAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入押金")]
		[Display(Name = "押金")]
        public decimal Deposit
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入有效日期")]
		[Display(Name = "有效日期")]
        public DateTime EffectiveDate
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入经办人")]
		[Display(Name = "经办人")]
        public string OperatorPerson
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入会员卡状态")]
		[Display(Name = "会员卡状态")]
        public string CardStatus
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
    
    
    public class MembershipCardListModel : BaseListViewModel<CRM_MembershipCard>{

    }
}

