using System;
using System.Collections.Generic;

namespace TP.EntityFramework.Models
{
    public partial class SAL_Order
    {
        public SAL_Order()
        {
            this.SAL_WorkProject = new List<SAL_WorkProject>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderType { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string CustomerName { get; set; }
        public string MembershipCode { get; set; }
        public string Cardholder { get; set; }
        public string CardNumber { get; set; }
        public string Contact { get; set; }
        public string MobilePhone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string ResponsiblePerson { get; set; }
        public bool IsInvoice { get; set; }
        public string InvoiceHead { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> OrderTaxRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public bool IsAdvancesReceived { get; set; }
        public Nullable<decimal> PrepaymentsAmount { get; set; }
        public bool IsPickup { get; set; }
        public bool IsCashIn { get; set; }
        public bool IsDebt { get; set; }
        public decimal DebtAmount { get; set; }
        public Nullable<System.DateTime> CloseAccountsDate { get; set; }
        public bool IsDelivery { get; set; }
        public Nullable<System.DateTime> DeliveryTtime { get; set; }
        public int UrgencyLevel { get; set; }
        public bool IsSample { get; set; }
        public string StoredMedium { get; set; }
        public Nullable<int> MediumNumber { get; set; }
        public string RevocatoryPersonnel { get; set; }
        public Nullable<System.DateTime> RevocatoryDate { get; set; }
        public string MakePersonnel { get; set; }
        public System.DateTime MakeOrderDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string OrderStatus { get; set; }
        public string Description { get; set; }
        public virtual SAL_Customer SAL_Customer { get; set; }
        public virtual ICollection<SAL_WorkProject> SAL_WorkProject { get; set; }
    }
}
