using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Order{

     
    /// <summary>
	/// 订单信息
	/// </summary>
    public class OrderModel : BaseViewModel{
    
        public OrderModel(){
        }
        
        [Required(ErrorMessage = "请输入CustomerId")]
		[Display(Name = "CustomerId")]
        public int CustomerId
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入订单编号")]
		[Display(Name = "订单编号")]
        public string OrderNumber
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入订单类型")]
		[Display(Name = "订单类型")]
        public string OrderType
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入订单来源")]
		[Display(Name = "订单来源")]
        public bool OnlineOrderFlag
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入客户名称")]
		[Display(Name = "客户名称")]
        public string CustomerName
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
		
        [Required(ErrorMessage = "请输入联系人")]
		[Display(Name = "联系人")]
        public string Contact
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
		
        [Required(ErrorMessage = "请输入地址")]
		[Display(Name = "地址")]
        public string Address
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入负责人")]
		[Display(Name = "负责人")]
        public string ResponsiblePerson
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否需要发票")]
		[Display(Name = "是否需要发票")]
        public bool IsInvoice
		{
			get;
			set;
		}
		
		[Display(Name = "发票抬头")]
        public string InvoiceHead
		{
			get;
			set;
		}
		
		[Display(Name = "发票金额")]
        public decimal InvoiceAmount
		{
			get;
			set;
		}
		
		[Display(Name = "订单税率")]
        public decimal OrderTaxRate
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入总金额")]
		[Display(Name = "总金额")]
        public decimal TotalAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入支付类型")]
		[Display(Name = "支付类型")]
        public string PaymentType
		{
			get;
			set;
		}
		
		[Display(Name = "支付时间")]
        public DateTime PaymentDate
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否预收")]
		[Display(Name = "是否预收")]
        public bool IsAdvancesReceived
		{
			get;
			set;
		}
		
		[Display(Name = "预收金额")]
        public decimal PrepaymentsAmount
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否自取")]
		[Display(Name = "是否自取")]
        public bool IsPickup
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否结算")]
		[Display(Name = "是否结算")]
        public bool IsCashIn
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否欠款")]
		[Display(Name = "是否欠款")]
        public bool IsDebt
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入欠款金额")]
		[Display(Name = "欠款金额")]
        public decimal DebtAmount
		{
			get;
			set;
		}
		
		[Display(Name = "结账时间")]
        public DateTime CloseAccountsDate
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否交货")]
		[Display(Name = "是否交货")]
        public bool IsDelivery
		{
			get;
			set;
		}
		
		[Display(Name = "交付时间")]
        public DateTime DeliveryTtime
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入紧急程度")]
		[Display(Name = "紧急程度")]
        public int UrgencyLevel
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入是否出样")]
		[Display(Name = "是否出样")]
        public bool IsSample
		{
			get;
			set;
		}
		
		[Display(Name = "存储介质")]
        public string StoredMedium
		{
			get;
			set;
		}
		
		[Display(Name = "介质数量")]
        public int MediumNumber
		{
			get;
			set;
		}
		
		[Display(Name = "撤销人")]
        public string RevocatoryPersonnel
		{
			get;
			set;
		}
		
		[Display(Name = "撤销时间")]
        public DateTime RevocatoryDate
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入开单人")]
		[Display(Name = "开单人")]
        public string MakePersonnel
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入开单时间")]
		[Display(Name = "开单时间")]
        public DateTime MakeOrderDate
		{
			get;
			set;
		}
		
        [Required(ErrorMessage = "请输入订单状态")]
		[Display(Name = "订单状态")]
        public string OrderStatus
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
    
    
    public class OrderListModel : BaseListViewModel<SAL_Order>{

    }
}

